using System;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Lms.Core;
using Lms.Desktop.Extensions;
using Lms.Services;

namespace Lms.Desktop.ViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        private readonly UserClientService _userClientService;
        private readonly BookClientService _bookClientService;

        private async void Initialize()
        {
            var user = await _userClientService.FindByUsernameAsync(
                AppDomain.CurrentDomain.GetData(AppConstants.AuthenticatedUserUsernameKey) as string);

            var books = await _bookClientService.GetBooksByStockOwnerId(user.Id);
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        protected void OnInitializing() => Initializing.Raise(this);
        protected void OnInitialized() => Initialized.Raise(this);

        public event EventHandler Initializing;
        public event EventHandler Initialized;
        public ObservableCollection<Book> Books { get; }

        public BooksPageViewModel(NavigationService navigationService,
            UserClientService userClientService,
            BookClientService bookClientService) : base(navigationService)
        {
            _userClientService = userClientService;
            _bookClientService = bookClientService;
            Books = new ObservableCollection<Book>();
            OnInitializing();
            Initialize();
            OnInitialized();
        }
    }
}