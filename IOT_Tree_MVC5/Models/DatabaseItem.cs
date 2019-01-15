namespace IOT_Tree_MVC5.Models
{
    public class DatabaseItem
    {
        private string databaseName;

        public DatabaseItem(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public string DatabaseName
        {
            get
            {
                return databaseName;
            }

            set
            {
                databaseName = value;
            }
        }
    }
}