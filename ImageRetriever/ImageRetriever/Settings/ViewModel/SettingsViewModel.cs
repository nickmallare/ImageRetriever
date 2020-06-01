using ImageRetriever.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageRetriever.Settings.ViewModel
{
    public class SettingsViewModel:BaseVM
    {
        public ICommand SaveCommand { private set; get; }
        public SettingsViewModel()
        {


            RaisePropertyChanged(nameof(BaseURL));
            RaisePropertyChanged(nameof(Tenant));

            SaveCommand = new Command(
                   execute: () =>
                   {
                       Application.Current.Properties["BaseUrl"] = BaseURL;
                       Application.Current.Properties["Tenant"] = Tenant;
                       Application.Current.SavePropertiesAsync();
                       Application.Current.MainPage.Navigation.PopAsync();
                   },
                   canExecute: () =>
                   {
                       return true;
                   });
        }


        public string BaseURL
        {
            get { return SessionObjects.BaseURL; }
            set
            {
                SessionObjects.BaseURL = value;
                RaisePropertyChanged(nameof(BaseURL));
            }

        }
    
        public string Tenant
        {
            get { return SessionObjects.Tenant; }
            set
            {
                SessionObjects.Tenant = value;

                RaisePropertyChanged(nameof(Tenant));
            }

        }
    }
}
