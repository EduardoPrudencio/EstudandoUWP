using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remeberme.Commands
{
    public class DelegateContactsCommand : ICommand
    {

        private SimpleEventHandler handler;
        private bool isEnable = true;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();

        public DelegateContactsCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        private void OnCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }


        public bool CanExecute(object parameter)
        {
            return this.isEnable;
        }

        public void Execute(object parameter)
        {
            this.handler();
        }
    }
}
