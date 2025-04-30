using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Pawfect_Care
{
    public partial class Profile : ContentPage
    {
        private readonly local_db_service db_service;
        private ObservableCollection<pet_local_db> pets;

        public Profile(local_db_service _db_service)
        {
            InitializeComponent();
            db_service = _db_service;

            pets = new ObservableCollection<pet_local_db>();

            PetsListView.ItemsSource = pets;

            this.Appearing += PetsListPage_Appearing;
        }

        private async void PetsListPage_Appearing(object sender, EventArgs e)
        {
            await LoadPetsAsync();
        }

        private async Task LoadPetsAsync()
        {
            try
            {
                pets.Clear();
                var petsList = await db_service.GetAllPets();
                foreach (var pet in petsList)
                {
                    pets.Add(pet);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load pets: {ex.Message}", "OK");
            }
        }

        private async void PetsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }

}