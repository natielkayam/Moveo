namespace Moveo.Exceptions
{
    public class UsersNotFoundQueryException : Exception
    {
        public UsersNotFoundQueryException(string query) : base($"No users found matching '{query}'")
        {
        }
    }
}
