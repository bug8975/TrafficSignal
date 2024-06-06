using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.Extensions;
using log4net;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TrafficSignal.Common;
using TrafficSignal.Models;
using TrafficSignal.MySqlContextDataModel;
using TrafficSignal.Server;
using TrafficSignal.Views.Communication;

namespace TrafficSignal.ViewModels
{

    /// <summary>
    /// Represents the Device collection view model.
    /// </summary>
    public partial class DeviceCollectionViewModel : CollectionViewModel<Device, int, IMySqlContextUnitOfWork>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DeviceCollectionViewModel));
        private SupersocketManager Manager { get; set; }
        private IMessageBoxService BoxService { get; set; }
        /// <summary>
        /// Creates a new instance of DeviceCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static DeviceCollectionViewModel Create(IUnitOfWorkFactory<IMySqlContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new DeviceCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the DeviceCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the DeviceCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected DeviceCollectionViewModel(IUnitOfWorkFactory<IMySqlContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Device)
        {
        }

        public override void OnLoaded()
        {
            try
            {
                BoxService = this.GetService<IMessageBoxService>();
                Manager = new SupersocketManager();
                Manager.CreateFixedPortServer();
                base.OnLoaded();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public async Task OpenNetWorkAsync()
        {

            try
            {
                ObservableCollection<Device> devices = Entities;
                // 创建服务器实例，并根据设备的端口配置服务器
                Manager.CreateServers(devices.ToList());

                // 启动所有服务器
                await Manager.StartAllServersAsync();
                Console.WriteLine("All servers started.");
                BoxService.ShowMessage("All servers started.");
            }
            catch (Exception ex)
            {
                log.Error($"An error occurred: {ex.Message}");
                Console.WriteLine($"An error occurred: {ex.Message}");
                BoxService.ShowMessage($"An error occurred: {ex.Message}");
            }
        }

        public async Task CloseNetWorkAsync()
        {
            try
            {
                // 停止所有服务器
                await Manager.StopAllServersAsync();
                Console.WriteLine("All servers stopped.");
                BoxService.ShowMessage("All servers stopped.");
            }
            catch (Exception ex)
            {
                log.Error($"An error occurred while stopping the servers: {ex.Message}");
                Console.WriteLine($"An error occurred while stopping the servers: {ex.Message}");
                BoxService.ShowMessage($"An error occurred while stopping the servers: {ex.Message}");
            }
        }

        public void TestNetWork()
        {
            TestForm testForm = new TestForm();
            testForm.Device = SelectedEntity;
            testForm.Manager = Manager;
            testForm.ShowDialog();
        }

        public override void Refresh()
        {
            try
            {
                // 使用 ToList() 确保我们遍历的是一个固定的集合快照，避免在循环过程中集合发生变化
                var entitiesSnapshot = Entities.ToList();

                // 更新状态的逻辑
                entitiesSnapshot.ForEach(device =>
                {
                    string state = Manager.GetServerStatus(device);
                    UpdateDeviceState(device.Id, state);
                });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                this.GetService<IMessageBoxService>().ShowMessage(ex.Message);
            }
            base.Refresh();
        }

        private void UpdateDeviceState(int deviceId, string state)
        {
            // 使用单一的 UnitOfWork 实例来避免多个实例之间的数据不一致问题
            var unitOfWork = UnitOfWorkSource.GetUnitOfWorkFactory().CreateUnitOfWork();
            var device = unitOfWork.Device.Find(deviceId);

            if (device != null)
            {
                // 更新数据库中的实体
                device.CollectionState = state;
                unitOfWork.SaveChanges();

                // 更新内存中的实体（Entities 集合）
                var entity = Entities.FirstOrDefault(e => e.Id == deviceId);
                if (entity != null)
                {
                    entity.CollectionState = state;
                }

                Console.WriteLine($"Device {device.DeviceName} state updated to {state}.");
            }
            else
            {
                Console.WriteLine($"Device with ID {deviceId} not found.");
                log.Warn($"Device with ID {deviceId} not found.");
            }
        }

    }
}