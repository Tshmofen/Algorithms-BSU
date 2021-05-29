namespace Hashing
{
    public class TableItem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public TableItem(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
