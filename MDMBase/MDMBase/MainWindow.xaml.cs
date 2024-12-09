using MDMBase.ViewModel.MainView;
using System.Windows;

namespace MDMBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = DataContext as MainViewModel;

            if(viewModel != null)
            {
                viewModel.OnMinimizeRequested += OnMinimizerequested;
            }


        }

        private void OnMinimizerequested()
        {
            Console.WriteLine("이벤트 동작");
            //this.Hide();
        }
    
    }
}