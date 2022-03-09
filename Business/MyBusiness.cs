using System.Threading;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Business
{
    public class MyBusiness : IMyService
    {
        //public readonly IHubContext<MyHub> _myHub;
        //public MyBusiness(IHubContext<MyHub> myHub)
        //{
        //    _myHub = myHub;
        //}

        //public async Task SendMessage()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(1000);
        //        string message = "Hello !";
        //        await _myHub.Clients.All.SendAsync("ReceiveMessage", message);

        //    }
        //}
    }
}
