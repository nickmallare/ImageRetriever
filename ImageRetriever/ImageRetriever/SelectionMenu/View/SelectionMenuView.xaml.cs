using ImageRetriever.Favorites.View;
using ImageRetriever.ImageLookUp.View;
using ImageRetriever.ItemSearch.View;
using ImageRetriever.SelectionMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageRetriever.SelectionMenu.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionMenuView : TabbedPage
    {
        public SelectionMenuView()
        {
            try
            {
                //InitializeComponent();
                NavigationPage navigationPageItemSearch = new NavigationPage(new ItemSearchView());
                navigationPageItemSearch.IconImageSource = "filter.png";

                NavigationPage navigationPageImageLookUp = new NavigationPage(new ImageLookUpView("default"));
                navigationPageImageLookUp.IconImageSource = "explore.png";

                NavigationPage navigationPageFavorites = new NavigationPage(new FavoritesView());
                navigationPageFavorites.IconImageSource = "filledHeart.png";

                Children.Add(navigationPageItemSearch);
                Children.Add(navigationPageFavorites);
                Children.Add(navigationPageImageLookUp);
                var test = CurrentPage;
            }
            catch(Exception ex)
            {

            }

           
        }

        public void GetDetailedInformation()
        {
            CurrentPage = Children[2];
        }
    }
}