using ImageRetriever.Common.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace ImageRetriever.Common
{
    public static class ImageUpdater
    {
        static public SaveAsset SaveImageForAsset(AssetRecord assetInfo)
        {
            SaveAsset saveAsset = new SaveAsset();
            saveAsset.AssetTypeID = assetInfo.AssetTypeID;
            saveAsset.TAGIds = assetInfo.TAGIds;
            saveAsset.StatusName = assetInfo.StatusName;
            saveAsset.ID = assetInfo.ID;
            saveAsset.AssetTypeID = assetInfo.AssetTypeID;
            saveAsset.LocationName = assetInfo.LocationName;
            saveAsset.IsDisabled = "false";
            saveAsset.CompanyID = assetInfo.CompanyId;
            saveAsset.Name = assetInfo.Name;
            saveAsset.ShowAssetPosition = "false";
            saveAsset.StatusId = assetInfo.StatusId;
            AssetTagsItem assetTagsItem = new AssetTagsItem();
            assetTagsItem.Id = assetInfo.ID;
            assetTagsItem.AssetId = assetInfo.ID;
            assetTagsItem.TagId = assetInfo.TAGIds;
            assetTagsItem.IsDisabled = "false";
            assetTagsItem.CompanyId = assetInfo.CompanyId;
            assetTagsItem.CreatedOn = assetInfo.CreatedOn;
            assetTagsItem.CreatedBy = 247;
            assetTagsItem.ModifiedBy = 247;
            assetTagsItem.ModifiedOn = "2020-06-04T16:35:50.16";
            saveAsset.ImagesNames = new List<ImagesNamesItem>();
        
          
            return saveAsset;
        }
    }
}
