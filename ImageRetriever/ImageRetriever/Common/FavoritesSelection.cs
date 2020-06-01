using ImageRetriever.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ImageRetriever.Common
{
    public static class FavoritesSelection
    {
        public static void ChangeFavoritePreferenceFromList(AssetRecord assetRecord)
        {
            ChangeFavorite(assetRecord);

            UpdateAssetSelectedFromList(assetRecord);
        }
        public static void ChangeFavorite(AssetRecord assetRecord)
        {
            assetRecord.IsFavorite = !assetRecord.IsFavorite;
            if (assetRecord.IsFavorite == true)
            {
                AssetCollection.ListOfFavorites.Add(assetRecord);
            }
            else
            {
                if (AssetCollection.ListOfFavorites.Contains(assetRecord))
                {
                    AssetCollection.ListOfFavorites.Remove(assetRecord);
                }
            }
            MessagingCenter.Send<object, bool>(Application.Current, "ChangeFavoriteImage", assetRecord.IsFavorite);
        }
        public static void UpdateAssetSelectedFromList(AssetRecord assetRecord)
        {

            var index = AssetCollection.ListOfFilteredAssets.IndexOf(assetRecord);
            if (index >= 0)
            {
                AssetCollection.ListOfFilteredAssets.Remove(assetRecord);
                AssetCollection.ListOfFilteredAssets.Insert(index, assetRecord);
            }

        }
        
    }
}
