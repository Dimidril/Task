using MDL_Test_task.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace MDL_Test_task;

public sealed class ApplicationContext: DbContext
{
    /// <summary>
    /// Представление таблицы Mails из БД
    /// </summary>
    public DbSet<DbMail> Mails { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=mails;Uid=root", 
            ServerVersion.Create(new Version(10, 10, 7), ServerType.MariaDb));
    }
}