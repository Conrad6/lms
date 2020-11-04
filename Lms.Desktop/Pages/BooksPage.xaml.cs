using System.Windows;
using System.Windows.Controls;
using Lms.Desktop.ViewModels;

namespace Lms.Desktop.Pages
{
    public partial class BooksPage
    {
        public BooksPageViewModel ViewModel { get; }

        public BooksPage(BooksPageViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Initialize();
        }
    }
}