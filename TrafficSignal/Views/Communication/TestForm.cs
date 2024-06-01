using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public SupersocketManager Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        private Device device;
        public Device Device
        {
            get { return device; }
            set
            {
                device = value;
                if (device != null)
                {
                    textEdit1.EditValue = device.DeviceName;
                    textEdit3.EditValue = device.DeviceType;
                }
                else
                {
                    textEdit1.EditValue = string.Empty;
                    textEdit3.EditValue = string.Empty;
                }
            }
        }

        private void testNetWorkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Manager == null || device == null)
                {
                    XtraMessageBox.Show("Manager或Device未初始化，请先进行初始化。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var status = Manager.GetServerStatus(device);
                XtraMessageBox.Show(status);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"测试网络时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Manager == null || device == null)
                {
                    XtraMessageBox.Show("Manager或Device未初始化，请先进行初始化。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedValue = lookupEdit1.EditValue as string;
                if (string.IsNullOrEmpty(selectedValue))
                {
                    XtraMessageBox.Show("请选择一个命令。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = Manager.SendMessageToClient(device, selectedValue);
                XtraMessageBox.Show(result);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"发送消息时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (device == null)
                {
                    XtraMessageBox.Show("Device未初始化，请先进行初始化。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
            catch (Exception ex)
            {
                XtraMessageBox.Show($"加载表单时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
