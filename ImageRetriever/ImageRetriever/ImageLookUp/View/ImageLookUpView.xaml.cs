using ImageRetriever.ImageLookUp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageRetriever.ImageLookUp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageLookUpView : ContentPage
    {
        public ImageLookUpView()
        {
            InitializeComponent();
            this.BindingContext = new ImageLookUpViewModel();
            MessagingCenter.Subscribe<ImageLookUpViewModel>(this, "NoImage", (sender) =>
            {
                DisplayAlert("Alert", "No item found", "OK");
            });
        }
        public ImageLookUpView(string name)
        {
            InitializeComponent();
            if(name == null)
            {
                name = "default";
            }
            this.BindingContext = new ImageLookUpViewModel(name);
            MessagingCenter.Subscribe<ImageLookUpViewModel>(this, "NoImage", (sender) =>
            {
                DisplayAlert("Alert", "No item found", "OK");
            });
        }


    }
}