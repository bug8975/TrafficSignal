namespace TrafficSignal.Views.DeviceView
{
    partial class DeviceView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions9 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions10 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions11 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions12 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.DeviceNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.deviceViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PortTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DeviceTypeTextEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CollectionStateTextEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDeviceName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPort = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeviceType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCollectionState = new DevExpress.XtraLayout.LayoutControlItem();
            this.windowsUIButtonPanelCloseButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.windowsUIButtonPanelMain = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceTypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionStateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCollectionState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.DeviceNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PortTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DeviceTypeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CollectionStateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEdit1);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEdit2);
            this.dataLayoutControl1.DataSource = this.deviceViewBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(60, 38);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1305, 779);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // DeviceNameTextEdit
            // 
            this.DeviceNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceViewBindingSource, "DeviceName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DeviceNameTextEdit.Location = new System.Drawing.Point(76, 12);
            this.DeviceNameTextEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeviceNameTextEdit.Name = "DeviceNameTextEdit";
            this.DeviceNameTextEdit.Size = new System.Drawing.Size(1217, 23);
            this.DeviceNameTextEdit.StyleController = this.dataLayoutControl1;
            this.DeviceNameTextEdit.TabIndex = 4;
            // 
            // deviceViewBindingSource
            // 
            this.deviceViewBindingSource.DataSource = typeof(TrafficSignal.Models.Device);
            // 
            // PortTextEdit
            // 
            this.PortTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceViewBindingSource, "Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PortTextEdit.Location = new System.Drawing.Point(76, 39);
            this.PortTextEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PortTextEdit.Name = "PortTextEdit";
            this.PortTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PortTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PortTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PortTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.PortTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.PortTextEdit.Size = new System.Drawing.Size(1217, 23);
            this.PortTextEdit.StyleController = this.dataLayoutControl1;
            this.PortTextEdit.TabIndex = 5;
            // 
            // DeviceTypeTextEdit
            // 
            this.DeviceTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceViewBindingSource, "DeviceType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DeviceTypeTextEdit.Location = new System.Drawing.Point(76, 66);
            this.DeviceTypeTextEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeviceTypeTextEdit.Name = "DeviceTypeTextEdit";
            this.DeviceTypeTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DeviceTypeTextEdit.Properties.Items.AddRange(new object[] {
            "红绿灯",
            "显示屏",
            "声光报警器"});
            this.DeviceTypeTextEdit.Size = new System.Drawing.Size(1217, 23);
            this.DeviceTypeTextEdit.StyleController = this.dataLayoutControl1;
            this.DeviceTypeTextEdit.TabIndex = 6;
            // 
            // CollectionStateTextEdit
            // 
            this.CollectionStateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceViewBindingSource, "CollectionState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CollectionStateTextEdit.Location = new System.Drawing.Point(76, 147);
            this.CollectionStateTextEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CollectionStateTextEdit.Name = "CollectionStateTextEdit";
            this.CollectionStateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CollectionStateTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CollectionStateTextEdit.Size = new System.Drawing.Size(1217, 23);
            this.CollectionStateTextEdit.StyleController = this.dataLayoutControl1;
            this.CollectionStateTextEdit.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1305, 779);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDeviceName,
            this.ItemForPort,
            this.ItemForDeviceType,
            this.layoutControlItem1,
            this.ItemForCollectionState,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1285, 759);
            // 
            // ItemForDeviceName
            // 
            this.ItemForDeviceName.Control = this.DeviceNameTextEdit;
            this.ItemForDeviceName.Location = new System.Drawing.Point(0, 0);
            this.ItemForDeviceName.Name = "ItemForDeviceName";
            this.ItemForDeviceName.Size = new System.Drawing.Size(1285, 27);
            this.ItemForDeviceName.TextSize = new System.Drawing.Size(60, 15);
            // 
            // ItemForPort
            // 
            this.ItemForPort.Control = this.PortTextEdit;
            this.ItemForPort.Location = new System.Drawing.Point(0, 27);
            this.ItemForPort.Name = "ItemForPort";
            this.ItemForPort.Size = new System.Drawing.Size(1285, 27);
            this.ItemForPort.TextSize = new System.Drawing.Size(60, 15);
            // 
            // ItemForDeviceType
            // 
            this.ItemForDeviceType.Control = this.DeviceTypeTextEdit;
            this.ItemForDeviceType.Location = new System.Drawing.Point(0, 54);
            this.ItemForDeviceType.Name = "ItemForDeviceType";
            this.ItemForDeviceType.Size = new System.Drawing.Size(1285, 27);
            this.ItemForDeviceType.TextSize = new System.Drawing.Size(60, 15);
            // 
            // ItemForCollectionState
            // 
            this.ItemForCollectionState.Control = this.CollectionStateTextEdit;
            this.ItemForCollectionState.Location = new System.Drawing.Point(0, 135);
            this.ItemForCollectionState.Name = "ItemForCollectionState";
            this.ItemForCollectionState.Size = new System.Drawing.Size(1285, 624);
            this.ItemForCollectionState.TextSize = new System.Drawing.Size(60, 15);
            this.ItemForCollectionState.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // windowsUIButtonPanelCloseButton
            // 
            this.windowsUIButtonPanelCloseButton.ButtonInterval = 0;
            windowsUIButtonImageOptions7.ImageUri.Uri = "Backward;Size32x32;GrayScaled";
            this.windowsUIButtonPanelCloseButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanelCloseButton.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.windowsUIButtonPanelCloseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowsUIButtonPanelCloseButton.ForeColor = System.Drawing.Color.Gray;
            this.windowsUIButtonPanelCloseButton.Location = new System.Drawing.Point(0, 0);
            this.windowsUIButtonPanelCloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.windowsUIButtonPanelCloseButton.MaximumSize = new System.Drawing.Size(60, 0);
            this.windowsUIButtonPanelCloseButton.MinimumSize = new System.Drawing.Size(60, 0);
            this.windowsUIButtonPanelCloseButton.Name = "windowsUIButtonPanelCloseButton";
            this.windowsUIButtonPanelCloseButton.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.windowsUIButtonPanelCloseButton.Padding = new System.Windows.Forms.Padding(7, 6, 0, 0);
            this.windowsUIButtonPanelCloseButton.Size = new System.Drawing.Size(60, 817);
            this.windowsUIButtonPanelCloseButton.TabIndex = 2;
            this.windowsUIButtonPanelCloseButton.Text = "windowsUIButtonPanel1";
            // 
            // windowsUIButtonPanelMain
            // 
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            windowsUIButtonImageOptions8.ImageUri.Uri = "Save;Size32x32;GrayScaled";
            windowsUIButtonImageOptions9.ImageUri.Uri = "SaveAndClose;Size32x32;GrayScaled";
            windowsUIButtonImageOptions10.ImageUri.Uri = "SaveAndNew;Size32x32;GrayScaled";
            windowsUIButtonImageOptions11.ImageUri.Uri = "Reset;Size32x32;GrayScaled";
            windowsUIButtonImageOptions12.ImageUri.Uri = "Edit/Delete;Size32x32;GrayScaled";
            this.windowsUIButtonPanelMain.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save And Close", true, windowsUIButtonImageOptions9, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save And New", true, windowsUIButtonImageOptions10, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Reset Changes", true, windowsUIButtonImageOptions11, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions12, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanelMain.EnableImageTransparency = true;
            this.windowsUIButtonPanelMain.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanelMain.Location = new System.Drawing.Point(0, 817);
            this.windowsUIButtonPanelMain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.windowsUIButtonPanelMain.MaximumSize = new System.Drawing.Size(0, 69);
            this.windowsUIButtonPanelMain.MinimumSize = new System.Drawing.Size(80, 69);
            this.windowsUIButtonPanelMain.Name = "windowsUIButtonPanelMain";
            this.windowsUIButtonPanelMain.Size = new System.Drawing.Size(1365, 69);
            this.windowsUIButtonPanelMain.TabIndex = 3;
            this.windowsUIButtonPanelMain.Text = "windowsUIButtonPanelMain";
            this.windowsUIButtonPanelMain.UseButtonBackgroundImages = false;
            // 
            // labelControl
            // 
            this.labelControl.AllowHtmlString = true;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.Options.UseFont = true;
            this.labelControl.Appearance.Options.UseForeColor = true;
            this.labelControl.Appearance.Options.UseTextOptions = true;
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl.Location = new System.Drawing.Point(60, 0);
            this.labelControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl.Name = "labelControl";
            this.labelControl.Padding = new System.Windows.Forms.Padding(13, 6, 0, 0);
            this.labelControl.Size = new System.Drawing.Size(1305, 38);
            this.labelControl.TabIndex = 1;
            this.labelControl.Text = "Device - Element View";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(TrafficSignal.ViewModels.DeviceViewModel);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(76, 93);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "UP",
            "DOWN"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(1217, 23);
            this.comboBoxEdit1.StyleController = this.dataLayoutControl1;
            this.comboBoxEdit1.TabIndex = 8;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.comboBoxEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1285, 27);
            this.layoutControlItem1.Text = "设备分组";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 15);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(76, 120);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.Items.AddRange(new object[] {
            "大屏（横屏）",
            "小屏（竖屏）"});
            this.comboBoxEdit2.Size = new System.Drawing.Size(1217, 23);
            this.comboBoxEdit2.StyleController = this.dataLayoutControl1;
            this.comboBoxEdit2.TabIndex = 9;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBoxEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1285, 27);
            this.layoutControlItem2.Text = "设备型号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 15);
            // 
            // DeviceView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.windowsUIButtonPanelCloseButton);
            this.Controls.Add(this.windowsUIButtonPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DeviceView";
            this.Size = new System.Drawing.Size(1365, 886);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceTypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionStateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCollectionState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanelCloseButton;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanelMain;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private System.Windows.Forms.BindingSource deviceViewBindingSource;
        private DevExpress.XtraEditors.TextEdit DeviceNameTextEdit;
        private DevExpress.XtraEditors.TextEdit PortTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit DeviceTypeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeviceName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPort;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeviceType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCollectionState;
        private DevExpress.XtraEditors.ComboBoxEdit CollectionStateTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
