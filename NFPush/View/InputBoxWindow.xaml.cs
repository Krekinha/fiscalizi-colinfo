using System.Windows;
using System.Windows.Input;

namespace NFPush.View
{
    public partial class InputBoxWindow
    {
        public InputBoxWindow()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
            /*throw new Exception("");*/
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            e.Handled = true;
            BtnOk.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtValor.Focus();
        }
    }
}
