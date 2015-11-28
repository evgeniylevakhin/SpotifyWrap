using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyWrap
{
    class SpotifyUnauthorisedException : Exception
    {
        public SpotifyUnauthorisedException(string message) : base(message)
        {
        }
    }
}
