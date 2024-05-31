using DevExpress.Mvvm.DataModel;
using TrafficSignal.Models;

namespace TrafficSignal.MySqlContextDataModel
{

    /// <summary>
    /// IMySqlContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IMySqlContextUnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// The Device entities repository.
        /// </summary>
        IRepository<Device, int> Device { get; }
    }
}
