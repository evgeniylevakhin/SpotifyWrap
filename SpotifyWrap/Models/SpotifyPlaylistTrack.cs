using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap.Models
{
    [DataContract]
    public class SpotifyPlaylistTrack
    {
        [DataMember]
        public string Added_at { get; set; }
        [DataMember]
        public SpotifyUser Added_By { get; set; }   
        [DataMember]
        public SpotifyTrack Track { get; set; }

    }
}
