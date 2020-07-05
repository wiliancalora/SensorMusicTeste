using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using SensorMusic.Domain.DTO;
using SensorMusic.Domain.Entities;
using SensorMusic.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SensorMusic.Domain.Services
{
    public class SpotifyService : ISpotifyService
    {

        private static async Task<SpotifyToken> GetAccessTokenAsync()
        {
            string clientId = "6826049dcba547fc85ab201d2522fd01";
            string clientSecret = "fb3ae11a96cf41888592fe3548ad13de";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
                var response = await request.Content.ReadAsStringAsync();
                var accessToken = JsonConvert.DeserializeObject<SpotifyToken>(response);

                return accessToken;
            }
        }

        public async Task<SpotifyList> GetPlayListAsync(string genre)
        {
            var accessToken = await GetAccessTokenAsync();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);
                var request = await client.GetAsync("https://api.spotify.com/v1/search?q=genre%3A"+ genre + "&type=artist");
                var response = await request.Content.ReadAsStringAsync();
                var playList = JsonConvert.DeserializeObject<SpotifyList>(response);

                return playList;
            }
        }
    }
    
}