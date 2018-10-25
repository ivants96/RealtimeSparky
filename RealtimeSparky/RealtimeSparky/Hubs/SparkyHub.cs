using Microsoft.AspNetCore.SignalR;
using RealtimeSparky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeSparky.Hubs
{
    public class SparkyHub : Hub
    {
        //Walk up to an instance of SparkyHub in JS and do connection.invoke("SendMessage", message)
        //and then SendMessage method will be invoked and I'll be passed a message from JS
        //Then I can do whatever I need I can  save it to DB... or in this case invoke method (eventHandler) in js called receiveMessage
        //which will display message on user's screen
        //Go to each client that is connected and invoke JS method called receiveMessage
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
