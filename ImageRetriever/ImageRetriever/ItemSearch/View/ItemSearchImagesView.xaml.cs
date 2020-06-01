using ImageRetriever.ItemSearch.ViewModel;
using ImageRetriever.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Image = ImageRetriever.Common.Models.Image;
using ImageRetriever.Common;
using ImageRetriever.SelectionMenu.View;

namespace ImageRetriever.ItemSearch.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemSearchImagesView : ContentPage
    {
        public ItemSearchImagesView()
        {
            InitializeComponent();
            this.BindingContext = new ItemSearchImagesViewModel();
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