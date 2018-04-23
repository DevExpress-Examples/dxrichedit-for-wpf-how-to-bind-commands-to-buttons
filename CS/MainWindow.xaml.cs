using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.RichEdit;

namespace RichEditBindCommandsToStandardControlsWpf {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public class CustomRichEditUICommand : ICommand  {
        private static readonly CustomRichEditUICommand myCommand = new CustomRichEditUICommand("MyCommand");
        public static CustomRichEditUICommand MyCommand { get { return myCommand; } }
        private readonly string commandName;

        public CustomRichEditUICommand() { }
        
        protected internal CustomRichEditUICommand(string commandName) {
            this.commandName = commandName;
        }

        #region ICommand Members

        public event System.EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            if (commandName != "MyCommand")
                throw new System.ApplicationException("Unknown command");
            
            MessageBox.Show("Custom command is executed\r\nRichEditControl.Text: "
                + ((RichEditControl)parameter).Text, "MyCommand");
        }

        #endregion
    }
}
