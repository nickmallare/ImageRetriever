using ImageRetriever.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ImageRetriever.Common
{
    public class DataRequest
    {
        //HttpConnection httpConnection
        public string url;
        /// <summary>
        /// Attaches headers and token for API request, returns string of the response from the client
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="isAPIRequest"></param>
        /// <param name="typeOfRequest"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public string ConfigureHttpClient(string endPoint, bool isAPIRequest, string typeOfRequest, object json)
        {

            string responseString = "";
            try
            {

                var client = new HttpClient();
                if (SessionObjects.ApiURL != "")
                {

                    var url = SessionObjects.AppURL + endPoint;
                    if (isAPIRequest == true)
                    {
                        url = SessionObjects.ApiURL + endPoint;
                    }
                    client.BaseAddress = new Uri(url);
                    client.Timeout = new TimeSpan(0, 0, 30);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (SessionObjects.Token != "")
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionObjects.Token);
                    }

                    if (typeOfRequest == "POST")
                    {
                        var jsoncont = JsonConvert.SerializeObject(json);
                        var content = new StringContent(jsoncont, Encoding.UTF8, "application/json");

                        var response = client.PostAsync(url, content).Result;
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            responseString = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                    else if (typeOfRequest == "GET" && json == null)
                    {

                        var response = client.GetAsync(url).Result;
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            responseString = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                    else if (typeOfRequest == "GET" && json != null)
                    {
                        url = url + "/" + json;
                        var response = client.GetAsync(url).Result;
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            responseString = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               

            }
            return responseString;
        }
        public void UpdateImagesInBlob(List<ImagesName> listOfImages)
        {
            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 30);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(listOfImages[0].BlobUrl + listOfImages[0].ImageName).Result;
           


        }

    }
}
