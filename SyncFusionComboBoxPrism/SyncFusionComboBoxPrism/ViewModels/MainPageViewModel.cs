using Prism.Commands;
using Prism.Navigation;
using System;

namespace SyncFusionComboBoxPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private int initalMemoryUsed;
        private string _initalMemoryText;
        public string InitalMemoryText
        {
            get => _initalMemoryText;
            set => SetProperty(ref _initalMemoryText, value);
        }

        private int memoryUsed;
        private string _memoryText;
        private bool initalLaunch = true;

        public string MemoryText
        {
            get => _memoryText;
            set => SetProperty(ref _memoryText, value);
        }

        public DelegateCommand GoToComboBoxCommand { get; set; } 
        public DelegateCommand GoToMainPageCommand { get; set; } 
        public DelegateCommand GoToListViewCommand { get; set; }
        public DelegateCommand GCCommand { get; set; } 
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GoToComboBoxCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("ComboBoxPage"));
            GoToMainPageCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("MainPage"));
            GoToListViewCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync("ListPage"));
            GCCommand = new DelegateCommand(GCAndUpdate);

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            if (initalLaunch)
            {
                initalLaunch = false;
                initalMemoryUsed = (int)(GC.GetTotalMemory(true) / 1024);
                InitalMemoryText = $"The Application used{initalMemoryUsed}k of memory, on first launch.";
            }
            GCAndUpdate();
        }

        private void GCAndUpdate()
        {
            memoryUsed = (int)(GC.GetTotalMemory(true) / 1024);
            MemoryText = $"Application is using {memoryUsed}k of memory. Leaking {memoryUsed - initalMemoryUsed}k";
        }
    }
}
