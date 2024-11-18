namespace MauiDemo.Views
{
    public partial class LoginView : ContentPage
    {
        private List<string> images = new List<string>
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        private int currentIndex = 0;
        private System.Timers.Timer? timer;

        public LoginView()
        {
            InitializeComponent();
            StartImageRotation();
        }

        private void StartImageRotation()
        {
            // Thi?t l?p ?nh ban ??u
            imageView.Source = images[currentIndex];

            // T?o m?t b? h?n gi? ?? thay ??i ?nh m?i 2 giây (2000 ms)
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // Thay ??i hình ?nh
            currentIndex = (currentIndex + 1) % images.Count;

            // C?p nh?t giao di?n trong MainThread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                imageView.Source = images[currentIndex];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            timer?.Dispose(); // Ng?ng b? h?n gi? khi không còn c?n thi?t
        }
    }
}
