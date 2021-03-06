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
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.Net;

namespace PowerAutomateFunction
{
    public static class AddSample100
    {
        [FunctionName("AddSample100")]
        [OpenApiOperation(operationId: "ReturnSample100", tags: new[] { "apikey" }, Summary = "테스트 데이터 100개", Description = "API 쿼리 key로 인증하고 샘플 데이터 반환(100개)", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response", Summary = "샘플값반환")]

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
                json.Add("ClientName", "WoochangCo" + i.ToString());
                json.Add("Pic", "김 우창");
                json.Add("Work", true);
                json.Add("ClientCategory", 601760000);
                json.Add("ClientNum", 1000000 + i);
                json.Add("대표여부", true);
                json.Add("Order", 1);

                jarray.Add(json);

            }


            return new OkObjectResult(jarray.ToString());
        }
    }
}
