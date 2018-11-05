using System;
using NUnit.Framework;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Deloitte
{
    [TestFixture]
    public class MultipleDataOverview : API_Base_Test
    {
        [Test]
        public void TestMethod1()
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Start");
            stopWatch.Start();
            Parallel.For(0, 14, i => DataOverView(i));
            stopWatch.Stop();
            Console.WriteLine("Runtime " + stopWatch.Elapsed);
        }

        async Task DataOverView(int i)
        {
            RestClient restClient = new RestClient(baseUrl + "/gptransactions/v1/overview");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
            Console.WriteLine("Thread is run " + i);

            IRestResponse responce = restClient.Execute(restRequest);
        }
    }
}
