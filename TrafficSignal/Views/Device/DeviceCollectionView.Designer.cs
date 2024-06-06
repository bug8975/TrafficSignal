namespace TrafficSignal.Views.DeviceCollectionView
{
    partial class DeviceCollectionView
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceCollectionView));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.deviceCollectionViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaneAddresses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectionState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.windowsUIButtonPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceCollectionViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.deviceCollectionViewBindingSource;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(15, 19, 15, 19);
            this.gridControl.Location = new System.Drawing.Point(92, 53);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(2204, 1580);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // deviceCollectionViewBindingSource
            // 
            this.deviceCollectionViewBindingSource.DataSource = typeof(TrafficSignal.Models.Device);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDeviceName,
            this.colPort,
            this.colDeviceType,
            this.colDeviceVersion,
            this.colDeviceGroup,
            this.colLaneAddresses,
            this.colTestState,
            this.colCollectionState});
            this.gridView.DetailHeight = 809;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colDeviceName
            // 
            this.colDeviceName.AppearanceCell.Options.UseTextOptions = true;
            this.colDeviceName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeviceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceName.FieldName = "DeviceName";
            this.colDeviceName.MinWidth = 43;
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.OptionsColumn.AllowEdit = false;
            this.colDeviceName.OptionsColumn.AllowFocus = false;
            this.colDeviceName.OptionsColumn.ReadOnly = true;
            this.colDeviceName.Visible = true;
            this.colDeviceName.VisibleIndex = 0;
            this.colDeviceName.Width = 164;
            // 
            // colPort
            // 
            this.colPort.AppearanceCell.Options.UseTextOptions = true;
            this.colPort.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPort.AppearanceHeader.Options.UseTextOptions = true;
            this.colPort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPort.FieldName = "Port";
            this.colPort.MinWidth = 43;
            this.colPort.Name = "colPort";
            this.colPort.OptionsColumn.AllowEdit = false;
            this.colPort.OptionsColumn.AllowFocus = false;
            this.colPort.OptionsColumn.ReadOnly = true;
            this.colPort.Visible = true;
            this.colPort.VisibleIndex = 1;
            this.colPort.Width = 164;
            // 
            // colDeviceType
            // 
            this.colDeviceType.AppearanceCell.Options.UseTextOptions = true;
            this.colDeviceType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeviceType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceType.FieldName = "DeviceType";
            this.colDeviceType.MinWidth = 43;
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.OptionsColumn.AllowEdit = false;
            this.colDeviceType.OptionsColumn.AllowFocus = false;
            this.colDeviceType.OptionsColumn.ReadOnly = true;
            this.colDeviceType.Visible = true;
            this.colDeviceType.VisibleIndex = 2;
            this.colDeviceType.Width = 164;
            // 
            // colDeviceVersion
            // 
            this.colDeviceVersion.AppearanceCell.Options.UseTextOptions = true;
            this.colDeviceVersion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeviceVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceVersion.FieldName = "DeviceVersion";
            this.colDeviceVersion.MinWidth = 43;
            this.colDeviceVersion.Name = "colDeviceVersion";
            this.colDeviceVersion.OptionsColumn.AllowEdit = false;
            this.colDeviceVersion.OptionsColumn.AllowFocus = false;
            this.colDeviceVersion.OptionsColumn.ReadOnly = true;
            this.colDeviceVersion.Visible = true;
            this.colDeviceVersion.VisibleIndex = 3;
            this.colDeviceVersion.Width = 164;
            // 
            // colDeviceGroup
            // 
            this.colDeviceGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colDeviceGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeviceGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceGroup.FieldName = "DeviceGroup";
            this.colDeviceGroup.MinWidth = 43;
            this.colDeviceGroup.Name = "colDeviceGroup";
            this.colDeviceGroup.OptionsColumn.AllowEdit = false;
            this.colDeviceGroup.OptionsColumn.AllowFocus = false;
            this.colDeviceGroup.OptionsColumn.ReadOnly = true;
            this.colDeviceGroup.Visible = true;
            this.colDeviceGroup.VisibleIndex = 4;
            this.colDeviceGroup.Width = 164;
            // 
            // colLaneAddresses
            // 
            this.colLaneAddresses.AppearanceCell.Options.UseTextOptions = true;
            this.colLaneAddresses.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLaneAddresses.AppearanceHeader.Options.UseTextOptions = true;
            this.colLaneAddresses.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLaneAddresses.Caption = "车道地址列表";
            this.colLaneAddresses.FieldName = "LaneAddresses";
            this.colLaneAddresses.MinWidth = 43;
            this.colLaneAddresses.Name = "colLaneAddresses";
            this.colLaneAddresses.OptionsColumn.AllowEdit = false;
            this.colLaneAddresses.OptionsColumn.AllowFocus = false;
            this.colLaneAddresses.OptionsColumn.ReadOnly = true;
            this.colLaneAddresses.Visible = true;
            this.colLaneAddresses.VisibleIndex = 5;
            this.colLaneAddresses.Width = 164;
            // 
            // colTestState
            // 
            this.colTestState.AppearanceCell.Options.UseTextOptions = true;
            this.colTestState.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTestState.AppearanceHeader.Options.UseTextOptions = true;
            this.colTestState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTestState.Caption = "调试状态";
            this.colTestState.FieldName = "TestState";
            this.colTestState.MinWidth = 43;
            this.colTestState.Name = "colTestState";
            this.colTestState.OptionsColumn.AllowEdit = false;
            this.colTestState.OptionsColumn.AllowFocus = false;
            this.colTestState.OptionsColumn.ReadOnly = true;
            this.colTestState.Visible = true;
            this.colTestState.VisibleIndex = 6;
            this.colTestState.Width = 164;
            // 
            // colCollectionState
            // 
            this.colCollectionState.AppearanceCell.Options.UseTextOptions = true;
            this.colCollectionState.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectionState.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectionState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectionState.FieldName = "CollectionState";
            this.colCollectionState.MinWidth = 43;
            this.colCollectionState.Name = "colCollectionState";
            this.colCollectionState.OptionsColumn.AllowEdit = false;
            this.colCollectionState.OptionsColumn.AllowFocus = false;
            this.colCollectionState.OptionsColumn.ReadOnly = true;
            this.colCollectionState.Visible = true;
            this.colCollectionState.VisibleIndex = 7;
            this.colCollectionState.Width = 164;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterMessageBoxService(null, false, this, DevExpress.Utils.MVVM.Services.DefaultMessageBoxServiceType.XtraMessageBox)});
            this.mvvmContext.ViewModelType = typeof(TrafficSignal.ViewModels.DeviceCollectionViewModel);
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
            this.labelControl.Location = new System.Drawing.Point(92, 0);
            this.labelControl.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.labelControl.Name = "labelControl";
            this.labelControl.Padding = new System.Windows.Forms.Padding(0, 7, 29, 14);
            this.labelControl.Size = new System.Drawing.Size(2204, 53);
            this.labelControl.StyleController = this.layoutControl;
            this.labelControl.TabIndex = 4;
            this.labelControl.Text = "设备";
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomization = false;
            this.layoutControl.Controls.Add(this.labelControl);
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(2388, 1633);
            this.layoutControl.TabIndex = 0;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemLabel,
            this.itemGrid});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(92, 92, 0, 0);
            this.layoutControlGroup.Size = new System.Drawing.Size(2388, 1633);
            this.layoutControlGroup.TextVisible = false;
            // 
            // itemLabel
            // 
            this.itemLabel.Control = this.labelControl;
            this.itemLabel.Location = new System.Drawing.Point(0, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.itemLabel.Size = new System.Drawing.Size(2204, 53);
            this.itemLabel.TextSize = new System.Drawing.Size(0, 0);
            this.itemLabel.TextVisible = false;
            // 
            // itemGrid
            // 
            this.itemGrid.Control = this.gridControl;
            this.itemGrid.Location = new System.Drawing.Point(0, 53);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.itemGrid.Size = new System.Drawing.Size(2204, 1580);
            this.itemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itemGrid.TextVisible = false;
            // 
            // windowsUIButtonPanel
            // 
            this.windowsUIButtonPanel.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            windowsUIButtonImageOptions1.ImageUri.Uri = "New;Size32x32;GrayScaled";
            windowsUIButtonImageOptions2.ImageUri.Uri = "Edit;Size32x32;GrayScaled";
            windowsUIButtonImageOptions3.ImageUri.Uri = "Edit/Delete;Size32x32;GrayScaled";
            windowsUIButtonImageOptions4.ImageUri.Uri = "Refresh;Size32x32;GrayScaled";
            windowsUIButtonImageOptions5.ImageUri.Uri = "Preview;Size32x32;GrayScaled";
            windowsUIButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions6.Image")));
            windowsUIButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions7.Image")));
            windowsUIButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions8.Image")));
            this.windowsUIButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("新增", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("修改", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("删除", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("刷新", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("打印", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("开启", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("关闭", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("测试", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanel.EnableImageTransparency = true;
            this.windowsUIButtonPanel.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanel.Location = new System.Drawing.Point(0, 1633);
            this.windowsUIButtonPanel.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.windowsUIButtonPanel.MaximumSize = new System.Drawing.Size(0, 138);
            this.windowsUIButtonPanel.MinimumSize = new System.Drawing.Size(140, 138);
            this.windowsUIButtonPanel.Name = "windowsUIButtonPanel";
            this.windowsUIButtonPanel.Size = new System.Drawing.Size(2388, 138);
            this.windowsUIButtonPanel.TabIndex = 1;
            this.windowsUIButtonPanel.Text = "windowsUIButtonPanel";
            this.windowsUIButtonPanel.UseButtonBackgroundImages = false;
            // 
            // DeviceCollectionView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.windowsUIButtonPanel);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "DeviceCollectionView";
            this.Size = new System.Drawing.Size(2388, 1771);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceCollectionViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource deviceCollectionViewBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem itemLabel;
        private DevExpress.XtraLayout.LayoutControlItem itemGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceName;
        private DevExpress.XtraGrid.Columns.GridColumn colPort;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceType;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colLaneAddresses;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectionState;
        private DevExpress.XtraGrid.Columns.GridColumn colTestState;
    }
}
