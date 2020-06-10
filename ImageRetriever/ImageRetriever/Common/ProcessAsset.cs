using ImageRetriever.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms.Internals;
using static ImageRetriever.ImageLookUp.Models.ImageLookUpModels;

namespace ImageRetriever.Common
{

    public class ProcessAsset : BaseVM
    {
        /// <summary>
        /// Returns an AssetRecord for the given EPC. 
        /// </summary>
        /// <param name="epc">EPC of barcode or rfid tag being searched</param>
        /// <returns></returns>
        public AssetRecord GetAssetInfoFromTag(string epc)
        {

            var returnAssetinfo = new AssetRecord();
            try
            {
                //revert to epc as parameter in PostAssetInfo
                PostAssetInfo assetInfo = new PostAssetInfo(epc, "TAGIds");
                var response = base.ConfigureHttpClient("api/assets/FilterAssetList", true, "POST", assetInfo);
                if (response != "")
                {
                    Asset asset = JsonConvert.DeserializeObject<Asset>(response);
                    if (asset.AssetRecords.Count() != 0)
                    {
                        returnAssetinfo = asset.AssetRecords.FirstOrDefault(s => s.TAGIds == epc);
                    }
                    else
                    {
                        returnAssetinfo = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO handle exception
            }

            return returnAssetinfo;
        }
        public AssetRecord GetAssetInfoFromName(string Name)
        {

            var returnAssetinfo = new AssetRecord();
            try
            {
                //revert to epc as parameter in PostAssetInfo
                PostAssetInfo assetInfo = new PostAssetInfo(Name, "Name");
                var response = base.ConfigureHttpClient("api/assets/FilterAssetList", true, "POST", assetInfo);
                if (response != "")
                {
                    Asset asset = JsonConvert.DeserializeObject<Asset>(response);
                    if (asset.AssetRecords.Count() != 0)
                    {
                        returnAssetinfo = asset.AssetRecords.FirstOrDefault(s => s.Name == Name);
                    }
                    else
                    {
                        returnAssetinfo = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO handle exception
            }

            return returnAssetinfo;
        }

        //Test function for creating POST body for /saveasset api call

        public DetailedAssetInformation CreateSaveAssetObj(string TypeID, string ID)
        {
            var returnObj = new DetailedAssetInformation();
            var response = base.ConfigureHttpClient("api/assettypes/RenderFormByAssetType/" + TypeID + "/" + ID, true, "GET", null);
            if (response != "")
            {
                 returnObj = JsonConvert.DeserializeObject<DetailedAssetInformation>(response);
            }
            return returnObj;
        }


        public ObservableCollection<AssetFieldValueViewModel> GetCustomAttributes(string TypeID, string ID)
        {
            ObservableCollection<AssetFieldValueViewModel> returnList = new ObservableCollection<AssetFieldValueViewModel>();
            var response = base.ConfigureHttpClient("api/assettypes/RenderFormByAssetType/" + TypeID + "/" + ID, true, "GET", null);
            if(response != "")
            {
                DetailedAssetInformation responseInfo = JsonConvert.DeserializeObject<DetailedAssetInformation>(response);
                returnList = new ObservableCollection<AssetFieldValueViewModel>(responseInfo.AssetFieldValueViewModel);
            }
            return returnList;
        }
        public ObservableCollection<AssetRecord> GetFilteredCollectionOfAssets(string Name, string SelectedStatus, string SelectedType, string SelectedLocation, ObservableCollection<CustomFieldsFilterData> customFieldsFilterData)
        {
            
            ObservableCollection<AssetRecord> rtnList = new ObservableCollection<AssetRecord>();
            //var assetInfo = new AssetRecord();
            try
            {
                PostAssetInfo assetInfo = new PostAssetInfo(Name, SelectedStatus, SelectedType, SelectedLocation, customFieldsFilterData);
                var response = base.ConfigureHttpClient("api/assets/FilterAssetList", true, "POST", assetInfo);
                if (response != "")
                {
                    Asset asset = JsonConvert.DeserializeObject<Asset>(response);

                    if (asset.AssetRecords.Count() != 0)
                    {
                      
                        foreach (var assetFromResponse in asset.AssetRecords)
                        {
                            rtnList.Add(assetFromResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO handle exception
            }
            return rtnList;
        }

        public string GetPrimaryImageForAsset(AssetRecord asset)
        {
            if (asset.BlobUrl != "")
            {
                return asset.ImageName;
            }
            return "";
        }

    
        public List<ImageFileName> GetImagesForAsset(string id)
        {
            List<ImageFileName> rtnList = new List<ImageFileName>();
            var response = base.ConfigureHttpClient("api/assets/GetAssetImageList", true, "GET", id);
            if (response != "")
            {
              rtnList = JsonConvert.DeserializeObject<List<ImageFileName>>(response);
            }
            return rtnList;
        }
        public string GetBlobUrl(AssetRecord asset)
        {
            if (asset.BlobUrl != "")
            {
                return asset.BlobUrl;
            }
            return "";
        }


    }
}
    
