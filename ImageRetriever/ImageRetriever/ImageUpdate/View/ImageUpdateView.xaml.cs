using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using ImageRetriever.Common;
using ImageRetriever.ImageUpdate.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ImageRetriever.ImageUpdate.View
{
    public partial class ImageUpdateView : ContentPage
    {
        public Byte[] imageAsBytes;
        public DataRequest dataRequest = new DataRequest();
        public string pathImage;
        
        public ImageUpdateView(string ID)
        {
            InitializeComponent();
            this.BindingContext = new ImageUpdateViewModel();
            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", "No camera available.", "OK");
                    return;
                }
                try
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {

                        SaveToAlbum = true,
                        CompressionQuality = 75,
                        DefaultCamera = CameraDevice.Rear,
                        AllowCropping = true,
                        //prevents image from rotating 90 degrees in iOS
                        SaveMetaData = false

                    });
                    if (file == null)
                        return;

                    pathImage = file.Path;
                    imageAsBytes = File.ReadAllBytes(file.Path);
                    string imageBase64 = Convert.ToBase64String(imageAsBytes);
                    image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });

                }
                catch (Exception ex) { }
                var test = image.Source;
            };
            savePhoto.Clicked += async (sender, args) =>
            {
                
                //uploading image
                MultipartFormDataContent form = new MultipartFormDataContent();
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://uat.sonaria.com/api/assets/SaveAssetImages/0/" + ID);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionObjects.Token);
                form.Add(new ByteArrayContent(imageAsBytes, 0, imageAsBytes.Length), "newImage", "newImage.jpg");

                var response = await httpClient.PostAsync("https://uat.sonaria.com/api/assets/SaveAssetImages/0/" + ID, form);
                var httpResponse = response.Content.ReadAsStringAsync().Result;

                string[] httpAndImagePath = { httpResponse, pathImage };
                await Application.Current.MainPage.Navigation.PopModalAsync();
                if (pathImage != null) {
                    MessagingCenter.Send(this, "imagePath", httpAndImagePath);
                }


            };




        }

    }
}

    
