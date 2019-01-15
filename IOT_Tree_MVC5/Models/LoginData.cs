namespace IOT_Tree_MVC5.Models
{
    public class LoginData
    {
        private string server;
        private string port;
        private string username;
        private string password;

        public LoginData(string server, string port, string username, string password)
        {
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
        }

        public string Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}