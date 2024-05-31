using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EFCore;
using System;
using TrafficSignal.Models;

namespace TrafficSignal.MySqlContextDataModel
{

    /// <summary>
    /// A MySqlContextUnitOfWork instance that represents the run-time implementation of the IMySqlContextUnitOfWork interface.
    /// </summary>
    public class MySqlContextUnitOfWork : DbUnitOfWork<MySqlContext>, IMySqlContextUnitOfWork
    {

        public MySqlContextUnitOfWork(Func<MySqlContext> contextFactory)
            : base(contextFactory)
        {
        }

        IRepository<Device, int> IMySqlContextUnitOfWork.Device
        {
            get { return GetRepository(x => x.Set<Device>(), (Device x) => x.Id); }
        }
    }
}
