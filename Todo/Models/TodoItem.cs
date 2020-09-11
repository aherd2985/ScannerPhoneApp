using SQLite;

namespace Todo
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Sync { get; set; }
    public string Type { get; set; }
  }
}

