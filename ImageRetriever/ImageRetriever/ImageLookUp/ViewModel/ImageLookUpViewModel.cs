
using ImageRetriever.Common;
using ImageRetriever.Common.Models;
using ImageRetriever.ImageUpdate.View;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Image = ImageRetriever.Common.Models.Image;

namespace ImageRetriever.ImageLookUp.ViewModel
{
    class ImageLookUpViewModel : BaseVM
    {
        private string heartImage = "Heart.png";
        private string filledHeartImage = "filledHeart.png";
        ZXingScannerPage scanPage;
        private string tagID;
        private string location;
        private string zoneName;
        private string dimensions;
        private string description;
        private string barcode;
        private string status;
        private string color;
        private string type;
        private string name;
        private string weight;
        private string createdOn;
        private bool searchComplete;
        private bool showDetails;
        private bool defaultSearch;
        private bool isBusy;

        private string barcodeID;
        private ObservableCollection<Image> imageList = new ObservableCollection<Image>();
        private ObservableCollection<string> attributeList = new ObservableCollection<string>();
        private AssetRecord assetInfo;
        private string changeFavoriteImage;
        public ICommand CameraCommand { private set; get; }
        public ICommand DetailsCommand { private set; get; }
        public ICommand FavoriteCommand { private set; get; }
        public ICommand SearchCommand { private set; get; }
        public ICommand AddPhotoCommand { private set; get; }
        ProcessAsset processAsset = new ProcessAsset();
        public ImageLookUpViewModel(string name)
        {

            if (name == null)
            {
                DefaultSearch = true;
            }
            else if (name == "default")
            {
                DefaultSearch = true;
            }
            else
            {
                DefaultSearch = false;
                assetInfo = processAsset.GetAssetInfoFromName(name);
                ProcessSearch();
            }
            ChangeFavoriteImage = heartImage;
            CameraCommand = new Command(
                 execute: async () =>
                 {
                     ImageList.Clear();
                     ShowDetails = false;
                     scanPage = new ZXingScannerPage();
                     scanPage.OnScanResult += (result) =>
                     {
                         scanPage.IsScanning = false;
                         Device.BeginInvokeOnMainThread(() =>
                         {
                             Application.Current.MainPage.Navigation.PopModalAsync();
                             TagID = result.Text;

                             assetInfo = processAsset.GetAssetInfoFromTag(TagID);
                             ProcessSearch();
                         });
                     };

                     await Application.Current.MainPage.Navigation.PushModalAsync(scanPage);
                 },
                 canExecute: () =>
                 {
                     return true;
                 });

            DetailsCommand = new Command(
                 execute: () =>
                 {
                     if (assetInfo != null)
                     {
                         ShowDetails = !ShowDetails;
                         SetItemDetails(assetInfo);
                     }
                 },
                 canExecute: () =>
                 {
                     return true;
                 });

            FavoriteCommand = new Command(
                 execute: () =>
                 {
                     FavoritesSelection.ChangeFavorite(assetInfo);
                     if (assetInfo.IsFavorite == false)
                     {
                         ChangeFavoriteImage = heartImage;
                     }
                     else
                     {
                         ChangeFavoriteImage = filledHeartImage;
                     }
                 },
                 canExecute: () =>
                 {
                     return true;
                 });

            SearchCommand = new Command(
                 execute: () =>
                 {
                     IsBusy = true;
                     if (barcodeID != null)
                     {
                         assetInfo = processAsset.GetAssetInfoFromTag(BarCodeID);
                         if (ImageList.Count > 0)
                         {
                             ImageList.Clear();
                         }
                         ProcessSearch();
                     }
                     IsBusy = false;
                 },
                 canExecute: () =>
                 {
                     return true;
                 });
            AddPhotoCommand = new Command(
                 execute: async () =>
                 {
                     if (assetInfo != null)
                     {
                         await Application.Current.MainPage.Navigation.PushModalAsync(new ImageUpdateView(assetInfo.ID));
                     }
                 },
                 canExecute: () =>
                 {
                     return true;
                 });

            MessagingCenter.Subscribe<ImageUpdateView, string[]>(this, "imagePath", (sender, httpAndImagePath) =>
            {
                try
                {
                    var blobInfo = JsonConvert.DeserializeObject<BlobInformation>(httpAndImagePath[0]);
                    var imageNamesFromBlob = blobInfo.Result.Split(',');
                    var pathNameForImageFromBlob = imageNamesFromBlob[0];

                    //have to insert image at the start of list or it doesnt update properly
                    ImageList.Insert(0, new Image(httpAndImagePath[1], assetInfo.ID));

                    var postObj = processAsset.CreateSaveAssetObj(assetInfo.AssetTypeID, assetInfo.ID);
                    ImagesName pictureToAdd = new ImagesName(pathNameForImageFromBlob, "test", true, blobInfo.BlobUrl.ToString().TrimStart('{').TrimEnd('}'));
                    if (postObj.ImagesNames == null)
                    {
                        postObj.ImagesNames = new System.Collections.Generic.List<ImagesName>();
                    }
                    else
                    {
                        foreach (var x in postObj.ImagesNames)
                        {
                            if (x.IsPrimary == true)
                            {
                                x.IsPrimary = false;
                            }
                        }
                        foreach(var assetFieldValue in postObj.AssetFieldValueViewModel)
                        {
                            assetFieldValue.IsReadOnly = "";
                            assetFieldValue.FieldValue = "";
                        }
                    }
                    postObj.ImagesNames.Insert(0, pictureToAdd);
                    postObj.PrimaryImageId = postObj.ImagesNames[0].ImageName;
                    postObj.AssetTags[0].ModifiedBy = null;
                    postObj.AssetTags[0].ModifiedOn = null;
                    processAsset.UpdateImagesInBlob(postObj.ImagesNames);
                    var test = processAsset.ConfigureHttpClient("api/assets/SaveAsset", true, "POST", postObj);
                
                    var test2 = processAsset.ConfigureHttpClient("api/ConfigurationSettings.GetConfigValueByKey/ShowAssetImageOnItemList", true, "GET", null);

                }
                catch (Exception ex)
                {
                    //log error
                }
            });
        }

