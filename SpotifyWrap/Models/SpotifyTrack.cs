using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap.Models
{
    [DataContract]
    public class SpotifyTrack
    {

        [DataMember]
        public List<string> Available_Markets { get; set; }
        [DataMember]
        public int Disc_Number { get; set; }
        [DataMember]
        public Dictionary<string, string> External_IDs { get; set; }
        [DataMember]
        public Dictionary<string, string> External_URLs { get; set; }
        [DataMember]
        public string HREF { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Popularity { get; set; }
        [DataMember]
        public string Preview_URL { get; set; }
        [DataMember]
        public int Track_Number { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string URI { get; set; }
    }
}
