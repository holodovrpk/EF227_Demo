using EF227_Demo.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EF227_Demo
{
    public partial class MainWindow : Window
    {
        // Создаём экземпляр DbContext — главный объект EF Core.
        // Через него выполняются все операции с таблицами базы:
        //   - загрузка данных
        //   - изменение
        //   - удаление
        //   - сохранение
        //
        // Контекст создаётся один раз на окно, его хватает для работы всего UI.
        EF227_DemoContex db = new EF227_DemoContex();

        // Коллекция пациентов, которая будет привязана к таблице в UI (DataGrid).
        // ObservableCollection — особый тип коллекции, который УМЕЕТ уведомлять интерфейс
        // об изменениях:
        //   - добавление
        //   - удаление
        //   - перестановка
        //
        // Благодаря этому DataGrid автоматически обновляется, когда мы меняем коллекцию.
        ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

        public MainWindow()
        {
            // Стандартная инициализация компонента WPF.
            // Этот вызов загружает разметку XAML, создаёт все элементы окна,
            // присваивает имена элементам, вешает обработчики событий и т.д.
            InitializeComponent();

            // Загружаем таблицу Patients в локальный кэш EF Core.
            // Load() — это метод EF, который выполняет SELECT * FROM Patients
            // и заполняет коллекцию db.Patients.Local объектами пациентов.
            db.Patients.Load();

            // Переносим локальную коллекцию EF Core в ObservableCollection.
            // db.Patients.Local — это специальная коллекция, которая хранит:
            //   - загруженные строки
            //   - новые незаписанные строки
            //   - изменённые строки
            //
            // Но она не является ObservableCollection, поэтому оборачиваем её.
            patients = db.Patients.Local.ToObservableCollection();

            // Привязываем коллекцию пациентов к DataGrid в интерфейсе.
            // Теперь DataGrid будет показывать содержимое patients.
            // Любые изменения списка (удаление/добавление) сразу попадут в UI.
            PatTable.ItemsSource = patients;
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик кнопки "Сохранить".
            // SaveChanges() — главный метод EF, который:
            //   - находит все изменённые сущности
            //   - формирует SQL-команды UPDATE/INSERT/DELETE
            //   - отправляет их в базу данных
            //
            // Таким образом сохраняются все изменения, сделанные пользователем в DataGrid.
            db.SaveChanges();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем: выбран ли элемент в таблице?
            // PatTable.SelectedItem — элемент, на который сейчас кликает пользователь.
            // "is Patient p" — паттерн-матчинг, который одновременно:
            //   1) проверяет тип
            //   2) сохраняет в переменную p
            if (PatTable.SelectedItem is Patient p)
            {
                // Удаляем пациента из локальной коллекции.
                // ObservableCollection → удаление сразу видно в интерфейсе.
                patients.Remove(p);

                // Теперь фиксируем изменения в базе данных.
                // EF понимает, что сущность p была удалена из Local,
                // помечает её как "Deleted" и генерирует SQL DELETE.
                db.SaveChanges();
            }
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient p = new Patient();

            AddPatientWindow w = new AddPatientWindow() { DataContext = p};

            if (w.ShowDialog() == true)
            {
                patients.Add(p);
                db.SaveChanges();
            }
        }
    }
}
