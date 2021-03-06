namespace API.Entities
{
    public class Connection
    {
        public Connection()
        {
        }

        public Connection(string connectionId, string username)
        {
            ConnectionId = connectionId;
            Username = username;
        }

        // This is an Entity Framework name convention for primary key
        public string ConnectionId { get; set; }
        public string Username { get; set; }
    }
}