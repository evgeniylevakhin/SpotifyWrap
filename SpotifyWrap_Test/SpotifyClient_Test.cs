using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyWrap.Requests;
using SpotifyWrap;
using System.Configuration;
using SpotifyWrap.Abstracts;
using SpotifyWrap.Interfaces;
using SpotifyWrap.Responses;
using SpotifyWrap.Models;
using System.Linq;

namespace SpotifyWrap_Test
{
    [TestClass]
    public class SpotifyClient_Test
    {
        SpotifyAccessCredentials creds = new SpotifyAccessCredentials()
        {
            Access_Token = ConfigurationManager.AppSettings["SpotifyAccessToken"],
            Refresh_Token = ConfigurationManager.AppSettings["SpotifyRefreshToken"],          
            Token_Type = "Bearer"
        };

        [TestMethod]
        public void SpotifyClient_Connect()
        {
            SpotifyClient client = new SpotifyClient(creds);
            Assert.AreEqual(true, client.Connected);
        }

        [TestMethod]
        public void SpotifyClient_GetPlaylists()
        {
            SpotifyClient client = new SpotifyClient(creds);
            SpotifyPlaylistsResponse response = null;
            if(client.Connected)
                response = client.GET<SpotifyPlaylistsResponse>(new SpotifyPlaylistsRequest());

            Assert.AreNotEqual(null, response);
        }

        [TestMethod]
        public void SpotifyClient_GetTracksForPlaylist()
        {
            SpotifyClient client = new SpotifyClient(creds);
            SpotifyPlaylist playlist = null;
            SpotifyPlaylistTracksRequest tracksRequest = null;
            SpotifyPlaylistTracksResponse tracksResponse = null;
            if (client.Connected)
            {
                playlist = client.GET<SpotifyPlaylistsResponse>(new SpotifyPlaylistsRequest()).Items.FirstOrDefault();
                tracksRequest = new SpotifyPlaylistTracksRequest()
                {
                    Playlist_ID = playlist.ID
                };

                tracksResponse = client.GET<SpotifyPlaylistTracksResponse>(tracksRequest);               
                Console.WriteLine("test");          
            }               
        }
    }
}
