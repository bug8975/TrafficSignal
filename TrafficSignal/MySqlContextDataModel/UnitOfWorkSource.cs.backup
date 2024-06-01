using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EFCore;
using TrafficSignal.Models;

namespace TrafficSignal.MySqlContextDataModel
{

    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource
    {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<IMySqlContextUnitOfWork> GetUnitOfWorkFactory()
        {
            return new DbUnitOfWorkFactory<IMySqlContextUnitOfWork>(() => new MySqlContextUnitOfWork(() => new MySqlContext()));
        }
    }
}