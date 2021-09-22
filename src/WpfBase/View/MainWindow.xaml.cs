using System.Windows;
using WpfBase.ViewModels;

namespace WpfBase.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        private void PointCreation_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.CreatePortals();
            _viewModel.Update();
        }
    }
}
