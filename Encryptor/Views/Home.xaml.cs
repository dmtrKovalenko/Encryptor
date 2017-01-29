using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Encryptor.Views
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/dmtrKovalenko");
        }

        private void TwitterButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/elf_fenris_hate_mages");
        }

        private void ChatButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/elf_fenris_hate_mages");
        }

        private void EmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto://dmtr.kovalenko@outlook.net");
        }

        private void RepoButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/dmtrKovalenko/Encryptor");
        }

        private void DonateButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Lol, really?
            //Process.Start("https://pledgie.com/campaigns/31029");
        }
    }
}
