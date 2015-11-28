using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyWrap.Interfaces
{
    public interface ISpotifyRequest
    {
        string Endpoint { get; set; }
        string Query { get; set; }
    }
}
