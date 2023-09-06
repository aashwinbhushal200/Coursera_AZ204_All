using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;
using System.Threading;
using System;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Timers;

public static class TimerOrchestrator
{
    //The following example illustrates how to use durable timers for delay,
    ///which sends a reminder every day for 10 days
    [FunctionName("MyOrchestrator")]
    public static async Task RunOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        for (int i = 0; i < 10; i++)
        {
            DateTime deadline = context.CurrentUtcDateTime.AddDays(i);
            //The createTimer() method is used to create a timer that expires at
            //the deadline specified by the moment object
            await context.CreateTimer(deadline, CancellationToken.None);
            await context.CallActivityAsync("SendReminder", null);
        }
    }
}