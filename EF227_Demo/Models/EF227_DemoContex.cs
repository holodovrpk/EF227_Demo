using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    // Класс контекста — главный объект EF Core, который связывает
    // модели (Doctor, Patient, Priem) и базу данных.
    // Именно через DbContext выполняются запросы, сохранения, миграции и т.д.
    public class EF227_DemoContex : DbContext
    {
        // Набор данных (таблица Doctors).
        // DbSet<Doctor> позволяет выполнять CRUD-операции:
        // Add, Remove, Update, Linq-запросы — всё обращается к таблице Doctor.
        public DbSet<Doctor> Doctors { get; set; }

        // Таблица Patients в БД. Работает так же как выше.
        public DbSet<Patient> Patients { get; set; }

        // Таблица Priems — приёмы пациентов у врачей.
        // Через этот DbSet можно выполнять запросы и сохранять визиты.
        public DbSet<Priem> Priems { get; set; }

        // Метод, который настраивает источник данных (подключение к БД).
        // OnConfiguring вызывается автоматически каждый раз при создании контекста.
        // Здесь выбирается:
        //   - провайдер (UseSqlServer)
        //   - строка подключения (connection string)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к LocalDB (MS SQL Server Express).
            // Сервер: (localdb)\mssqllocaldb
            // Имя базы: BolnichkaBD
            // Trusted_Connection=True — используется Windows-авторизация.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BolnichkaBD;Trusted_Connection=True;");
        }

        // Конструктор контекста.
        public EF227_DemoContex()
        {
            // EnsureCreated():
            //   - Проверяет, существует ли база.
            //   - Если нет — создаёт БЕЗ миграций.
            // Важно: если будешь использовать миграции, эту строку нужно убрать,
            // потому что EnsureCreated и Migrations несовместимы.
            Database.EnsureCreated();
        }
    }
}
