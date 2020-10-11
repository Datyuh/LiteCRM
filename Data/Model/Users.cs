namespace LiteCRM.Data.Model
{
    public class Users
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string UserRight { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
}
