using ImageRetriever.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageRetriever.Common
{
    static class AssetCollection
    {
        public static ObservableCollection<AssetRecord> ListOfFilteredAssets = new ObservableCollection<AssetRecord>();
        public static ObservableCollection<AssetRecord> ListOfFavorites = new ObservableCollection<AssetRecord>();
    }

}
