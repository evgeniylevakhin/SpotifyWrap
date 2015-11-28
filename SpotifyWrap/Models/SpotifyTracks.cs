using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap.Models
{
    [DataContract]
    public class SpotifyTracks
    {
        [DataMember]
        public string HREF { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
}
