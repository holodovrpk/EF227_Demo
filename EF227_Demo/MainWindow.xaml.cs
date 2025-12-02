using EF227_Demo.Models;
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
        // Создаём экземпляр нашего DbContext.
        // Это объект, через который всё приложение получает доступ к базе данных.
        // Пока окно открыто, эта переменная "db" хранит подключение к БД
        // и отслеживает изменения сущностей.
        EF227_DemoContex db = new EF227_DemoContex();

        public MainWindow()
        {
            // Инициализация компонентов интерфейса WPF.
            // Этот метод создаёт графические элементы, описанные в MainWindow.xaml.
            InitializeComponent();

            // Здесь можно будет:
            // - загружать данные из БД и выводить в элементы UI
            // - привязывать списки к DataGrid/ListBox
            // - подписываться на события кнопок и т.д.
            //
            // Пока конструктор пустой, но "db" уже готов к работе.
        }
    }
}
