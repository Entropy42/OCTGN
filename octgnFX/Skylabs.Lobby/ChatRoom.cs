﻿using System.Collections.Generic;
using System.Linq;

namespace Skylabs.Lobby
{
    public class ChatRoom
    {
        private readonly object _userLocker = new object();

        public ChatRoom(long id)
        {
            Id = id;
            Users = new List<User>();
            IsGroupChat = (id == 0);
        }

        public long Id { get; private set; }
        private List<User> Users { get; set; }

        public bool IsGroupChat { get; private set; }

        public int UserCount
        {
            get
            {
                lock (_userLocker)
                    return Users.Count;
            }
        }

        public User[] GetUserList()
        {
            lock (_userLocker)
                return Users.ToArray();
        }

        public void UserStatusChange(User userToChange, UserStatus newUserData)
        {
            lock (_userLocker)
            {
                if (!Users.Contains(userToChange)) return;
                User utochange = Users.FirstOrDefault(us => us.Uid == userToChange.Uid);
                if (utochange == null) return;
                utochange.Status = newUserData;
                utochange.CustomStatus = userToChange.CustomStatus;
            }
        }

        public void ResetUserList(List<User> users)
        {
            lock (_userLocker)
            {
                Users = users;
                if (Users.Count > 2)
                    IsGroupChat = true;
            }
        }

        public void RemoveUser(User user)
        {
            lock (_userLocker)
                Users.Remove(user);
        }
    }
}