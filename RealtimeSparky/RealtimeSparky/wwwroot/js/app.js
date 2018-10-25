(function () {
    var userInput = document.getElementById("content");
    var saveButton = document.getElementById("submitForm");   

    // establish connection with a server and start communicating
    var connection = new signalR.HubConnectionBuilder().withUrl("/sparky").build();

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
        var message = userInput.value;
        connection.invoke("SendMessage", message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });

})();


