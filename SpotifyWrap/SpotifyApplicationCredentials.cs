using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyWrap
{
    public class SpotifyApplicationcredentials
    {
        public string Code { get; set; }
        public string RedirectURL { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
