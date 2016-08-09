using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGraphApi
{
    public class FacebookGraphApi
    {
        private HttpClient _httpClient;
        private string _baseUrl = "https://graph.facebook.com/v2.7";

        //accesToken
        public FacebookGraphApi(string access_token)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth",access_token);

        }

        //intoarce detaliile userului: nume si id
        public string GetMyDetails()
        {
            return Get(_baseUrl + "/me");
        }

       //verifica daca exista prietenie intre contul curent si contul userului cu id-ul dat
        public string CheckFriendship(string possibleFriendId)
        {
            if (string.IsNullOrEmpty(possibleFriendId))
                return "";
            return Get(_baseUrl + "/me/friends/"+ possibleFriendId);
        }

        //returneaza toti prietenii
        public string GetFriends()
        {
            return Get(_baseUrl + "/me/friends");
        }

        //returneaza lista cu toate pozele uploadate
        public string GetPhotos()
        {
            return Get(_baseUrl + "/me/photos/uploaded");
        }

        //comenteaza poza cu id-ul dat
        public void CommentPhoto(string photoId, string message)
        {
            var objectToPost = new List<KeyValuePair<string, string>>();
            objectToPost.Add(new KeyValuePair<string, string>("message", message));
            Post(_baseUrl + "/" + photoId + "/comments", objectToPost);
        }

        //returneaza newsfeed-urile
        public string GetFeed()
        {
            return Get(_baseUrl + "/me/feed");
        }


        //GET
        private string Get(string url)
        {
            return GetJsonResult(_httpClient.GetAsync(url).Result);
        }

        //POST
        private void Post(string url,IEnumerable<KeyValuePair<string,string>> postObject)
        {
            var result = _httpClient.PostAsync(url, new FormUrlEncodedContent(postObject)).Result;
            var te = GetJsonResult(result);
        }

        private string GetJsonResult(HttpResponseMessage message)
        {
            return message.Content.ReadAsStringAsync().Result;
        }
    }
}
