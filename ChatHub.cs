using GenerativeAI.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace signalRxGemini
{
    public class ChatHub : Hub
    {
        public void Send(String name, string message )
        {
            Clients.All.addNewMessageToPage(name, message);
            if(name!= "Bear Bot")
            {
                bearBot(message);
            }
        }

        public async Task bearBot(string message)
        {
            var apiKey = "AIzaSyAtsBMgDdIZim-K4Bp_51SPkN6m61rP0bk";

            var model = new GenerativeModel(apiKey);
          

            var res = await model.GenerateContentAsync(message);

            if(res == null)
            {
                bearBot(message);
            }
            else
            {
                Send("Bear Bot", res.ToString());
            }

            
        }



    }
}