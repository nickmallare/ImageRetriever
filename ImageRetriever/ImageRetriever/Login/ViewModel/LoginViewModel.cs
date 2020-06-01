using ImageRetriever.Common;
using ImageRetriever.ImageLookUp.View;
using ImageRetriever.Login.Models;
using ImageRetriever.SelectionMenu.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static ImageRetriever.Login.Models.LoginModel;

namespace ImageRetriever.Login.ViewModel
{


    public class LoginViewModel : BaseVM
    {

        private UserLoginModel UserModel = new UserLoginModel();
        private bool isBusy;
        private bool loginSuccess = false;
        public ICommand LoginCommand { private set; get; }
        public ICommand SettingsCommand { private set; get; }

        public LoginViewModel()
        {

            UserName = "nicholasm@sontosocorp.onmicrosoft.com";
            Password = "Inspiron700m@";


            if (Application.Current.Properties.ContainsKey("BaseUrl"))
            {
                SessionObjects.BaseURL = Application.Current.Properties["BaseUrl"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("Tenant") && !Application.Current.Properties["Tenant"].Equals(null))
            {
                SessionObjects.Tenant = Application.Current.Properties["Tenant"].ToString();
            }


            LoginCommand = new Command(
                     execute: async () =>
                     {
                         IsBusy = true;
                         try
                         {
                                 
                                 await SetUserAuthTokenAsync();
                             if (SessionObjects.Token != "")
                             {
                                 if (loginSuccess)
                                 {
                                     await Application.Current.MainPage.Navigation.PushModalAsync(new SelectionMenuView());
                                 }
                             }
                             else
                             {
                                 MessagingCenter.Send<LoginViewModel>(this, "TenantError");
                             }
                         }
                         catch (Exception ex)
                         {

                         }
                         IsBusy = false;
                     },
                     canExecute: () =>
                     {
                         return true;
                     });
            SettingsCommand = new Command(
                    execute: () =>
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new Settings.View.SettingsView());
                    },
                    canExecute: () =>
                    {
                        return true;
                    });

        }
        public async Task SetUserAuthTokenAsync()
        {
            try
            {
                SessionObjects.Token = await Task.Run(() => base.ConfigureHttpClient("/Login/GenerateToken", false, "POST", UserModel));
                if (SessionObjects.Token != "")
                {
                    UserModel.JWTToken = SessionObjects.Token;
                    loginSuccess = true;
                }
            }
            catch (Exception)
            {
                //TODO handle exception
            }
        }

        public string UserName
        {
            get
            {
                return UserModel.UserName;
            }
            set
            {
                UserModel.UserName = value;
                RaisePropertyChanged("UserName");
            }
        }
        public string Password
        {
            get
            {

                return UserModel.Password;
            }
            set
            {
                this.UserModel.Password = value;
                RaisePropertyChanged("Password");
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