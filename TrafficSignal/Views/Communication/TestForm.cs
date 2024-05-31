using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficSignal.Models;
using TrafficSignal.Server;
using TrafficSignal.Server.Enums;

namespace TrafficSignal.Views.Communication
{
    public partial class TestForm : DevExpress.XtraEditors.XtraForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private SupersocketManager manager;
        public SupersocketManager Manager { get; set; }
        private Device device;
        public Device Device
        {
            get { return device; }
            set
            {
                device = value;
                textEdit1.EditValue = device.DeviceName;
                textEdit3.EditValue = device.DeviceType;
            }
        }


        private void testNetWorkBtn_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(Manager.GetServerStatus(device));
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            string selectedValue = lookupEdit1.EditValue as string;
            XtraMessageBox.Show(Manager.SendMessageToClient(device, selectedValue));
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            List<CommandInfo> commands = EnumHelper.GetAllCommandInfos(device);

            lookupEdit1.Properties.DataSource = commands;
            lookupEdit1.Properties.DisplayMember = "Description";
            lookupEdit1.Properties.ValueMember = "HexValue";

            // 设置列显示，只显示描述文本
            lookupEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "描述"));

            // 设置下拉菜单宽度，使其只显示文本内容
            lookupEdit1.Properties.PopupFormSize = new Size(lookupEdit1.Width, 200);

            // 默认选中第一个项
            if (commands.Count > 0)
            {
                lookupEdit1.EditValue = commands[0].HexValue;
            }
        }

    }
}