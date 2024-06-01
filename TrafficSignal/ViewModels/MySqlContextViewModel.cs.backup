using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using System;
using TrafficSignal.MySqlContextDataModel;

namespace TrafficSignal.ViewModels
{
    /// <summary>
    /// Represents the root POCO view model for the MySqlContext data model.
    /// </summary>
    public partial class MySqlContextViewModel : DocumentsViewModel<MySqlContextModuleDescription, IMySqlContextUnitOfWork>
    {

        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";
        INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }

        /// <summary>
        /// Creates a new instance of MySqlContextViewModel as a POCO view model.
        /// </summary>
        public static MySqlContextViewModel Create()
        {
            return ViewModelSource.Create(() => new MySqlContextViewModel());
        }


        /// <summary>
        /// Initializes a new instance of the MySqlContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the MySqlContextViewModel type without the POCO proxy factory.
        /// </summary>
        protected MySqlContextViewModel()
            : base(UnitOfWorkSource.GetUnitOfWorkFactory())
        {
        }

        protected override MySqlContextModuleDescription[] CreateModules()
        {
            return new MySqlContextModuleDescription[] {
                new MySqlContextModuleDescription( "Device", "DeviceCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Device)),
            };
        }
        protected override void OnActiveModuleChanged(MySqlContextModuleDescription oldModule)
        {
            if (ActiveModule != null && NavigationService != null)
            {
                NavigationService.ClearNavigationHistory();
            }
            base.OnActiveModuleChanged(oldModule);
        }
    }

    public partial class MySqlContextModuleDescription : ModuleDescription<MySqlContextModuleDescription>
    {
        public MySqlContextModuleDescription(string title, string documentType, string group, Func<MySqlContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory)
        {
        }
    }
}