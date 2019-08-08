using System.Collections.Specialized;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using ScrollToPosition = Syncfusion.ListView.XForms.ScrollToPosition;


namespace SyncFusionComboBoxPrism.Views
{
    public partial class ListPage : ContentPage, IDestructible
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            ListView.DataSource.DisplayItems.CollectionChanged += ListView_CollectionChanged;
        }

        private async void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // UNCOMMENTING THIS LINE TO ADD A SHORT DELAY FIXES THE PROBLEM
                // await Task.Delay(50);

                // THIS ONLY SCROLLS CORRECTLY ON EVERY SECOND CLICK
                ListView.LayoutManager.ScrollToRowIndex(ListView.DataSource.DisplayItems.Count - 1, ScrollToPosition.Center);
            }
        }

        public void Destroy()
        {
            ListView.DataSource.DisplayItems.CollectionChanged -= ListView_CollectionChanged;
        }
    }
}
