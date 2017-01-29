using System;
using System.Windows;
using System.Windows.Controls;

namespace Encryptor.Views
{
    /// <summary>
    /// Логика взаимодействия для Encrypt.xaml
    /// </summary>
    public partial class Encrypt : UserControl
    {
        #region properties

        public static readonly DependencyProperty EncryptedTextProperty;
        public static readonly DependencyProperty InitialTextProperty;
        public static readonly DependencyProperty EncryptionKeyProperty;

        public string EncryptedText
        {
            get { return (string)GetValue(EncryptedTextProperty); }
            set { SetValue(EncryptedTextProperty, value); }
        }

        public string EncryptionKey
        {
            get { return (string)GetValue(EncryptionKeyProperty); }
            set { SetValue(EncryptionKeyProperty, value); }
        }

        public string InitialText
        {
            get { return (string)GetValue(InitialTextProperty); }
            set { SetValue(InitialTextProperty, value); }
        } 
        #endregion

        #region constructors

        static Encrypt()
        {
            EncryptedTextProperty = DependencyProperty.Register("EncryptedText", typeof(string), typeof(Encrypt), new PropertyMetadata(null));
            InitialTextProperty = DependencyProperty.Register("InitialText", typeof(string), typeof(Encrypt), new PropertyMetadata(null));
            EncryptionKeyProperty = DependencyProperty.Register("EncryptionKey", typeof(string), typeof(Encrypt), new PropertyMetadata(null));
        }

        public Encrypt()
        {
            InitializeComponent();
        } 
        #endregion

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.InitialText))
            {
                this.EncryptedText = EncryptionService.Encrypt(this.InitialText, this.EncryptionKey);

                //move to show encrypted string
                Transitioner.SelectedIndex = 1;
            }
        }

        private void Copy_to_clipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.EncryptedText);
        }
    }
}
