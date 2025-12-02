using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF227_Demo.Models
{
    public class Doctor
    {
        // Первичный ключ таблицы Doctors. EF автоматически определяет свойство формата:
        //   - Id
        //   - ClassNameId (в нашем случае DoctorId)
        // как первичный ключ (Primary Key). Значение int будет автоинкрементироваться.
        public int DoctorId { get; set; }

        // Имя врача. Атрибут [Required] делает поле обязательным (NOT NULL в БД).
        // [MaxLength(33)] — ограничивает максимальную длину строки до 33 символов.
        // Это работает как на уровне модели EF, так и на уровне структуры таблицы,
        // где создаётся VARCHAR(33) или NVARCHAR(33) в зависимости от провайдера.
        public string Name { get; set; }

        // Специальность врача (например, "Хирург", "Терапевт", "Офтальмолог").
        // Ограничение длины — максимум 50 символов.
        // Поле необязательно, потому что нет [Required].
        public string Spec { get; set; }

        // Телефон. Поле необязательное (string?).
        // MaxLength(20) предотвращает хранение слишком длинных номеров.
        public string? Phone { get; set; }

        // Категория врача (например, "Высшая", "Первая", "Вторая").
        // Нет атрибутов, значит поле необязательное и длина не ограничена.
        // EF создаст колонку типа string без ограничений (обычно NVARCHAR(MAX)).
        public string Category { get; set; }

        // Навигационное свойство, описывающее отношение один-ко-многим (Doctor -> Priem).
        // ICollection<Priem> говорит EF, что у врача может быть много приёмов.
        // При генерации БД EF создаст внешний ключ в таблице Priems, например DoctorId.
        // Это позволяет легко загружать список приёмов врача с помощью Include.
        public ICollection<Priem> Priems { get; set; }
    }
}
