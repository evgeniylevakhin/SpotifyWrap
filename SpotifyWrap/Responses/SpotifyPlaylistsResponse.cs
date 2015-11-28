using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using SpotifyWrap.Models;

namespace SpotifyWrap.Responses
{
    [DataContract]
    public class SpotifyPlaylistsResponse
    {
        [DataMember]
        public string HREF { get; set; }
        [DataMember]
        public List<SpotifyPlaylist> Items { get; set; }
    }
}
