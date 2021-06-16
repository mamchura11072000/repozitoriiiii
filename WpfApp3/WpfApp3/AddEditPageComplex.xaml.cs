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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AddEditPageComplex.xaml
    /// </summary>
    public partial class AddEditPageComplex : Page
    {
        private ResidentialComplex _currentComplex = new ResidentialComplex();
        public AddEditPageComplex()
        {

            InitializeComponent();

            DataContext = _currentComplex;
        }

        private void SaveComplex_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentComplex.Name))
                errors.AppendLine("Введите название комплекса");
            if (_currentComplex.ComplexValueAdded == 0)
                errors.AppendLine("Введите коэффициент добавочной стоимостити");
            if (string.IsNullOrWhiteSpace(_currentComplex.Status))
                errors.AppendLine("Введите статус");
            if (_currentComplex.BuildingCost == 0)
                errors.AppendLine("Введите стоимость затрат");
            if (string.IsNullOrWhiteSpace(_currentComplex.City))
                errors.AppendLine("Введите город");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentComplex.ID == 0)
            {
                Database1Entities.GetContext().ResidentialComplexes.Add(_currentComplex);
            }

            try
            {
                Database1Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
