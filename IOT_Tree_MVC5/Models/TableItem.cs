namespace IOT_Tree_MVC5.Models
{
    public class TableItem
    {
        private string tableName;

        public TableItem(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
            }
        }
    }
}