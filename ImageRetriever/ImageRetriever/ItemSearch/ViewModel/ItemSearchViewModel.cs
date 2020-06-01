using ImageRetriever.Common;
using ImageRetriever.Common.Models;
using ImageRetriever.ItemSearch.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static ImageRetriever.Common.Operators;
using static ImageRetriever.ItemSearch.Models.ItemSearchModel;

namespace ImageRetriever.ItemSearch.ViewModel
{
    public class ItemSearchViewModel: BaseVM
    {
        private string selectedStatus;
        private string selectedType;
        private string selectedLocation;
        private string attributeValue;
        private int selectedIndex;
        private ItemAttribute selectedAttribute;
        private bool isBusy;
        private string name;
        private ObservableCollection<Operator> operatorNamePickerCollection = new ObservableCollection<Operator>();
        private ObservableCollection<ItemAttribute> attributesPickerCollection = new ObservableCollection<ItemAttribute>();
        private Operator selectedOperator = new Operator();
        private ObservableCollection<CustomFieldsFilterData> listOfCustomFieldsFilterData = new ObservableCollection<CustomFieldsFilterData>();

        public ICommand SearchCommand { private set; get; }
        public ICommand ResetSearchCommand { private set; get; }
        public ICommand AddCommand { private set; get; }
        ProcessAsset processAsset = new ProcessAsset();
        public ItemSearchViewModel()
        {
     
            GenerateStatuslist();
            GenerateAssetTypesList();
            GenerateLocationList();
            GenerateAttributesList();
            GenerateOperatorsList();
            SearchCommand = new Command(
                 execute: async () =>
                 {
                     IsBusy = true;
                     await ProcessSearch();
                     IsBusy = false;
                 },
                 canExecute: () =>
                 {
                     return true;
                 });
            ResetSearchCommand = new Command(
                execute: () =>
                {
                    try
                    {
                        ResetValues();
                    }
                    catch
                    {

                    }

                },
                canExecute: () =>
                {
                    return true;
                });
            AddCommand = new Command(
                 execute: () =>
                 {
                     try
                     {
                         ListOfCustomFieldsFilterData.Add(new CustomFieldsFilterData(selectedAttribute.Id, selectedAttribute.ControlLabelText, selectedOperator.OperatorName, attributeValue));
                     }
                     catch (Exception)
                     {

                     }
                 },
                 canExecute: () =>
                 {
                     return true;
                 });
        }

        private void ResetValues()
        {
            Name = "Name";
            SelectedStatus = null;
            SelectedLocation = null;
            SelectedType = null;
            AttributeValue = null;
            SelectedIndex = -1;
            OperatorNamePickerCollection.Clear();
            ListOfCustomFieldsFilterData.Clear();
        }

        private void SetOperatorsForSelectedAttribute(string operatorName)
        {
            foreach(var x in OperatorNames.OperatorNameList)
            {
                if(x.DataType.Equals(operatorName, StringComparison.InvariantCultureIgnoreCase))
                {
                    OperatorNamePickerCollection.Add(x);
                }
            }
        }
 

     
        private void GenerateOperatorsList()
        {
            var response = base.ConfigureHttpClient("api/custom/GetMastersForAdvancedSearch", true, "GET", null);
            if (response != null && response != "") {
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(response);
                foreach(var x in rootObject.Operators)
                {
                    OperatorNames.OperatorNameList.Add(x);
                }
            }
        }
        private void GenerateLocationList()
        {
            var response = base.ConfigureHttpClient("api/User/GetUserLocations", true, "GET", null);
            if (response != null && response != "")
            {
                Locations.ListOfLocations.Add(null);
                List<Location> status = JsonConvert.DeserializeObject<List<Location>>(response);
                foreach(var x in status)
                {
                    Locations.ListOfLocations.Add(x.LocationName);
                }
            }
        }
        private void GenerateStatuslist()
        {
            var response = base.ConfigureHttpClient("api/assettypes/GetAssetStatuses", true, "GET", null);
            if (response != null && response != "")
            {
                StatusNames.StatusList.Add(null);
                List<Models.ItemSearchModel.Status> status = JsonConvert.DeserializeObject<List<Models.ItemSearchModel.Status>>(response);
                foreach (var x in status)
                {
                    StatusNames.StatusList.Add(x.Name);
                }
            }
        }
        private void GenerateAssetTypesList()
        {
            var response = base.ConfigureHttpClient("api/assettypes/getAllAssetTypes", true, "GET", null);
            if (response != null && response != "")
            {
                TypesOfAssets.AssetTypesList.Add(null);
                List<AssetType> types = JsonConvert.DeserializeObject<List<AssetType>>(response);
                foreach (var x in types)
                {
                    TypesOfAssets.AssetTypesList.Add(x.Name);
                }
            }
        }
        private void GenerateAttributesList()
        {
            var response = base.ConfigureHttpClient("api/genericAttribute/getAttributeList", true, "GET", null);
            if (response != null && response != "")
            {
                var responseList = JsonConvert.DeserializeObject<ObservableCollection<ItemAttribute>>(response);
                AttributesPickerCollection.Add(new ItemAttribute { ControlLabelText = "" });
                foreach (var x in responseList)
                {
                    Attributes.PostAttributeString += $"{x.ControlLabelText},";
                    Attributes.AttributeList.Add(x.ControlLabelText);
                    if (!x.IsDisabled && x.IsDisplayOnSearch)
                    {
                        AttributesPickerCollection.Add(x);
                    }
                }
                if(Attributes.PostAttributeString != null)
                {
                    Attributes.PostAttributeString = Attributes.PostAttributeString.TrimEnd(',');
                }
            }
        }
        private async Task ProcessSearch()
        { 
            try
            {
               
                AssetCollection.ListOfFilteredAssets = await Task.Run(() => processAsset.GetFilteredCollectionOfAssets(Name, SelectedStatus, SelectedType, SelectedLocation, listOfCustomFieldsFilterData));
                if (AssetCollection.ListOfFilteredAssets.Count != 0)
                {
                    MessagingCenter.Send<ItemSearchViewModel>(this, "ProcessingComplete");
                }
                else
                {
                    MessagingCenter.Send<ItemSearchViewModel>(this, "NoFoundAssets");
                }
            }
            catch (Exception)
            {
                // TODO handle exception
            }
        }

