using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib
{
    class SelectRandomMethodology : API_Base_Test
    {
        public void GetRandomMethodologyID()
        {

            RestClient restClient = new RestClient(baseUrl + "/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<ResponseBodyGetAllMeth>(responce);

            //Add IDs of all methodologies to list

            List<Datum> allMeth = new List<Datum>();
            List<string> all_IDs = new List<string>();

            allMeth = JSONObj.data;

            foreach (var item in allMeth)
            {
                all_IDs.Add(item.meth_id);
            }

            //Select random element from list

            int r = RandomGenerator.GetRandomNumber(all_IDs.Count());

        }
    }
}
