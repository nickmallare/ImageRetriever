using ImageRetriever.Common;
using ImageRetriever.Common.Models;
using ImageRetriever.Favorites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageRetriever.Favorites.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesView : ContentPage
    {
       
        public FavoritesView()
        {
            InitializeComponent();
            this.BindingContext = new FavoritesViewModel();
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as AssetRecord;
            FavoritesSelection.ChangeFavoritePreferenceFromList(selected);
        }
        private async void DetailedItemSearch(object sender, EventArgs e)
        {
            
            var selected = (AssetRecord)((Button)sender).BindingContext;
            var name = selected.Name;
            await Navigation.PushAsync(new ImageLookUp.View.ImageLookUpView(name));
            
            // MessagingCenter.Send<ItemSearchImagesView>(this, "NavigateDetailedItemSearch");

        }
    }
}