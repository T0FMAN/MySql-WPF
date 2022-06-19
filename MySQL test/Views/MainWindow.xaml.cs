using Microsoft.EntityFrameworkCore;
using MySQL_test.Data;
using MySQL_test.Data.Interfaces;
using MySQL_test.Data.Repositories;
using MySQL_test.Models;
using MySQL_test.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MySQL_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly User _user;
        readonly ICompanyRepository _companyRepository;
        BindingList<Company> _companies;

        public MainWindow(User user)
        {
            _companyRepository = new CompanyRepository();
            _companies = new BindingList<Company>();
            _user = user;

            InitializeComponent();
            PreSetup();
        }

        void PreSetup()
        {
            mainWindow.Title += $" ({_user.Post.Title} {_user.LastName} {_user.Name})";

            LoadTable();
        }

        async void LoadTable()
        {
            _companies.Clear();
            _companies = await _companyRepository.GetAllAsBindingList();

            companiesGrid.ItemsSource = _companies;
        }

        void updateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTable();
        }

        void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (companiesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < companiesGrid.SelectedItems.Count; i++)
                {
                    var company = companiesGrid.SelectedItems[i] as Company;

                    if (company != null)
                    {
                        _companyRepository.Delete(company);

                        _companies.Remove(company);
                    }
                }
            }
        }

        void addButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddModelWindow(this, ClassType.Company);

            addWindow.Owner = this;
            addWindow.Show();

            IsEnabled = false;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (companiesGrid.SelectedItems.Count == 1)
            {

            }
            else if (companiesGrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Выберите не больше одной позиции");
            }
            else
            {
                MessageBox.Show("Позиция меню не выбрана");
            }
        }
    }
}
