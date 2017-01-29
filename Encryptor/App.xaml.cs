using Encryptor.ViewModels;
using Encryptor.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace Encryptor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnExceptionAsync);
        }

        static async void OnExceptionAsync(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            var view = new ErrorDialog
            {
                DataContext = new ErrorDialogViewModel() { ErrorMessage = e.Message }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");
        }
    }
}
