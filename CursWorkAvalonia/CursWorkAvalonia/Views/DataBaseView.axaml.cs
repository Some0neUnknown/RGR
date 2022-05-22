using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CursWorkAvalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Avalonia.Interactivity;

namespace CursWorkAvalonia.Views
{
    public partial class DataBaseView : UserControl
    {
        public DataBaseView()
        {
            InitializeComponent();
          
        }
        
        
       
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
