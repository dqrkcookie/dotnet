namespace Pawfect_Care
{
    public partial class AddPetPage : ContentPage
    {
        private string selectedImagePath;

        public AddPetPage()
        {
            InitializeComponent();
        }

        private async void OnSelectImageTapped(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Select Pet Photo"
                });

                if (result != null)
                {
                    // Save the path for later use when saving the pet data
                    selectedImagePath = result.FullPath;
                    // Display the selected image
                    var stream = await result.OpenReadAsync();
                    PetImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to select image: {ex.Message}", "OK");
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Validate entries
            if (string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await DisplayAlert("Error", "Please enter your pet's name", "OK");
                return;
            }

            // Here you would typically save the pet data to your database or storage
            // For now, we'll just show a success message and navigate back
            await DisplayAlert("Success", $"{NameEntry.Text} has been added!", "OK");
            await Navigation.PopAsync();
        }
    }
}