using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using TrafficSignal.Common;
using TrafficSignal.Models;
using TrafficSignal.MySqlContextDataModel;

namespace TrafficSignal.ViewModels
{

    /// <summary>
    /// Represents the single Device object view model.
    /// </summary>
    public partial class DeviceViewModel : SingleObjectViewModel<Device, int, IMySqlContextUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of DeviceViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DeviceViewModel Create(IUnitOfWorkFactory<IMySqlContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new DeviceViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the DeviceViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DeviceViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DeviceViewModel(IUnitOfWorkFactory<IMySqlContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Device, x => x.DeviceName)
        {
        }



    }
}
