using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap
{
    [DataContract]
    public abstract class SpotifyError
    {
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string Error_Description { get; set; }
    }
}
