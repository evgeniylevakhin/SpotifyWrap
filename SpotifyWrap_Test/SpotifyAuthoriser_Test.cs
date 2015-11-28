using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyWrap;
using System.Configuration;

namespace SpotifyWrap_Test
{
    [TestClass]
    public class SpotifyAuthoriser_Test
    {
        SpotifyAccessCredentials creds = new SpotifyAccessCredentials()
        {
            Access_Token = ConfigurationManager.AppSettings["SpotifyAccessToken"],
            Refresh_Token = ConfigurationManager.AppSettings["SpotifyRefreshToken"],
            Token_Type = "Bearer"
        };
        [TestMethod]
        public void RefreshToken_Test()
        {
            SpotifyAccessCredentials refreshedCreds = null;
            refreshedCreds = SpotifyAuthoriser.Refresh(creds);

            Assert.AreNotEqual(refreshedCreds, null);
        }
    }
}
