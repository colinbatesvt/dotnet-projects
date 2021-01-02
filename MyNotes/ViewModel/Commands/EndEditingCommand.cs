using MyNotes.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MyNotes.ViewModel.Commands
{
    public class EndEditingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NotesVM vm { get; set; }

        public EndEditingCommand(NotesVM vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            if(notebook != null)
                vm.StopEditing(notebook);
        }
    }
}
