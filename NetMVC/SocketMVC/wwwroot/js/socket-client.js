// wwwroot/js/socket-client.js
(function () {
    // Initialize the SocketIO client using the package provided
    var socket = new io.SocketIO("http://localhost:4000");

    socket.on("message", function (message) {
        var messagesDiv = document.getElementById("messages");
        var messageElement = document.createElement("div");
        messageElement.textContent = message;
        messagesDiv.appendChild(messageElement);
    });

    // Handle disconnection and reconnection if necessary
    socket.on("disconnect", function () {
        console.log("Disconnected from Socket.IO server.");
    });
})();
