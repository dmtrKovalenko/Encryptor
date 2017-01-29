using Encryptor.Models;
using Encryptor.Views;
using System.Collections.Generic;

namespace Encryptor.ViewModels
{
    public class MainWindowViewModel
    {
        public List<MenuItem> MenuItems { get; set; }

        public MainWindowViewModel()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Name ="Home", ContentView = new Home() },
                new MenuItem { Name = "Encrypt", ContentView = new Encrypt() },
                new MenuItem { Name = "Decrypt", ContentView = new Decrypt() }
            };
        }
    }
}
