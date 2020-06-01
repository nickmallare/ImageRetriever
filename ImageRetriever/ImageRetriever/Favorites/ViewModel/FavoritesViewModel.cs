using ImageRetriever.Common;
using ImageRetriever.Common.Models;
using System.Collections.ObjectModel;

namespace ImageRetriever.Favorites.ViewModel
{
    public class FavoritesViewModel : BaseVM
    {
        
        public FavoritesViewModel()
        {
         
        }
        private bool isBusy;
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
        public ObservableCollection<AssetRecord> FavoritesList
        {
            get
            {
                return AssetCollection.ListOfFavorites;
            }
            set
            {
                AssetCollection.ListOfFavorites = value;
                RaisePropertyChanged(nameof(FavoritesList));
            }
        }
    }
}
