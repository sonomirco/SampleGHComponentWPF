using System.Windows;
using WpfBase.ViewModel;

namespace WpfBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FrameViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new FrameViewModel();
            this.DataContext = _viewModel;
        }

        private void PointCreation_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.CreatePortals();
            _viewModel.Update();
        }
    }
}
