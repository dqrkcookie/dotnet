using System.Collections.ObjectModel;

namespace Pawfect_Care;

public partial class Scheduler : ContentPage
{
    private readonly local_db_service db_service;
    private ObservableCollection<pet_local_db> pets = new();

    public Scheduler(local_db_service _db_service)
    {
        InitializeComponent();
        db_service = _db_service;
        LoadPets();

        //string date = DatePicker.Date.ToString("MMMM dd, yyyy");
    }

    private async Task LoadPets()
    {
        var loadedPets = await db_service.GetAllPets();
        foreach (var pet in loadedPets)
        {
            pets.Add(pet);
        }

        PetPicker.ItemsSource = pets;
    }

    private async void OnAddScheduleClicked(object sender, EventArgs e)
    {
        
    }

}
