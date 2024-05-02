namespace CollectionTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);
            // Set the App window to a sensible (phone like) size during initialization
            if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
            {
                window.Height = 400;
                window.Width = 600;
                window.X = 100;
                window.Y = 100;
            }
            return window;
        }
    }
}
