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
    /// Логика взаимодействия для PageChild.xaml
    /// </summary>
    public partial class PageChild : Page
    {
        public PageChild()
        {
            InitializeComponent();
            DtGridChild.ItemsSource = kindergartenEntities.GetContext().Child.ToList();
            AppFrame.FrameMain.Navigated += FrameMain_Navigated;
        }
        private void FrameMain_Navigated(object sender, NavigationEventArgs e)
        {
            DtGridChild.ItemsSource = kindergartenEntities.GetContext().Child.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageEditChild(null));

        }

        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            {
                // Проверяем, выбран ли элемент в DataGrid
                if (DtGridChild.SelectedItem == null)
                {
                    MessageBox.Show("Выберите ребенка для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Запрашиваем подтверждение
                var result = MessageBox.Show("Удалить выбранного ребенка?", "Подтверждение",
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;

                try
                {
                    // Получаем выбранный объект Child
                    Child selectedChild = DtGridChild.SelectedItem as Child;

                    // Удаляем из базы данных
                    kindergartenEntities.GetContext().Child.Remove(selectedChild);
                    kindergartenEntities.GetContext().SaveChanges();

                    // Обновляем DataGrid
                    DtGridChild.ItemsSource = kindergartenEntities.GetContext().Child.ToList();
                    MessageBox.Show("Ребенок удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageAddChild());
        }

        private void BtnCard_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageMedicalCard());
        }

      

       
    }
}
