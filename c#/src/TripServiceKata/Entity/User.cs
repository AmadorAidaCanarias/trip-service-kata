using System.Collections.Generic;
using System.Linq;

namespace TripServiceKata.Entity
{
    public class User : IUser
    {
        private readonly List<IUser> friends;

        public User()
        {
            friends = new List<IUser>();
        }

        public void AddFriend(IUser user)
        {
            friends.Add(user);
        }

        public bool IsFriend(IUser loggedUser)
        {
            return Enumerable.Contains(friends, loggedUser);
        }
    }
}