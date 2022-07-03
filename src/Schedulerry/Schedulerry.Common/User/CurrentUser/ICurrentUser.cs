namespace Schedulerry.Common.User
{
    public interface ICurrentUser
    {
        public UserRole Role { get; }

        public long Id { get; }

        public string Email { get; }

        public string Username { get; }

        public bool IsVerified { get; }
    }
}
