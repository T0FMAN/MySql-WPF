using MySQL_test.Data;
using MySQL_test.Data.Interfaces;
using MySQL_test.Data.Repositories;
using MySQL_test.Models;
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
using System.Windows.Shapes;

namespace MySQL_test.Views
{
    /// <summary>
    /// Interaction logic for AddModelWindow.xaml
    /// </summary>
    public partial class AddModelWindow : Window
    {
        readonly ICompanyRepository _companyRepository;
        readonly ClassType _classType;

        MainWindow _window;

        public AddModelWindow(MainWindow window, ClassType type)
        {
            _companyRepository = new CompanyRepository();
            _classType = type;
            _window = window;

            InitializeComponent();
        }

        private void AddModelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var title = TitleTextBox.Text;
                var country = CountryTextBox.Text;
                var region = RegionTextBox.Text;
                var city = CityTextBox.Text;
                var street = StreetTextBox.Text;

                var company = new Company
                {
                    Title = title,
                    Location = new Location
                    {
                        Country = country,
                        Region = region,
                        City = city,
                        Street = street,
                    }
                };

                var addModel = _companyRepository.Add(company);

                if (addModel)
                {
                    MessageBox.Show("Объект успешно записан в базу данных");

                    _window.IsEnabled = true;

                    _window.Activate();

                    this.Close();
                }
                else MessageBox.Show("Объект не записан в базу данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
