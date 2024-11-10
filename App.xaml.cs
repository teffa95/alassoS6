namespace alassoS6
{
    partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.vEstudiante());
        }
    }
}
