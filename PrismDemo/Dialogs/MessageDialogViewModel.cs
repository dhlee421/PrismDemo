using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.Dialogs
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "My Message Dialog";
        private string _message;
        
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand CloseDialogCommand { get; }

        public event Action<IDialogResult> RequestClose;

        public MessageDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(CloseDialog);

            Message = Title;
        }


        private void CloseDialog()
        {
            var buttonResult = ButtonResult.OK;
            var parameters = new DialogParameters();

            parameters.Add("myParm", "The Dialog was closed by the user");

            RequestClose?.Invoke(new DialogResult(buttonResult, parameters));
        }


        public bool CanCloseDialog()
        {
            return true;
        }


        public void OnDialogClosed()
        {
            
        }


        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
