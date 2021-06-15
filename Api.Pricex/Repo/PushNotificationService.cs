using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace Api.Pricex.Repo
{
    public class PushNotificationServiceRepo : IPushNotificationService
    {
        //private readonly IDbService dbService;
        private readonly string _serverKey;
        private readonly pedb_devContext _dataContext;

        public PushNotificationServiceRepo(IConfiguration configuration, pedb_devContext dataContext)
        {
            _serverKey = configuration.GetSection("FCM:ServerKey").Value;
            _dataContext = dataContext;
        }

        public async Task SendNotificationF(PushNotification notification)
        {
            var topic = "highScores";
            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "score", "850" },
                    { "time", "2:45" },
                },
                Topic = topic,
                Token = "eO7inxaD00garEzPloBEqJ:APA91bHhG29hT0UKswbs8oE6gfwWbriiilf6GrLVY_ZcbZ7KJibFFmYpaibIHIacH0tS6LgfcLL3NQzlqvvlCeyZmXVkjZ8u4wjriq2HkgK3vAvcIoKeb0_oAtFHZpS2a34VCqmqBVVz",
                Notification = new Notification()
                {
                    Title = "$GOOG up 1.43% on the day",
                    Body = "$GOOG gained 11.80 points to close at 835.67, up 1.43% on the day.",
                    ImageUrl = "1.jpg"
                },

            };

            // Send a message to the devices subscribed to the provided topic.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }

        public async Task SendNotification(PushNotification notification, int user_hotel_id, string booking_type)
        {
            try
            {
                dynamic data = "";
                GetUserHotelRepo getUser = new GetUserHotelRepo(_dataContext);

                var user = await getUser.GetUserHotel(user_hotel_id);

                if (user != null)
                {
                    if(booking_type == "accept")
                    {
                        data = new
                        {
                            //to = "e2UjcNiCGETCrpCutiGyFj:APA91bFWAUXY8U08auJeTutJ8MoVeknfRre1_Ia2PBdZEjZOUw244siVFgbxKKiapt6tx3-MEjO0t2-XeHrJU7NYNhvMWtCXtKT32rViRyNd_M5WDdxpH3ki7cZmUbOxbt8hXsEJDXDJ",
                            to = user.FcmToken,

                            notification = new
                            {
                                title = "Test noti pricex - booking",     // Notification title
                                body = "booking",    // Notification body data
                                //link = "คุณมีงานใหม่"   // When click on notification user redirect to this link
                            }
                        };
                    }
                    else if (booking_type == "reject")
                    {
                        data = new
                        {
                            to = user.FcmToken,

                            notification = new
                            {
                                title = "Test noti pricex - reject",     // Notification title
                                body = "reject",    // Notification body data
                                //link = "คุณมีงานใหม่"   // When click on notification user redirect to this link
                            }
                        };

                    }
              
                    var json = JsonConvert.SerializeObject(data);

                    Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                    string SERVER_API_KEY = _serverKey;
                    string SENDER_ID = "359420216137";

                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    WebResponse tResponse = tRequest.GetResponse();

                    dataStream = tResponse.GetResponseStream();

                    StreamReader tReader = new StreamReader(dataStream);

                    String sResponseFromServer = tReader.ReadToEnd();

                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
