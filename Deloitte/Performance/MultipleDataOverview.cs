using System;
using NUnit.Framework;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Deloitte
{
    [TestFixture]
    public class MultipleDataOverview : API_Base_Test
    {
        [Test]
         public async Task Test_DataOverview_14_Requests()
        {
            Stopwatch stopWatch = new Stopwatch();            
            Task[] tasks = new Task[14];
            
            for (int i =0; i < 14; i++)
            {
                tasks[i] = new Task(() => DataOverView(i));
            }

            Console.WriteLine("Start");
            stopWatch.Start();
            foreach (var t in tasks)
            {
                t.Start();
                
            }
            await Task.WhenAll(tasks);
            stopWatch.Stop();

            Console.WriteLine("Runtime Tasks " + stopWatch.Elapsed);
            stopWatch.Reset();
            //stopWatch.Start();
            //Parallel.For(0, 14, i => DataOverView(i));
            //stopWatch.Stop();
            //Console.WriteLine("Runtime Parallel " + stopWatch.Elapsed);
        }

        async Task DataOverView(int i)
        {
            Console.WriteLine("Thread is start " + i);
            RestClient restClient = new RestClient(baseUrl + "/gpdomain/v1/overview");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
            
            IRestResponse responce = restClient.Execute(restRequest);
            Console.WriteLine("Thread is stop " + i);
        }
    }
}
