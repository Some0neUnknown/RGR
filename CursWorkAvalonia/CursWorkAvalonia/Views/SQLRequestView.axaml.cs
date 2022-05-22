using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CursWorkAvalonia.Views
{
    public partial class SQLRequestView : UserControl
    {
        public SQLRequestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
