using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remeberme.Commands
{
    public class DelegateNewContactCommand : ICommand
    {
        private SimpleEventHandler handler;
        private bool isEnable = true;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();

        public DelegateNewContactCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public bool IsEnable { get { return this.isEnable; } }

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
