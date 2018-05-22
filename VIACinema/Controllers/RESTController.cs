using CinemaData;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;


namespace VIACinema.Controllers
{
    [Route("Movie")]
    public class RESTController:Controller
    {

        private IMovie _movies;
        public RESTController(IMovie movies)
        {
            _movies = movies;
        }

        [HttpGet]
        public string Get()
        {
            string json = "";
            var Movies = _movies.GetAll();
            foreach(var Movie in Movies)
            {
                json+=ObjectToJson(Movie);
            }
            return json;
        }

        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        
    }
}
