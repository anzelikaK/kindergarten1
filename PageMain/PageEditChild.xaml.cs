using kindergarten.ApplicationDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kindergarten.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageEditChild.xaml
    /// </summary>
    public partial class PageEditChild : Page
    {
        private Child _currentChild = new Child();
        public PageEditChild(Child selectedChild)
        {
            InitializeComponent();
            if (selectedChild != null)
                _currentChild = selectedChild;

            DataContext = _currentChild;
            cmbGroup.ItemsSource = kindergartenEntities.GetContext().Group.ToList();
            cmbParent.ItemsSource = kindergartenEntities.GetContext().Parent.ToList();
            cmbMedicalCard.ItemsSource = kindergartenEntities.GetContext().MedicalCard.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentChild.Surname))
                errors.AppendLine("Укажите фамилию ребенка");
            if (string.IsNullOrWhiteSpace(_currentChild.NameChild))
                errors.AppendLine("Укажите имя ребенка");
            if (string.IsNullOrWhiteSpace(_currentChild.Patronymic))
                errors.AppendLine("Укажите отчество ребенка");
            if (_currentChild.DateOfBirth == null)
                errors.AppendLine("Укажите дату рождения ребенка");
            if (string.IsNullOrWhiteSpace(_currentChild.Gender))
                errors.AppendLine("Укажите пол ребенка");
            if (_currentChild.idParent <= 0)
                errors.AppendLine("Выберите родителя");
            if (_currentChild.idGroup <= 0)
                errors.AppendLine("Выберите группу");
            if (_currentChild.idMedicalCard <= 0)
                errors.AppendLine("Выберите медицинскую карту");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentChild.idСhild == 0)
                kindergartenEntities.GetContext().Child.Add(_currentChild);

            try
            {
                kindergartenEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.FrameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
