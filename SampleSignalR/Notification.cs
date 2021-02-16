using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleSignalR
{
    public class Notification : Hub
    {

        //public override Task OnConnectedAsync()
        //{
        //    public static HashSet<string> ConnectedIds = new HashSet<string>();
        //Context.ConnectionId;
        //    //UsersConnections.ConnectedIds.Add(Context.ConnectionId);
        //    base.OnConnectedAsync();
        //}
        //Remove login user connectionId in notification hub cache
        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    //iLogger.LogInformation(string.Format("User {0} disconnected from hub..!!", Context.ConnectionId));
        //    //UsersConnections.ConnectedIds.Remove(Context.ConnectionId);
        //    //UsersConnections.UsersList.Remove(UsersConnections.UsersList.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault());
        //    return base.OnDisconnectedAsync(exception);
        //}
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
