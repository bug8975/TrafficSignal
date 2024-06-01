using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.Extensions;
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
        private SupersocketManager Manager { get; set; }
        private IMessageBoxService BoxService { get; set; }
        private MySqlContext _dbContext;
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
                _dbContext = new MySqlContext();
                Manager = new SupersocketManager(_dbContext);
                BoxService = this.GetService<IMessageBoxService>();
                Manager.CreateFixedPortServer();
                base.OnLoaded();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void Refresh()
        {
            try
            {
                Entities.ForEach(device =>
                {
                    string state = Manager.GetServerStatus(device);
                    UpdateDeviceState(device.Id, state);
                });
            }
            catch (Exception ex)
            {
                this.GetService<IMessageBoxService>().ShowMessage(ex.Message);
            }
            base.Refresh();
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

        private void UpdateDeviceState(int deviceId, string state)
        {
            var device = _dbContext.Device.Find(deviceId);
            if (device != null)
            {
                device.CollectionState = state;
                _dbContext.SaveChanges();
                Console.WriteLine($"Device {device.DeviceName} state updated to {state}.");
            }
            else
            {
                Console.WriteLine($"Device with ID {deviceId} not found.");
            }
        }

    }
}