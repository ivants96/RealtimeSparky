import {Item} from './Item.js';

(function () {
    const userInput = document.getElementById("content");
    const saveButton = document.getElementById("submitForm");   

    // establish connection with a server and start communicating
    const connection = new signalR.HubConnectionBuilder()
    .withUrl("/sparky")
    .build();

    //Event handler for Clients.All.SendAsync("receiveMessage", message);
    connection.on("receiveMessage", function (message) {              
       userInput.value = message;
       userInput.innerText = message;      
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    saveButton.addEventListener("click", function (event) {
    //Invoke SendMessage method on the server          
        const message = userInput.value;             
        connection.invoke("SendMessage", message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });

       fetch(
    "http://localhost:50295/api/data", {
        method: "GET", 
    })
    .then(res =>
    {
        return res.json();
    })
    .then(item =>
    {        
        userInput.value = item.value;
    })
    .catch(res => {
        console.log(res);
        console.log("Error");
    });

 })();