        public string SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {
                selectedLocation = value;
                RaisePropertyChanged(nameof(SelectedLocation));
            }
        }
        public string SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                RaisePropertyChanged(nameof(SelectedType));
            }
        }
        public string SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;
                RaisePropertyChanged(nameof(SelectedStatus));
            }
        }
        public string AttributeValue
        {
            get
            {
                return attributeValue;
            }
            set
            {
                attributeValue = value;
                RaisePropertyChanged(nameof(AttributeValue));
            }
        }
        public ItemAttribute SelectedAttribute
        {
            get
            {
                return selectedAttribute;
            }
            set
            {
                selectedAttribute = value;
                OperatorNamePickerCollection.Clear();
                if (selectedAttribute != null)
                {
                    SetOperatorsForSelectedAttribute(selectedAttribute.DataTypeName);
                }
                
            }
        }
        public ObservableCollection<string> LocationList
        {
            get
            {
                return Locations.ListOfLocations;
            }
        }
        public ObservableCollection<string> StatusList
        {
            get
            {
                return StatusNames.StatusList;
            }
        }
        public ObservableCollection<string> AssetTypesList
        {
            get
            {
                return TypesOfAssets.AssetTypesList; 
            }
        }

        public ObservableCollection<string> AttributeList
        {
            get
            {
                return Attributes.AttributeList;
            }
        }

        public ObservableCollection<Operator> OperatorNamePickerCollection
        {
            get
            {
                return operatorNamePickerCollection;
            }
            set
            {
                operatorNamePickerCollection = value;
                RaisePropertyChanged(nameof(OperatorNamePickerCollection));
            }
           
        }
        public bool IsBusy
        {
            get 
            { 
                return isBusy; 
            }
            set 
            { 
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                RaisePropertyChanged(nameof(SelectedIndex));
            }
        }
        public string Name
        {
            get
            {
                if (name == null)
                {
                    return "Name";
                }
                else {
                    return name;
                }
            }
            set
            {
                
                 name = value;
                
                RaisePropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<ItemAttribute> AttributesPickerCollection
        {
            get
            {
                return attributesPickerCollection;
            }
            set
            {
                attributesPickerCollection = value;
                RaisePropertyChanged(nameof(attributesPickerCollection));
            }
        }

        public Operator SelectedOperator
        {
            get
            {
                return selectedOperator;
            }
            set
            {
                selectedOperator = value;
                RaisePropertyChanged(nameof(SelectedOperator));
            }
        }
        public ObservableCollection<CustomFieldsFilterData> ListOfCustomFieldsFilterData
        {
            get
            {
                return listOfCustomFieldsFilterData;
            }
            set
            {
                listOfCustomFieldsFilterData = value;
                RaisePropertyChanged(nameof(ListOfCustomFieldsFilterData));
            }
        }
       
    }
}
