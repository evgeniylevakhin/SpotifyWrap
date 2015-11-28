using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


namespace SpotifyWrap
{
    /// <summary>
    /// Authoriser used to request Refresh and Access tokens
    /// for a particulare user when given a code, this is the second Step with OAuth.
    /// </summary>
    public static class SpotifyAuthoriser
    {
        public static Uri BaseAddress = new Uri("https://accounts.spotify.com");

        public static SpotifyAccessCredentials Authorise(SpotifyApplicationcredentials AppCreds)
        {
            SpotifyAccessCredentials credentials = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", AppCreds.Code),
                    new KeyValuePair<string, string>("redirect_uri", AppCreds.RedirectURL)
                });
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", AppCreds.ClientID, AppCreds.ClientSecret))));
                try
                {
                    var post = client.PostAsync("/api/token", content);
                    post.Wait();
                    HttpResponseMessage response = post.Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonstring = response.Content.ReadAsStringAsync();
                        jsonstring.Wait();
                        string jstring = jsonstring.Result;
                        credentials = JsonConvert.DeserializeObject<SpotifyAccessCredentials>(jstring);                                        
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return credentials;
        }

        public static SpotifyAccessCredentials Refresh(SpotifyAccessCredentials Creds)
        {
            string ClientID = System.Configuration.ConfigurationManager.AppSettings["SpotifyClientID"];
            string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["SpotifyClientSecret"];
            SpotifyAccessCredentials credentials = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", Creds.Refresh_Token)
                });
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", ClientID, ClientSecret))));
                try
                {
                    var post = client.PostAsync("/api/token", content);
                    post.Wait();
                    HttpResponseMessage response = post.Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonstring = response.Content.ReadAsStringAsync();
                        jsonstring.Wait();
                        string jstring = jsonstring.Result;
                        credentials = JsonConvert.DeserializeObject<SpotifyAccessCredentials>(jstring);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return credentials;
        }
    }
}
