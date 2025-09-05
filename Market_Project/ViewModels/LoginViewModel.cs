using Market_Project.Services.Interfaces;
using Market_Project.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Market_Project.Views;
using Market_Project.Models;
using Market_Project.Data;

namespace Market_Project.ViewModels
{
    public class LoginViewModel
    {
       // VM data
        public string FormLogin { get; set; }
        public string FormPassword { get; set; }

        // Commands
        public ICommand LoginCheckCommand { get; set; }

        // Services
        private readonly ISecurityDetailService _sds;

        // Events
        public event Action SuccessfulLogin;

        // Constructor
        public LoginViewModel( ISecurityDetailService sds)
        {
            _sds = sds;
            LoginCheckCommand = new RelayCommand(_ => CheckLogin());
#if DEBUG
            //FormLogin = "john_admin";
            //FormPassword = "pass123";
            //CheckLogin();
#endif

        }

        // Functions
        public async void CheckLogin()
        {
            var userSecurityDetail = await _sds.GetSecurityDetail(FormLogin);
            if (userSecurityDetail != null && userSecurityDetail.Password == FormPassword)
            {
                OpenMainWindow();
                UpdateCurrentUser(userSecurityDetail);
            }
            else MessageBox.Show("Invalid login or password"); // temporary
        }

        public void OpenMainWindow()
        {
            var mainWindow = (Window)App.ServiceProvider.GetRequiredService<MainWindow>();
            SuccessfulLogin?.Invoke();
            mainWindow.Show();
        }

        public void UpdateCurrentUser(SecurityDetail sd)
        {
            var user = App.ServiceProvider.GetRequiredService<IActiveUserContext>();
            user.Id = sd.StaffId;

            sd.LastLogin = DateTime.Now;
            _sds.SaveAsync();
        }
    }
}
