namespace TripServiceKata.Entity
{
    public interface IUser
    {
        void AddFriend(IUser user);
        bool IsFriend(IUser loggedUser);
    }
}