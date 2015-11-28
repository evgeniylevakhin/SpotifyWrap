using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap
{
    [DataContract]
    public class SpotifyImage
    {
        [DataMember]
        public int? Height { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public int? Width { get; set; }
    }
}
