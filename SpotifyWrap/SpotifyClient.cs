using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyWrap.Requests;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using SpotifyWrap.Interfaces;
using SpotifyWrap.Abstracts;
using System.IO;

namespace SpotifyWrap
{
    public class SpotifyClient : IDisposable
    {
        private const string BaseAddress = "https://api.spotify.com";
        private SpotifyAccessCredentials Credentials;

        int connects = 0;

        public bool Connected
        {
            get; private set;
        }

        private SpotifyUser User;

        public SpotifyClient(SpotifyAccessCredentials creds)
        {
            Credentials = creds;
            User = GET<SpotifyUser>(new SpotifyUserRequest());
            if (!String.IsNullOrEmpty(User.Error))
                Console.WriteLine("We have some errors");
            else
                Connected = true;
        }


        
        /// <summary>
        /// Method call for a GET Request
        /// </summary>
        /// <param name="EndPoint">In the form of /v1/artist</param>
        /// <param name="Query">In the form of ?key=value</param>
        public T GET<T>(ISpotifyRequest Request)
        {
            T ReturnResult = default(T);
            string Endpoint = UpdateEndpoint(Request.Endpoint + Request.Query);
            //Sending the HttpRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseAddress + Endpoint);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + Credentials.Access_Token);
            HttpWebResponse response = null;

            //Processing the response
            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        string JSonString = sr.ReadToEnd();
                        ReturnResult = JsonConvert.DeserializeObject<T>(JSonString);
                    }
                }
            }
            catch(WebException E)
            {
                using (WebResponse error = E.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)error;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        //If unauthorised - refresh once and continue.
                        connects += 1;
                        if (connects == 1)
                        {
                            Credentials = SpotifyAuthoriser.Refresh(Credentials);
                            return GET<T>(Request);
                        }
                    }
                }
            }

            return ReturnResult;
        }

        public void POST()
        {

        }

        public void PUT()
        {

        }

        public void DELETE()
        {

        }

        public void Dispose()
        {

        }

        private string UpdateEndpoint(string endpoint)
        {
            string returnEndpoint = endpoint;
            //UpdateEnpoint with user credentials
            if(User!=null)
            {
                if (!string.IsNullOrEmpty(this.User.ID))
                    returnEndpoint = endpoint.Replace("{user_id}", this.User.ID);
            }
            return returnEndpoint;
        }
    }
}
