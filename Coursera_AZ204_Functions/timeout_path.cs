using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Collections.Generic;
using System.Threading;
using Coursera_AZ204_Functions;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Reflection;

    public static class MyOrchestrator
    {

        //durable timers for a timeout, which will execute a different path if a timeout occurs 
        [FunctionName("MyOrchestrator")]
        public static async Task<bool> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            DateTime deadline = context.CurrentUtcDateTime.AddSeconds(30);

            Task activityTask = context.CallActivityAsync("GetQuote", null);
            Task timeoutTask = context.CreateTimer(deadline, CancellationToken.None);

            List<Task> tasks = new List<Task> { activityTask, timeoutTask };
            while (tasks.Count > 0)
            {
                Task winner = await Task.WhenAny(tasks);
                if (winner == activityTask)
                {
                    // success case
                    timeoutTask.Dispose();
                    return true;
                }
                else
                {
                    // timeout case
                    return false;
                }
            }
            return false;
        }
    }


/*js format
    const df = require("durable-functions");
const moment = require("moment");

module.exports = df.orchestrator(function * (context) {
    const deadline = moment.utc(context.df.currentUtcDateTime).add(30, "s");
    const activityTask = context.df.callActivity("GetQuote");
    const timeoutTask = context.df.createTimer(deadline.toDate());

    const winner = yield context.df.Task.any([activityTask, timeoutTask]);
    if (winner === activityTask)
    {
        // success case
        timeoutTask.cancel();
        return true;
    }
    else
    {
        // timeout case
        return false;
    }
});*/
