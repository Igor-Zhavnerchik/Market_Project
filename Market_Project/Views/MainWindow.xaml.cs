using Market_Project.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market_Project.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainStackPanel.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
            // temp user
            var user = App.ServiceProvider.GetRequiredService<IActiveUserContext>();
            user.Id = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button clickedButton)
            {
                string? pageName = $"Market_Project.Views.{clickedButton.Tag as string}"; // workaround
                var type = Type.GetType(pageName);
                var page = (Page)App.ServiceProvider.GetRequiredService(type);

                MainFrame.Content = page;
            }
            e.Handled = true;
        }
    }
}