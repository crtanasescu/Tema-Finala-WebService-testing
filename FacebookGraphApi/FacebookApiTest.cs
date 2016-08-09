using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGraphApi
{
    [TestFixture]
    public class FacebookApiTest
    {

        private FacebookGraphApi _fbGraphApi;

        [SetUp]
        public void SetUp()
        {
            //parametrul trebuie schimbat cu un access token generat cu https://developers.facebook.com/tools/explorer
            _fbGraphApi = new FacebookGraphApi("EAACEdEose0cBAPI5BjSgI1psFbZBTHi9oEWGZBKb38KuI77k4kNR3ZCztXBZCKd1Nk6vKcSeEan7SrewxXDCaMnXMdQ6oalwKdzPZCOkdNn8QL9ZAwE2KVijVPsKqZAmiREaLgXwEuZBFPd04v6gwpad9pewydlwIt32qyF0HGlAURR1tomeZBS0t");

        }


        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestApi()
        {

          
            
            Trace.WriteLine("1.Detalii personale---------------------");
            Trace.WriteLine(_fbGraphApi.GetMyDetails());
            var test = _fbGraphApi.GetMyDetails();
            Assert.IsTrue(_fbGraphApi.GetMyDetails().Contains("Tanasescu"));
          

            Trace.WriteLine("2.Prieteni---------------------");
            Trace.WriteLine(_fbGraphApi.GetFriends());


            //verificare prietenie dupa un id primit in functia anterioara
            Trace.WriteLine("3.Verificare prietenie---------------------");
            Trace.WriteLine(_fbGraphApi.CheckFriendship("523450737766772"));
            Assert.IsTrue(_fbGraphApi.GetFriends().Contains("\"total_count\":2"));


            Trace.WriteLine("4.Pozele mele---------------------");
            Trace.WriteLine(_fbGraphApi.GetPhotos());


            Trace.WriteLine("5.Adaugare comentariu la una din pozele de mai sus---------------------");
            _fbGraphApi.CommentPhoto("119644731813680", "test");



            Trace.WriteLine("6.News Feed-uri ---------------------------");
            Trace.WriteLine(_fbGraphApi.GetFeed());
            Assert.IsTrue(_fbGraphApi.GetFeed().Contains("Facebook is cool!"));




            // Trace.WriteLine(fbGraphApi.GetFriends());

        }
    }
}
