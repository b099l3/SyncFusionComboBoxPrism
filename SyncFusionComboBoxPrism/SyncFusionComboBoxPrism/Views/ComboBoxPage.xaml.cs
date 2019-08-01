using Prism.Navigation;
using Xamarin.Forms;

namespace SyncFusionComboBoxPrism.Views
{
    public partial class ComboBoxPage : ContentPage, IDestructible
    {
        public ComboBoxPage()
        {
            InitializeComponent();
        }

        public void Destroy()
        {
            ItemDropdown.Behaviors.Clear();
        }
    }
}
