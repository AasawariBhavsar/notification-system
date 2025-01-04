using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NotificationSystem.Services;
using NotificationSystem.Models;
using NotificationSystem.Contexts;

namespace NotificationSystem.Function
{
    public static class SendNotification
    {
        [FunctionName("SendNotification")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var notificationService = new NotificationService(log);

            // Read and deserialize the request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<NotificationRequest>(requestBody);

            try
            {
                // Build the notification
                var notification = notificationService.BuildNotification(input);

                // Set delivery method
                var context = new NotificationContext();
                notificationService.GetDeliveryMethod(context, input.DeliveryMethod);

                // Send the notification
                notificationService.Send(context, notification);

                return new OkObjectResult("Notification sent successfully.");
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                log.LogError($"An error occurred: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
