namespace SocketMVC.Service
{
    // Service class responsible for handling Socket.IO client operations
    public class SocketService
    {
        // Private field to store the SocketIOClient.SocketIO instance for communication
        private readonly SocketIOClient.SocketIO _socket;

        // Public property to store and retrieve the list of received messages
        public List<string> Messages { get; private set; }

        // Constructor for SocketService
        // Initializes the list of messages and sets up the Socket.IO client
        public SocketService()
        {
            // Initialize the Messages list to store incoming messages
            Messages = new List<string>();

            // Create a new Socket.IO client instance and connect to the specified server URL
            _socket = new SocketIOClient.SocketIO("http://localhost:4000");

            // Event handler for when the client successfully connects to the Socket.IO server
            _socket.OnConnected += (sender, e) =>
            {
                // Log a message to the console indicating successful connection
                Console.WriteLine("Connected to Socket.IO server.");
            };

            // Event handler for when a message event is received from the server
            _socket.On("message", response =>
            {
                // Extract the message from the response object
                string message = response.GetValue<string>();
                // Call the OnMessageReceived method to handle the received message
                OnMessageReceived(message);
            });

            // Event handler for when the client disconnects from the Socket.IO server
            _socket.OnDisconnected += (sender, e) =>
            {
                // Log a message to the console indicating disconnection
                Console.WriteLine("Disconnected from Socket.IO server.");
            };

            // Initiate the connection to the Socket.IO server asynchronously
            ConnectAsync();
        }

        // Asynchronous method to connect to the Socket.IO server
        private async Task ConnectAsync()
        {
            // Connect to the server asynchronously
            await _socket.ConnectAsync();
        }

        // Asynchronous method to send a message to the Socket.IO server
        public async Task SendMessageAsync(string message)
        {
            // Emit a message event to the server with the specified message
            await _socket.EmitAsync("message", message);
        }

        // Method to handle received messages
        private void OnMessageReceived(string message)
        {
            // Add the received message to the Messages list
            Messages.Add(message);
        }
    }
}
