using System.ComponentModel.DataAnnotations;

namespace TrafficSignal.Models
{
    public partial class Device
    {
        [Key, Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(Name = "设备名称")]
        public string DeviceName { get; set; }

        [Display(Name = "端口号")]
        public int Port { get; set; }

        [Display(Name = "设备类型")]
        public string DeviceType { get; set; }

        [Display(Name = "设备型号")]
        public string DeviceVersion { get; set; }

        [Display(Name = "设备分组")]
        public string DeviceGroup { get; set; }

        [Display(Name = "车道地址列表")]
        public string LaneAddresses { get; set; }

        [Display(Name = "设备状态")]
        public string CollectionState { get; set; }
    }
}