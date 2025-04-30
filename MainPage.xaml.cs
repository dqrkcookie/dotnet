namespace Pawfect_Care
{
    public partial class MainPage : ContentPage
    {
        private readonly local_db_service db_service;

        public MainPage()
        {
            InitializeComponent();
            db_service = new local_db_service();
        }

        private async void AddPetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPetPage(db_service));
        }
    }

}
