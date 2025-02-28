using kindergarten.ApplicationDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace kindergarten.PageMain
{
    public partial class PageAddChild : Page
    {
        private Child _currentChild = new Child();
        private List<string> Genders = new List<string> { "М", "Ж" };

        public PageAddChild(Child selectedChild)
        {
            InitializeComponent();
            _currentChild = selectedChild; // Используем переданный объект
            DataContext = this;
            LoadComboBoxData();
           
        }
        public PageAddChild()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = Genders;
            _currentChild = new Child();
            DataContext = this;
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            var context = kindergartenEntities.GetContext();
            cmbParent.ItemsSource = context.Parent.ToList();
            cmbGroup.ItemsSource = context.Group.ToList();
            cmbMedicalCard.ItemsSource = context.MedicalCard.ToList();
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageChild());
        }
    }
}