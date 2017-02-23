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
using Microsoft.Win32;

namespace Countdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterInStartup();
            Left = (int)(SystemParameters.PrimaryScreenWidth / 2.65);
            Run();
        }

        private readonly DateTime _final = new DateTime(2017, 5, 18, 23, 59, 59);

        private async void Run()
        {
            if (_final > DateTime.Now)
            {
                var between = _final - DateTime.UtcNow;

                days.Text = between.Days < 10 ? $"0{between.Days}" : $"{between.Days}";
                days.Foreground = between.Days > 0 ? Brushes.LawnGreen : Brushes.Red;

                hours.Text = between.Hours < 10 ? $"0{between.Hours}" : $"{between.Hours}";
                hours.Foreground = between.Days > 0 ? Brushes.White : Brushes.Red;

                mins.Text = between.Minutes < 10 ? $"0{between.Minutes}" : $"{between.Minutes}";
                mins.Foreground = between.Days > 0 ? Brushes.White : Brushes.Red;

                secs.Text = between.Seconds < 10 ? $"0{between.Seconds}" : $"{between.Seconds}";
                secs.Foreground = between.Days > 0 ? Brushes.White : Brushes.Red;

                await Task.Delay(200);
                Run();
            }
            else
            {
                days.Text = "0";
                days.Foreground = Brushes.Red;

                hours.Text = "0";
                hours.Foreground = Brushes.Red;

                mins.Text = "0";
                mins.Foreground = Brushes.Red;

                secs.Text = "0";
                secs.Foreground = Brushes.Red;
            }
        }

        private void RegisterInStartup()
        {
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    registryKey?.SetValue("Countdown", $"\"{AppDomain.CurrentDomain.BaseDirectory}\\Countdown.exe\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
