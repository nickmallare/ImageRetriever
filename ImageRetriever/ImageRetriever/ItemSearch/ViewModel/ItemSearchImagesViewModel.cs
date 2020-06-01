
using ImageRetriever.Common;
using ImageRetriever.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageRetriever.ItemSearch.ViewModel
{
    public class ItemSearchImagesViewModel: BaseVM
    {
        private bool isBusy;
        public ItemSearchImagesViewModel() 
        {
          
        }
        public ObservableCollection<AssetRecord> AssetRecordList
        {
            get
            {
                return AssetCollection.ListOfFilteredAssets;
            }
            set
            {
                AssetCollection.ListOfFilteredAssets = value;
                RaisePropertyChanged(nameof(AssetRecordList));
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

    }
}
