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
    public static class AddDataverseItem
    {
        [FunctionName("AddSample")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "apikey" }, Summary = "������Ʈ������ ����", Description = "API ���� key�� �����ϰ� ���� ������ ��ȯ", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP Ʈ���� ����.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var json = new JObject();
            json.Add("ClientName", "WoochangCo3");
            json.Add("Pic", "�� ��â");
            json.Add("Work", true);
            json.Add("ClientCategory", 601760000);
            json.Add("ClientNum", 10000004);
            json.Add("��ǥ����", true);
            json.Add("Order", 4);



            return new JsonResult(json);
        }
    }
}
