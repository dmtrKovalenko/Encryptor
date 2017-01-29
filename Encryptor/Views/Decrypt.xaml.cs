using Encryptor.Models;
using Encryptor.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Encryptor.Views
{
    /// <summary>
    /// Логика взаимодействия для Decrypt.xaml
    /// </summary>
    public partial class Decrypt : UserControl
    {
        #region properties
        private const string defaultInvalidKeyMessage = "Padding is invalid and cannot be removed.";
        private const string customInvalidKeyMessage = "Invalid Encryption Key.";

        public static readonly DependencyProperty DecryptedTextProperty =
            DependencyProperty.Register("DecryptedText", typeof(string), typeof(Decrypt), new PropertyMetadata(null));
        public static readonly DependencyProperty InitialEncryptedTextProperty =
            DependencyProperty.Register("InitialEncryptedText", typeof(string), typeof(Decrypt), new PropertyMetadata(null));
        public static readonly DependencyProperty DecryptedKeyProperty =
            DependencyProperty.Register("DecryptionKey", typeof(string), typeof(Decrypt), new PropertyMetadata(null));
        public string DecryptedText
        {
            get { return (string)GetValue(DecryptedTextProperty); }
            set { SetValue(DecryptedTextProperty, value); }
        }

        public string DecryptionKey
        {
            get { return (string)GetValue(DecryptedKeyProperty); }
            set { SetValue(DecryptedKeyProperty, value); }
        }

        public string InitialEncryptedText
        {
            get { return (string)GetValue(InitialEncryptedTextProperty); }
            set { SetValue(InitialEncryptedTextProperty, value); }
        }
        #endregion

        #region constructors
        public Decrypt()
        {
            InitializeComponent();
        }
        #endregion

        private async void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            //little hack - set invariant culture to current thread to get exception messages on English
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            if (IsValid(this.EncryptedTextObj))
            {
                try
                {
                    this.DecryptedText = EncryptionService.Decrypt(this.InitialEncryptedText, this.DecryptionKey);
                    this.DecryptTransitioner.SelectedIndex = 1;
                }
                catch (CryptographicException ex)
                {
                    //replace default message to more user-friendly version
                    var message = ex.Message.Replace(defaultInvalidKeyMessage, customInvalidKeyMessage);

                    var view = new ErrorDialog
                    {
                        DataContext = new ErrorDialogViewModel() { ErrorMessage = message }
                    };

                    //show the dialog
                    var result = await DialogHost.Show(view, "RootDialog");
                }
            }
        }

        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
                LogicalTreeHelper.GetChildren(obj)
                    .OfType<DependencyObject>()
                    .All(IsValid);
        }

        private void Copy_to_clipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.DecryptedText);
        }
    }
}
