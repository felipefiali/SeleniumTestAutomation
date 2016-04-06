namespace TestRunnerUI
{
    using System.Windows;
    using System.Windows.Input;

    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        public void SetExceptionText(string exceptionText)
        {
            txtException.Text = exceptionText;
        }

        private void txtException_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtException.Text);
        }
    }
}