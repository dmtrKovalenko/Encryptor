using System.ComponentModel;

namespace Encryptor.ViewModels
{
    public class ErrorDialogViewModel
    {
        public string ErrorMessage { get; set; }

        public bool WillApplicationClose { get; set; }
    }
}
