namespace Pawfect_Care
{
    public partial class AddPetPage : ContentPage
    {
        private readonly local_db_service db_service;
        private string selectedImagePath;

        public AddPetPage(local_db_service _db_service)
        {
            InitializeComponent();
            db_service = _db_service;
        }

        private async void OnSelectImageTapped(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Pick a photo"
                });

                if (result != null)
                {
                    selectedImagePath = result.FullPath;
                    PetImage.Source = ImageSource.FromFile(selectedImagePath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to select image: " + ex.Message, "OK");
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {

            var pets = new pet_local_db
            {
                pet_name = NameEntry.Text,
                pet_gender = GenderEntry.Text,
                pet_age = AgeEntry.Text,
                pet_breed = BreedEntry.Text,
                pet_image_path = selectedImagePath
            };

            bool hasEmptyField = pets.GetType() 
                                .GetProperties()
                                .Where(prop => prop.PropertyType == typeof(string))
                                .Any(prop => string.IsNullOrWhiteSpace((string)prop.GetValue(pets)));

            if (hasEmptyField)
            {
                await DisplayAlert("Oops! Failed to add pet.", "Please fill in all the fields.", "OK");
                return;
            }

            if (new[] { pets.pet_name, pets.pet_gender, pets.pet_breed }.Any(s => s.Length > 16))
            {
                await DisplayAlert("Oops! Failed to add pet,", "Limit the inputs to 16 characters only.", "OK");
                return;
            }

            await db_service.AddPet(pets);
            await DisplayAlert("Pet Added!", $"Name: {pets.pet_name}\nGender: {pets.pet_gender}\nAge: {pets.pet_age}\nBreed: {pets.pet_breed}", "OK");

            NameEntry.Text = string.Empty;
            GenderEntry.Text = string.Empty;
            AgeEntry.Text = string.Empty;
            BreedEntry.Text = string.Empty;

            await Navigation.PopAsync();
        }
    }
}