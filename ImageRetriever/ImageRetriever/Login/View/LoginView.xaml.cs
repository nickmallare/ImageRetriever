using ImageRetriever.Login.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageRetriever.Login.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            MessagingCenter.Subscribe<LoginViewModel>(this, "TenantError", async (sender) =>
            {
                var result = await DisplayAlert("Alert", "Invalid Tenant or URL", "Ok", "Go to settings");
                if (result == false)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Settings.View.SettingsView());
                }
            });
           
        }
    }
}