using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Data;
using VueChatApp.Features.AccessControl.Models;

namespace VueChatApp.Hubs
{
    [Authorize]
    public class NotificationHub : Hub<INotificationClient>
    {
        private static readonly Dictionary<String, SystemUserViewModel> Users = new Dictionary<String, SystemUserViewModel>();
        private readonly ChatDbContext _chatDbContext;
        public NotificationHub(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }
        public void RegisterUser(SystemUserViewModel OnlineUser)
        {

            NotificationHub.Users.Add(Context.ConnectionId, OnlineUser);
            UpdateUserList();
        }


        public override Task OnConnectedAsync()
        {
            UpdateUserList();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (Users.ContainsKey(Context.ConnectionId))
            {
                Users.Remove(Context.ConnectionId);
                UpdateUserList();
            }
            return base.OnDisconnectedAsync(exception);
        }

        private Task UpdateUserList()
        {
            var usersList=_chatDbContext.Users.Select(x => new
              SystemUserViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
                IsOnline = false,
            }).ToList();
            foreach (var user in usersList) {
                if (Users.Values.Any(x => x.Id == user.Id)){
                    user.IsOnline = true;
                };
            }
            return Clients.All.UpdatedUserList(usersList);
        }
    }
}
