using LiteCRM.BaseWork.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace LiteCRM.BaseWork.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Client> Clients { get; set; }


        public ApplicationContext()
        {
            try
            {
                Database.OpenConnection();
                //.EnsureCreated();
            }
            catch (System.Exception)
            {
                Database.CloseConnection();
                MessageBox.Show("База данных не доступна\nПроверте подключение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; user id = root; database = greenworld; password = root; persistsecurityinfo = True;");
        }
    }
}
