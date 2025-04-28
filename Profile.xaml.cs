using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Pawfect_Care
{
    public partial class Profile : ContentPage
    {
        private ObservableCollection<PetModel> pets;

        public Profile()
        {
            InitializeComponent();

            // Initialize pet data - in a real app this would come from your database
            pets = new ObservableCollection<PetModel>
            {
                new PetModel
                {
                    Id = 1,
                    Name = "Buddy",
                    Age = "2",
                    Gender = "Male",
                    Breed = "Golden Retriever",
                    ImagePath = "sample.png"
                },
            };

            // Set the ListView's ItemsSource to the collection of pets
            PetsListView.ItemsSource = pets;
        }

        private async void PetsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is PetModel pet)
            {
                // Prevent double-tapping
                ((ListView)sender).SelectedItem = null;

                // Navigate to a detail page or show action options
                await DisplayActionSheet("Select Action", "Cancel", null, "Delete", "Edit");

                // Here you would typically navigate to a pet detail page
                // await Navigation.PushAsync(new PetDetailPage(pet));
            }
        }
    }

    // Model class for pet data
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public string ImagePath { get; set; }
    }
}