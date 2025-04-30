namespace Pawfect_Care
{
    public partial class AddPetPage : ContentPage
    {
        private readonly local_db_service db_service;
        private int edit_customer_id;
        private string selectedImagePath;

        public AddPetPage(local_db_service _db_service)
        {
            InitializeComponent();
            db_service = _db_service;
        }

        private async void OnSelectImageTapped(object sender, EventArgs e)
        {
          
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {

            var pets = new pet_local_db
            {
                pet_name = NameEntry.Text,
                pet_gender = GenderEntry.Text,
                pet_age = AgeEntry.Text,
                pet_breed = BreedEntry.Text
            };

            if (edit_customer_id == 0)
            {
                await db_service.AddPet(pets);
                await DisplayAlert("Pet Added!", $"Name: {pets.pet_name}\nGender: {pets.pet_gender}\nAge: {pets.pet_age}\nBreed: {pets.pet_breed}", "OK");
            }
            else
            {
                pets.pet_id = edit_customer_id;

                await db_service.UpdatePet(pets);
                await DisplayAlert("Pet Updated!", $"Name: {pets.pet_name}\nGender: {pets.pet_gender}\nAge: {pets.pet_age}\nBreed: {pets.pet_breed}", "OK");
            }

            NameEntry.Text = string.Empty;
            GenderEntry.Text = string.Empty;
            AgeEntry.Text = string.Empty;
            BreedEntry.Text = string.Empty;

            await Navigation.PopAsync();
        }
    }
}