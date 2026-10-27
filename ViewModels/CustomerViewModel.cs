using System.Collections.ObjectModel;
using System.Windows.Input;
using TemperatureConverter.Models;

namespace TemperatureConverter.ViewModels;

public class CustomerViewModel
{
    // ObservableCollection notifies the UI automatically when items are added/removed
    public ObservableCollection<Customer> Customers { get; set; }

    public ICommand AddNewCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SaveAllCommand { get; }

    public CustomerViewModel()
    {
        // Initial sample data matching your screenshots
        Customers = new ObservableCollection<Customer>
        {
            new Customer { Id = 4, Name = "New Company", Address = "123 Main St", Country = "USA" },
            new Customer { Id = 5, Name = "Limhong", Address = "tsetkkk", Country = "k" },
            new Customer { Id = 6, Name = "New Company", Address = "123 Main St", Country = "USA" }
        };

        // Command initializations
        AddNewCommand = new Command(OnAddNew);
        DeleteCommand = new Command(OnDelete);
        SaveAllCommand = new Command(OnSaveAll);
    }

    private void OnAddNew()
    {
        int newId = Customers.Count > 0 ? Customers[^1].Id + 1 : 1;
        Customers.Add(new Customer
        {
            Id = newId,
            Name = "New Company",
            Address = "123 Main St",
            Country = "USA"
        });
    }

    private void OnDelete()
    {
        if (Customers.Count > 0)
        {
            Customers.RemoveAt(Customers.Count - 1); // Removes the last item
        }
    }

    private void OnSaveAll()
    {
        // Add database or save logic here
    }
}