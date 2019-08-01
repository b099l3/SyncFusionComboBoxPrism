using Prism.Commands;
using Prism.Mvvm;
using SyncFusionComboBoxPrism.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SyncFusionComboBoxPrism.ViewModels
{
    public class ComboBoxPageViewModel : BindableBase
    {
        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public List<Item> Items { get; set; } = Enumerable.Range(1, 2000).Select(i => new Item { AutomationId = i, Label = $"Option Number {i}" }).ToList();

        public DelegateCommand<Item> SelectedItemCommand { get; set; }
        public ComboBoxPageViewModel()
        {
            SelectedItemCommand = new DelegateCommand<Item>(ApplyItem);
        }

        private void ApplyItem(Item item)
        {
            Console.WriteLine(item.Label);
        }
    }
}
