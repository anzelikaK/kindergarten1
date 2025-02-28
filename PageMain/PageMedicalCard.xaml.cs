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
    /// Логика взаимодействия для PageMedicalCard.xaml
    /// </summary>
    public partial class PageMedicalCard : Page
    {
        public PageMedicalCard()
        {
            InitializeComponent();
            DtGridMedicalCard.ItemsSource = kindergartenEntities.GetContext().MedicalCard.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            {
                // Проверяем, выбран ли элемент в DataGrid
                if (DtGridMedicalCard.SelectedItem == null)
                {
                    MessageBox.Show("Выберите медицискую карту для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Запрашиваем подтверждение
                var result = MessageBox.Show("Удалить выбраную медицинскую карту?", "Подтверждение",
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;

                try
                {
                    // Получаем выбранный объект Child
                    MedicalCard selectedMedicalCard = DtGridMedicalCard.SelectedItem as MedicalCard;

                    // Удаляем из базы данных
                    kindergartenEntities.GetContext().MedicalCard.Remove(selectedMedicalCard);
                    kindergartenEntities.GetContext().SaveChanges();

                    // Обновляем DataGrid
                    DtGridMedicalCard.ItemsSource = kindergartenEntities.GetContext().MedicalCard.ToList();
                    MessageBox.Show("Медицинская карта удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageAddMedicalCard());
        }
    }
}
