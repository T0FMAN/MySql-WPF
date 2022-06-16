using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WPF_Dem.ekz_test___EF_MySQL.Data;
using WPF_Dem.ekz_test___EF_MySQL.Data.Interfaces;
using WPF_Dem.ekz_test___EF_MySQL.Data.Repositories;
using WPF_Dem.ekz_test___EF_MySQL.Models;

namespace WPF_Dem.ekz_test___EF_MySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ICompanyRepository _companyRepository;

        public MainWindow()
        {
            InitializeComponent();

            Load();
        }

        private async void Load()
        {
            ICompanyRepository companyRepository = new CompanyRepository();

            var companies = await companyRepository.GetAll();


        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
