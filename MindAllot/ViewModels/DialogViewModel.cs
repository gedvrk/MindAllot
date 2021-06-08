using MindAllot.Commands;
using System.Windows;

namespace MindAllot.ViewModels
{
    public class DialogViewModel : ViewModel
    {
        public RelayCommand AddCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        private bool _dialogResult;

        public bool DialogResult
        {
            get => _dialogResult;
            set
            {
                _dialogResult = value;
                OnPropertyChanged("DialogResult");
            }
        }

        public DialogViewModel()
        {
            AddCommand = new RelayCommand(o => { Add(o); });
            CloseCommand = new RelayCommand(o => { Cancel(o); });
        }

        private void Add(object o)
        {
            Window wnd = o as Window;

            wnd.DialogResult = true;
            wnd.Close();
        }

        private void Cancel(object o)
        {
            Window wnd = o as Window;

            wnd.DialogResult = false;
            wnd.Close();
        }
    }
}
