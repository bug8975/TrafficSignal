using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;

namespace TrafficSignal.Views
{
    public partial class MySqlContextView : XtraForm
    {
        public MySqlContextView()
        {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitializeNavigation();
        }
        void InitializeNavigation()
        {
            tileBar.SelectionColorMode = SelectionColorMode.UseItemBackColor;
            mvvmContext.RegisterService(DocumentManagerService.Create(navigationFrame));
            DevExpress.Utils.MVVM.MVVMContext.RegisterFlyoutDialogService();
            // We want to use buttons in Ribbon to show the specific modules
            var fluentAPI = mvvmContext.OfType<TrafficSignal.ViewModels.MySqlContextViewModel>();
            tileBar.SelectedItem = tileBarItemDeviceCollectionView;

            fluentAPI.BindCommand(tileBarItemDeviceCollectionView, (x, m) => x.Show(m), x => x.Modules[0]);
            // We want show the default module when our UserControl is loaded
            fluentAPI.WithEvent<EventArgs>(this, "Load")
                .EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);

        }
    }
}
