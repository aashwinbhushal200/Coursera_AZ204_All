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
using System.Net.Http;
using crypto; 


namespace GithubWebHook1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(HttpRequestMessage req, ILogger log)
        {
            const Crypto = require('crypto');
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.RequestUri.ParseQueryString()["name"];
            string responseMessage = !string.IsNullOrEmpty(name)
                ? $"Hello, {name}. This HTTP triggered function executed successfully."
                : "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";

            JObject body = JObject.Parse(await req.Content.ReadAsStringAsync());
            if (body["pages"][0]["title"] != null)
            {
                return new OkObjectResult($"Page is {body["pages"][0]["title"]}, Action is {body["pages"][0]["action"]}, Event Type is {req.Headers.GetValues("x-github-event")}");
            }
            else
            {
                return new BadRequestObjectResult("Invalid payload for Wiki event");
            }
        }
    }
}
