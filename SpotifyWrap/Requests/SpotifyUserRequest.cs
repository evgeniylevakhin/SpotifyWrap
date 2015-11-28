using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyWrap.Interfaces;
using SpotifyWrap.Abstracts;

namespace SpotifyWrap.Requests
{
    public class SpotifyUserRequest : ASpotifyRequest, ISpotifyRequest
    {

        public string Endpoint
        {
            get
            {
                return "/v1/me";
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
