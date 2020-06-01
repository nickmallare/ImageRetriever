using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageRetriever.Common.Models
{
    public class CustomFieldsFilterData
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string OperatorName { get; set; }
        public string OperatorKey { get; set; }
        public string Value { get; set; }
        public CustomFieldsFilterData(string FieldId, string FieldName, string OperatorName, string Value)
        {
            this.FieldId = FieldId;
            this.FieldName = FieldName;
            this.OperatorName = OperatorName;
            this.Value = Value;
            this.OperatorKey = "";
        }
    }
    public class CustomAttributeList
    {
        public string label { get; set; }
        public string value { get; set; }
    }
    public class PostAssetInfo
    {
        public int AssetTypeID { get; set; }
        public int ZoneId { get; set; }
        public int AssetTypeFilter { get; set; }
        public string ToggleMode { get; set; }
        public string StatusName { get; set; }
        public string StatusNameFromGrid { get; set; }
        public string CountryId { get; set; }
        public List<object> AssetTags { get; set; }
        public ObservableCollection<CustomFieldsFilterData> CustomFieldsFilterData { get; set; }
        public int TypeId { get; set; }
        public string ReportServerUrl { get; set; }
        public string AssetStatusForPickList { get; set; }
        public string ScannedStatus { get; set; }
        public string SearchTemplate { get; set; }
        public string SearchText { get; set; }
        public int LocationID { get; set; }
        public int TakeCount { get; set; }
        public string SelectedCustomAttributeFields { get; set; }
        public List<string> SelectedCustomAttributes { get; set; }
        public int SkipCount { get; set; }
        public string undefined { get; set; }
        public string AssetSortByFieldName { get; set; }
        public int AssetSortBy { get; set; }
        public string LocationName { get; set; }
        public string Name { get; set; }
        public string NameForGrid { get; set; }
        public string TAGIds { get; set; }
        public List<string> LastSeenDays { get; set; }
        public List<string> AssetCreatedFrom { get; set; }
        public List<string> AssetCreatedFromObj { get; set; }
        public List<string> AssetCreatedTo { get; set; }
        public List<string> AssetCreatedToObj { get; set; }
        public string ZoneName { get; set; }
        public string Description { get; set; }
        public string AssetTypeDesc { get; set; }
        public string AssetTypeName { get; set; }
        public string CurrentLocationAddress { get; set; }
        public List<CustomAttributeList> CustomAttributeList { get; set; }
        public void SetAttributesForPost()
        {
            foreach (var x in Attributes.AttributeList)
            {
                if (x != null)
                {
                    Attributes.PostAttributeList.Add(new CustomAttributeList
                    {
                        label = x,
                        value = x
                    });
                }
            }
        }
       
        public PostAssetInfo(string name, string status, string type, string location, ObservableCollection<CustomFieldsFilterData> customFieldsFilterData)
        {
            AssetTypeID = 0;
            ZoneId = 0;
            AssetTypeFilter = 0;
            ToggleMode = "2";
            StatusName = "";
            StatusNameFromGrid = "";
            CountryId = "";
            AssetTags = new List<object>();
            CustomFieldsFilterData = new ObservableCollection<CustomFieldsFilterData>();
            if(customFieldsFilterData != null)
            {
                CustomFieldsFilterData = customFieldsFilterData;
            }
            TypeId = 0;
            ReportServerUrl = "";
            AssetStatusForPickList = "";
            ScannedStatus = "";
            SearchTemplate = "";
            SearchText = "";
            LocationID = 0;
            TakeCount = 100;


            // Only use one attribute? Sonaria implements it this way
            SelectedCustomAttributeFields = Attributes.AttributeList[0];
            SelectedCustomAttributes = new List<string>();
            SelectedCustomAttributes.Add(Attributes.AttributeList[0]);



            SkipCount = 0;
            undefined = "";
            AssetSortByFieldName = "Id";
            AssetSortBy = 1;
            LocationName = "";
            Name = "";
            NameForGrid = "";
            TAGIds = "";
            LastSeenDays = null;
            AssetCreatedFrom = null;
            AssetCreatedFromObj = null;
            AssetCreatedTo = null;
            AssetCreatedToObj = null;
            ZoneName = "";
            Description = "";
            AssetTypeName = "";
            AssetTypeDesc = "";
            CurrentLocationAddress = "";
            SetAttributesForPost();
            CustomAttributeList = new List<CustomAttributeList>();
            CustomAttributeList = Attributes.PostAttributeList;
            if (name != null && name != "Name")
            {
                Name = name;
            }
            else
            {
                Name = "";
            }
            if (status != null)
            {
                StatusName = status;
            }
            else
            {
                StatusName = "";
            }

            if (location != null)
            {
                LocationName = location;
            }
            else
            {
                LocationName = "";
            }

            if (type != null)
            {
                AssetTypeName = type;
            }
            else
            {
                AssetTypeName = "";
            }
        }

        public PostAssetInfo(string searchInfo, string searchField)
        {
            AssetTypeID = 0;
            ZoneId = 0;
            AssetTypeFilter = 2;
            ToggleMode = "2";
            StatusName = "";
            StatusNameFromGrid = "";
            CountryId = "";
            AssetTags = new List<object>();
            TypeId = 0;
            ReportServerUrl = "";
            AssetStatusForPickList = "";
            ScannedStatus = "";
            SearchTemplate = "";
            SearchText = "";
            TakeCount = 20;
            SelectedCustomAttributeFields = "";
            CustomFieldsFilterData = new ObservableCollection<CustomFieldsFilterData>();
            SkipCount = 0;
            undefined = "";
            AssetSortByFieldName = "ID";
            AssetSortBy = 1;
            LocationName = "";
            AssetTypeName = "";
            if (searchField == "TAGIds")
            {
                TAGIds = searchInfo;
                Name = "";
            }
            else if(searchField == "Name")
            {
                Name = searchInfo;
                TAGIds = "";
            }
        }
      
    }
}

