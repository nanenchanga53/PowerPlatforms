using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PowerAutomateFunction
{
    public static class AddSample100
    {
        [FunctionName("AddSample100")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP 트리거 실행.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var jarray = new JArray();

            for (int i = 0; i < 100; i++)
            {

                var json = new JObject();
                json.Add("ClientName", "메타넷" + i.ToString());
                json.Add("Pic", "김 우창");
                json.Add("Work", true);
                json.Add("ClientCategory", 601760000);
                json.Add("ClientNum", 1000000 + i);
                json.Add("대표여부", true);
                json.Add("Order", 1);

                jarray.Add(json);

            }


            return new JsonResult(jarray);
        }
    }
}