        public ImageLookUpViewModel() { }

        public void ProcessSearch()
        {
            try
            {
                if (assetInfo != null)
                {
                    if (assetInfo.IsFavorite == false)
                    {
                        ChangeFavoriteImage = heartImage;
                    }
                    else
                    {
                        ChangeFavoriteImage = filledHeartImage;
                    }
                    SearchComplete = true;
                    SessionObjects.BaseImageURL = assetInfo.BlobUrl;
                    Location = assetInfo.LocationName;
                    Name = assetInfo.Name;
                    var imageNamesList = processAsset.GetImagesForAsset(assetInfo.ID);
                    foreach (var x in imageNamesList)
                    {
                        ImageList.Add(new Image(SessionObjects.BaseImageURL + x.ImageName, assetInfo.ID));
                    }
                    var attributesList = processAsset.GetCustomAttributes(assetInfo.AssetTypeID, assetInfo.ID);
                    if (attributesList != null)
                    {
                        SetCustomAttributes(attributesList);
                    }


                }
                else
                {
                    MessagingCenter.Send<ImageLookUpViewModel>(this, "NoImage");
                    TagID = "";
                    SearchComplete = false;
                    ShowDetails = false;
                }
            }
            catch(Exception ex)
            {
                var test = ex.Message;
            }
        }
        public void SetItemDetails(AssetRecord asset)
        {
            Barcode = asset.TAGIds;
            Status = asset.StatusName;
            Type = asset.AssetTypeName;
            Color = asset.Color;
            ZoneName = asset.ZoneName;
            CreatedOn = asset.CreatedOn;
            Description = asset.Description;
        }
        public void SetCustomAttributes(ObservableCollection<AssetFieldValueViewModel> attributeList)
        {
            foreach (var item in attributeList)
            {
                if (item.Name == "Length")
                {
                    Dimensions = "L" + item.FieldValue + "\"";
                }
                else if (item.Name == "Width")
                {
                    Dimensions = Dimensions + " x W" + item.FieldValue + "\"";
                }
                else if (item.Name == "Heighted")
                {
                    Dimensions = Dimensions + " x H" + item.FieldValue + "\"";
                }
                else if (item.Name == "Weight")
                {
                    Weight = item.FieldValue;
                }
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

        public string TagID
        {
            get
            {
                return tagID;
            }
            set
            {
                tagID = value;
                RaisePropertyChanged(nameof(TagID));
            }
        }
        public ObservableCollection<Image> ImageList
        {
            get
            {
                return imageList;
            }
            set
            {
                imageList = value;
                RaisePropertyChanged(nameof(ImageList));
            }
        }
        public ObservableCollection<string> AttributeList
        {
            get
            {
                return attributeList;
            }
            set
            {
                attributeList = value;
                RaisePropertyChanged(nameof(AttributeList));
            }
        }
        public string Dimensions
        {
            get
            {
                return dimensions;
            }
            set
            {
                dimensions = value;
                RaisePropertyChanged(nameof(Dimensions));
            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                var tempLocationName = value.Split('\\');
                if (tempLocationName.Length > 3)
                {
                    int lastElement = tempLocationName.Length - 1;
                    location = tempLocationName[lastElement - 2] + "\\" + tempLocationName[lastElement - 1] + "\\" + tempLocationName[lastElement];
                }
                RaisePropertyChanged(nameof(Location));
            }
        }
        public string Barcode
        {
            get
            {
                return "Barcode: " + barcode;
            }
            set
            {
                barcode = value;
                RaisePropertyChanged(nameof(Barcode));
            }
        }
        public string Status
        {
            get
            {
                return "Status: " + status;
            }
            set
            {
                status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }
        public string Type
        {
            get
            {
                return "Type: " + type;
            }
            set
            {
                type = value;
                RaisePropertyChanged(nameof(Type));
            }
        }
        public string Color
        {
            get
            {
                return "Color: " + color;
            }
            set
            {
                color = value;
                RaisePropertyChanged(nameof(Color));
            }
        }

        public bool ShowDetails
        {
            get
            {
                return showDetails;
            }
            set
            {
                showDetails = value;
                RaisePropertyChanged(nameof(ShowDetails));
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public bool SearchComplete
        {
            get
            {
                return searchComplete;
            }
            set
            {
                searchComplete = value;
                RaisePropertyChanged(nameof(SearchComplete));
            }
        }
        public string Weight
        {
            get
            {
                return "Weight: " + weight;
            }
            set
            {
                weight = value;
                RaisePropertyChanged(nameof(Weight));
            }
        }
        public string ChangeFavoriteImage
        {
            get
            {
                return changeFavoriteImage;
            }
            set
            {
                changeFavoriteImage = value;
                RaisePropertyChanged(nameof(ChangeFavoriteImage));
            }
        }

        public string BarCodeID
        {
            get
            {
                return barcodeID;
            }
            set
            {
                barcodeID = value;
                RaisePropertyChanged(nameof(BarCodeID));
            }
        }
        public bool DefaultSearch
        {
            get
            {
                return defaultSearch;
            }
            set
            {
                defaultSearch = value;
                RaisePropertyChanged(nameof(DefaultSearch));
            }
        }
        public string ZoneName
        {
            get
            {
                return "Zone: " + zoneName;
            }
            set
            {
                zoneName = value;
                RaisePropertyChanged(nameof(ZoneName));
            }
        }
        public string CreatedOn
        {
            get
            {
                return "Created on: " + createdOn;
            }
            set
            {
                createdOn = value;
                RaisePropertyChanged(nameof(CreatedOn));
            }
        }
        public string Description
        {
            get
            {
                return "Description: " + description;
            }
            set
            {
                description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

    }
}
