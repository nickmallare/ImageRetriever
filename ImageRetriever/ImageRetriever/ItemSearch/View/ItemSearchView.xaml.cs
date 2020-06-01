using ImageRetriever.ItemSearch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageRetriever.ItemSearch.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemSearchView : ContentPage
    {
        public ItemSearchView()
        {
            InitializeComponent();
            this.BindingContext = new ItemSearchViewModel();
            MessagingCenter.Subscribe<ItemSearchViewModel>(this, "NoFoundAssets", (sender) =>
            {
                DisplayAlert("Alert", "No items found", "Ok");
            });
            MessagingCenter.Subscribe<ItemSearchViewModel>(this, "ProcessingComplete", async (sender) =>
            {
                await Navigation.PushAsync(new ItemSearchImagesView());
            });

           
        }
    }
}