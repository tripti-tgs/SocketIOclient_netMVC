using Microsoft.AspNetCore.Mvc; // Importing the ASP.NET Core MVC namespace for controllers and actions
using SocketMVC.Service; // Importing the custom service for Socket.IO communication

namespace SocketMVC.Controllers
{
    // Controller class for handling HTTP requests related to the Home page
    public class HomeController : Controller
    {
        // Private field to store the instance of SocketService, injected via the constructor
        private readonly SocketService _socketService;

        // Constructor for HomeController, accepting a SocketService instance
        // This dependency injection allows the controller to use the SocketService for sending messages
        public HomeController(SocketService socketService)
        {
            _socketService = socketService; // Initialize the _socketService field
        }

        // Action method to handle GET requests to the home page
        public IActionResult Index()
        {
            return View(); // Returns the view associated with the Index action
        }

        // Action method to handle POST requests for sending messages
        // The message parameter is optional and defaults to "true" if not provided
        [HttpPost] // Specifies that this method responds to POST requests
        public async Task<IActionResult> SendMessage(string message = "true")
        {
            // Calls the SendMessageAsync method of SocketService to send the provided message
            // Await is used here because SendMessageAsync is an asynchronous method
            await _socketService.SendMessageAsync(message);

            // Redirects to the "Index" action of the "TestPage" controller after the message is sent
            // This helps in following the Post-Redirect-Get pattern to avoid resubmission of the form
            return RedirectToAction("Index", "TestPage");
        }
    }
}
