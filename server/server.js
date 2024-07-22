const express = require('express');
const http = require('http');
const socketIo = require('socket.io');
const cors = require('cors');

const app = express();
const server = http.createServer(app);

// Configure CORS for both Express and Socket.IO
const io = socketIo(server, {
  cors: {
    origin: "*", // Allow all origins
    methods: ["GET", "POST"]
  }
});

// Middleware
app.use(cors()); 
app.use(express.static('public'));

// Socket.IO connection
io.on('connection', (socket) => {
    console.log('New client connected');
  
    socket.on('message', (data) => {
      console.log('Message received:', data);
      io.emit('message', data);
    });
  
    socket.on('disconnect', () => {
      console.log('Client disconnected');
    });
  });

const PORT = process.env.PORT || 4000;
server.listen(PORT, () => console.log(`Server running on port ${PORT}`));