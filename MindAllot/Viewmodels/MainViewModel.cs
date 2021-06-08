using MindAllot.Commands;
using MindAllot.Views.Popups;

namespace MindAllot.ViewModels
{
    public class MainViewModel
    {
        public RelayCommand NewIdeaCommand { get; set; }

        public MainViewModel()
        {
            NewIdeaCommand = new RelayCommand(o => { OpenNewIdeaDialog(); });
        }

        private void OpenNewIdeaDialog()
        {
            AddNewTaskDialog dialog = new AddNewTaskDialog();

            _ = dialog.ShowDialog();
        }
    }
}
