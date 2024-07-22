import React, { useEffect, useState } from "react";
import io from "socket.io-client";
import "./App.css";

const socket = io("http://localhost:4000");

function App() {
  const [messages, setMessages] = useState([]);
  const [message, setMessage] = useState("");

  useEffect(() => {
    socket.on("message", (message) => {
      setMessages((prevMessages) => [...prevMessages, message]);
    },[messages]);

    return () => {
      socket.off("message");
    };
  }, []);

  const sendMessage = () => {
    socket.emit("message", "true");
    setMessage("");
  };

  return (
    <div className="App">
      <h1>React Socket.io </h1>
        {messages == "true" ?(
          <button  onClick={sendMessage}> Stop </button>
        ) : 
        ( <button onClick={sendMessage}> Start </button>)
        }
    
    </div>
  );
}

export default App;
