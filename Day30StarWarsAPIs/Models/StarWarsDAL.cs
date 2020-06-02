using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Day30StarWarsAPIs.Models
{
    //DAL is a data access layer, can be used for any data source, but .Net uses it mostly for handling APIs
    public class StarWarsDAL
    {
        private readonly IConfiguration Configuration;
        public StarWarsDAL(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string GetAPIString(string objectType, string objectID = null)
        {
            try
            {
                string url = $"https://swapi.dev/api/{objectType}/";
                if (objectID != null)
                {
                    url += $"{objectID}/";
                }
                HttpWebRequest request = WebRequest.CreateHttp(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader rd = new StreamReader(response.GetResponseStream());
                string output = rd.ReadToEnd();
                return output;
            } catch (Exception)
            {
                return null;
            }
        }
        public Planet GetPlanet(string planetID)
        {
            string planetData = GetAPIString("planets", planetID);
            if (planetData == null) return null;
            JObject json = JObject.Parse(planetData);
            Planet m = JsonConvert.DeserializeObject<Planet>(json.ToString());
            return m;
        }

        public Person GetPerson(string personID)
        {
            string personData = GetAPIString("people", personID);
            if (personData == null) return null;
            JObject json = JObject.Parse(personData);
            Person m = JsonConvert.DeserializeObject<Person>(json.ToString());
            return m;
        }

        public List<Person> GetPeople()
        {
            string personData = GetAPIString("people");
            if (personData == null) return null;

            JObject json = JObject.Parse(personData);
            List<JToken> modelData = json["results"].ToList();
            if (modelData.Count == 0) return null;

            List<Person> pList = new List<Person>();

            foreach (JToken jt in modelData)
            {
                pList.Add(JsonConvert.DeserializeObject<Person>(jt.ToString()));
            }
            return pList;
        }

    }
}
