using MauiApp1.Data;
namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public readonly BookService _bookService;

        public MainPage()
        {
            InitializeComponent();
            _bookService = new BookService();
            LoadBooks();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
        }
        private async void LoadBooks()
        {
            var books = await _bookService.GetBooksAsync();
            bookListView.ItemsSource = books; // Gán dữ liệu cho ListView
        }
    }

}
