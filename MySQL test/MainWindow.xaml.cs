using Microsoft.EntityFrameworkCore;
using MySQL_test.Data;
using MySQL_test.Data.Interfaces;
using MySQL_test.Data.Repositories;
using MySQL_test.Models;
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
        private readonly ICompanyRepository _companyRepository;

        private BindingList<Company> Companies = new();

        public MainWindow()
        {
            _companyRepository = new CompanyRepository();

            InitializeComponent();

            Load();
        }

        private async void Load()
        {
            Companies.Clear();

            var companies = await _companyRepository.GetAll();

            foreach (var company in companies)
            {
                Companies.Add(company);
            }

            companiesGrid.ItemsSource = Companies;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (companiesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < companiesGrid.SelectedItems.Count; i++)
                {
                    Company company = companiesGrid.SelectedItems[i] as Company;
                    if (company != null)
                    {
                        _companyRepository.Delete(company);

                        Companies.Remove(company);
                    }
                }
            }
        }
    }
}
