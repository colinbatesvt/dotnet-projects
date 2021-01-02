using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace MyNotes.ViewModel.Commands
{
    public class EditCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public NotesVM vm { get; set; }

        public EditCommand(NotesVM vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.StartEditing();
        }
    }
}
