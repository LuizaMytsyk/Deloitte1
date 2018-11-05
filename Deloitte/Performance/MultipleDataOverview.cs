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
         public void Test_DataOverview_14_Requests()
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Start");
            List<Task> tasks = new List<Task>();
            for(int i =0; i < 14; i++)
            {
                Task t = new Task(() => DataOverView(i));
                t.Start();
                tasks.Add(t);
            }
            stopWatch.Start();
            Task.WaitAll(tasks.ToArray());
//           
            stopWatch.Stop();
            Console.WriteLine("Runtime Tasks " + stopWatch.Elapsed);
            stopWatch.Reset();
            //stopWatch.Start();
            //Parallel.For(0, 14, i => DataOverView(i));
            //stopWatch.Stop();
            Console.WriteLine("Runtime Parallel " + stopWatch.Elapsed);
        }

        async Task DataOverView(int i)
        {
            RestClient restClient = new RestClient(baseUrl + "/gpdomain/v1/overview");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
            Console.WriteLine("Thread is run " + i);

            IRestResponse responce = restClient.Execute(restRequest);
        }
    }
}
