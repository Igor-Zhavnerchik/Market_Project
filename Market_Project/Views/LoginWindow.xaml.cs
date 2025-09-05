using Market_Project.ViewModels;
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

namespace Market_Project.Views
{
    public partial class LoginWindow : Window
    {
        private LoginViewModel _loginViewModel;
        public LoginWindow( LoginViewModel vm)
        {
            InitializeComponent();

            _loginViewModel = vm;
            this.DataContext = _loginViewModel;

            _loginViewModel.SuccessfulLogin += () => this.Close();

            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter) _loginViewModel.CheckLogin();
            };
               
        }
    }
}
