using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Syncfusion.DataSource.Extensions;
using SyncFusionComboBoxPrism.Models;

namespace SyncFusionComboBoxPrism.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private int _index = 0;

        public ObservableCollection<Person> People { get; set; }

        public DelegateCommand AddItemCommand { get; set; }

        public ListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            People = Enumerable.Range(1, 30).Select(i => new Person { FirstName = $"First{i}", LastName = $"Last{i}", AutomationId = i }).ToObservableCollection();
            AddItemCommand = new DelegateCommand(AddItem);
        }

        private void AddItem()
        {
            People.Add(new Person
            {
                FirstName = $"New{++_index}",
                LastName = $"Person{_index}",
                AutomationId = _index
            });
        }
    }
}