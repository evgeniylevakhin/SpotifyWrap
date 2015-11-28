using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyWrap.Interfaces;
using SpotifyWrap.Abstracts;

namespace SpotifyWrap.Requests
{
    public class SpotifyPlaylistsRequest : ASpotifyRequest, ISpotifyRequest
    {
        private string ENDPOINT = "/v1/users/{user_id}/playlists";
        public string Endpoint
        {
            get
            {
                string EndpointReturn = ENDPOINT;
                if (!string.IsNullOrEmpty(this.User_ID))
                    EndpointReturn = EndpointReturn.Replace("{user_id}", this.User_ID);
                return EndpointReturn;
            }
            set { }
        }

        public string Query
        {
            get
            {
                return "";
            }
            set { }
        }
    }
}
