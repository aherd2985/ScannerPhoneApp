using SQLite;

namespace CodeScanner
{
    public class CodeItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Sync { get; set; }
        public string CodeType { get; set; }
  }
}

