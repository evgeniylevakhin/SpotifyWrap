using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyWrap.Abstracts;
using SpotifyWrap.Interfaces;

namespace SpotifyWrap.Requests
{
    public class SpotifyPlaylistTracksRequest : ASpotifyRequest, ISpotifyRequest
    {
        private string ENDPOINT = "/v1/users/{user_id}/playlists/{playlist_id}/tracks";
        public string Endpoint
        {
            get
            {
                string EndpointReturn = ENDPOINT;
                if (!string.IsNullOrEmpty(this.User_ID))
                    EndpointReturn = EndpointReturn.Replace("{user_id}", this.User_ID);
                if (!string.IsNullOrEmpty(this.Playlist_ID))
                    EndpointReturn = EndpointReturn.Replace("{playlist_id}", this.Playlist_ID);
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
