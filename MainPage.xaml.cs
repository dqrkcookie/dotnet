namespace Pawfect_Care
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddPetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPetPage());
        }
    }

}
