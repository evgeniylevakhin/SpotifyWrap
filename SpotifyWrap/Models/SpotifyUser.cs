using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpotifyWrap
{
    [DataContract]
    public class SpotifyUser : SpotifyError
    {
        [DataMember]
        public string Birthdate { get; set; }
        [DataMember]
        public string SE { get; set; }
        [DataMember]
        public string Display_name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Dictionary<string, string> External_URLs { get; set; }
        [DataMember]
        public Followers Followers { get; set; }

        /// <summary>
        /// EndPoint for the User
        /// </summary>
        [DataMember]
        public string HRef { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public List<SpotifyImage> Images { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Spotifies Uniform Resource Identifier for The User
        /// </summary>
        [DataMember]
        public string URI { get; set; }

    }
    [DataContract]
    public class Followers
    {
        [DataMember]
        public string Href { get; set; }
        [DataMember]
        public int Total { get; set; }

    }
}
