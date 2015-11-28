using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap.Models
{
    [DataContract]
    public class SpotifyPlaylist
    {
        [DataMember]
        public bool Collaborative { get; set; }
        //[DataMember]
        //public List<string> External_Urls { get; set; }
        [DataMember]
        public string HREF { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public List<SpotifyImage> Images { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public SpotifyUser Owner { get; set; }
        [DataMember]
        public bool Public { get; set; }
        [DataMember]
        public string SnapshotID { get; set; }
        [DataMember]
        public SpotifyTracks Tracks { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string URI { get; set; }
    }
}
