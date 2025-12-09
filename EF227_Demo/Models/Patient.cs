using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    public class Patient
    {
        // Первичный ключ сущности Patient (PK).
        // EF автоматически определит PatientId как главный идентификатор строки.
        // int → обычно автоинкремент в базе (Identity).
        public int PatientId { get; set; }

        // Имя пациента. Ограничение длины — до 33 символов.
        // Поле не отмечено как [Required], но string без ? = EF считает его обязательным.
        // Поэтому колонка в базе будет NOT NULL.
        public string PatientName { get; set; }

        // Дата рождения.
        // Используется современный тип DateOnly (только дата, без времени).
        // EF Core 6+ умеет прекрасно работать с этим типом,
        // и колонка в базе будет типа DATE.
        public DateTime DateOfBirth { get; set; }

        // Телефон пациента. Необязательное поле (string?).
        // MaxLength(20) — ограничивает длину телефонного номера.
        public string? Phone { get; set; }

        // Адрес пациента. Необязательное поле.
        // MaxLength(200) — можно хранить довольно длинный адрес, но в рамках разумного.
        public string? Adress { get; set; }

        // Номер полиса пациента (медицинского страхования).
        // Нет атрибутов → обязательное поле, и длина не ограничивается.
        // EF создаст NVARCHAR(MAX) и NOT NULL.
        public string Polis { get; set; }

        // Навигационное свойство: пациент имеет много приёмов.
        // Это часть отношения один-ко-многим Patient -> Priem.
        // EF создаст внешний ключ в таблице Priems, например PatientId.
        // Через это свойство можно получить все визиты пациента.
        public ICollection<Priem> Priems { get; set; }
    }
}
