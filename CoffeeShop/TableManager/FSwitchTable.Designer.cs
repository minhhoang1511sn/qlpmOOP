
namespace CoffeeShop
{
    partial class FSwitchTable
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSwitchTable));
            this.mainElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelContainer = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelEvent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnSwitch = new Guna.UI2.WinForms.Guna2ImageButton();
            this.grInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lb = new System.Windows.Forms.Label();
            this.cbTableName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbUsedTable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbEmptyTableId = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbUsedTableId = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panelControl = new Guna.UI2.WinForms.Guna2Panel();
            this.cBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ShadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.panelContainer.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.grInfo.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainElipse
            // 
            this.mainElipse.BorderRadius = 30;
            this.mainElipse.TargetControl = this;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.BorderColor = System.Drawing.Color.Transparent;
            this.panelContainer.BorderThickness = 1;
            this.panelContainer.Controls.Add(this.panelEvent);
            this.panelContainer.Controls.Add(this.grInfo);
            this.panelContainer.CustomizableEdges.BottomLeft = false;
            this.panelContainer.CustomizableEdges.BottomRight = false;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(104)))), ((int)(((byte)(80)))));
            this.panelContainer.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.panelContainer.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.panelContainer.Location = new System.Drawing.Point(0, 35);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.ShadowDecoration.Parent = this.panelContainer;
            this.panelContainer.Size = new System.Drawing.Size(550, 195);
            this.panelContainer.TabIndex = 94;
            this.panelContainer.UseTransparentBackground = true;
            // 
            // panelEvent
            // 
            this.panelEvent.BorderRadius = 20;
            this.panelEvent.Controls.Add(this.lbTitle);
            this.panelEvent.Controls.Add(this.btnSwitch);
            this.panelEvent.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.panelEvent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(45)))), ((int)(((byte)(43)))));
            this.panelEvent.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelEvent.Location = new System.Drawing.Point(421, 10);
            this.panelEvent.Margin = new System.Windows.Forms.Padding(4);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.ShadowDecoration.BorderRadius = 20;
            this.panelEvent.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panelEvent.ShadowDecoration.Depth = 40;
            this.panelEvent.ShadowDecoration.Parent = this.panelEvent;
            this.panelEvent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(7, 0, 0, 7);
            this.panelEvent.Size = new System.Drawing.Size(116, 175);
            this.panelEvent.TabIndex = 94;
            this.panelEvent.UseTransparentBackground = true;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(116, 41);
            this.lbTitle.TabIndex = 92;
            this.lbTitle.Text = "CHUYỂN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSwitch
            // 
            this.btnSwitch.AnimatedGIF = true;
            this.btnSwitch.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSwitch.CheckedState.Parent = this.btnSwitch;
            this.btnSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSwitch.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.HoverState.Image")));
            this.btnSwitch.HoverState.ImageSize = new System.Drawing.Size(80, 80);
            this.btnSwitch.HoverState.Parent = this.btnSwitch;
            this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
            this.btnSwitch.ImageRotate = 0F;
            this.btnSwitch.ImageSize = new System.Drawing.Size(80, 80);
            this.btnSwitch.Location = new System.Drawing.Point(0, 41);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.PressedState.Image")));
            this.btnSwitch.PressedState.ImageSize = new System.Drawing.Size(80, 80);
            this.btnSwitch.PressedState.Parent = this.btnSwitch;
            this.btnSwitch.Size = new System.Drawing.Size(116, 134);
            this.btnSwitch.TabIndex = 91;
            this.btnSwitch.UseTransparentBackground = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // grInfo
            // 
            this.grInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grInfo.BackColor = System.Drawing.Color.Transparent;
            this.grInfo.BorderColor = System.Drawing.Color.Empty;
            this.grInfo.BorderRadius = 20;
            this.grInfo.BorderThickness = 0;
            this.grInfo.Controls.Add(this.lb);
            this.grInfo.Controls.Add(this.cbTableName);
            this.grInfo.Controls.Add(this.cbUsedTable);
            this.grInfo.Controls.Add(this.cbEmptyTableId);
            this.grInfo.Controls.Add(this.cbUsedTableId);
            this.grInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(45)))), ((int)(((byte)(43)))));
            this.grInfo.CustomBorderThickness = new System.Windows.Forms.Padding(0, 50, -1, 0);
            this.grInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.grInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.grInfo.Location = new System.Drawing.Point(13, 33);
            this.grInfo.Margin = new System.Windows.Forms.Padding(4);
            this.grInfo.Name = "grInfo";
            this.grInfo.ShadowDecoration.BorderRadius = 20;
            this.grInfo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.grInfo.ShadowDecoration.Parent = this.grInfo;
            this.grInfo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.grInfo.Size = new System.Drawing.Size(400, 129);
            this.grInfo.TabIndex = 90;
            this.grInfo.Text = "Chọn bàn cần chuyển";
            this.grInfo.TextOffset = new System.Drawing.Point(0, 5);
            this.grInfo.UseTransparentBackground = true;
            // 
            // lb
            // 
            this.lb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb.AutoSize = true;
            this.lb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.lb.Location = new System.Drawing.Point(172, 77);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(56, 28);
            this.lb.TabIndex = 29;
            this.lb.Text = "Sang";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTableName
            // 
            this.cbTableName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTableName.Animated = true;
            this.cbTableName.AutoRoundedCorners = true;
            this.cbTableName.BackColor = System.Drawing.Color.Transparent;
            this.cbTableName.BorderColor = System.Drawing.Color.Transparent;
            this.cbTableName.BorderRadius = 17;
            this.cbTableName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.cbTableName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbTableName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbTableName.FocusedState.Parent = this.cbTableName;
            this.cbTableName.Font = new System.Drawing.Font("Helvetica World", 10.2F);
            this.cbTableName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbTableName.HoverState.Parent = this.cbTableName;
            this.cbTableName.ItemHeight = 30;
            this.cbTableName.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbTableName.ItemsAppearance.Parent = this.cbTableName;
            this.cbTableName.Location = new System.Drawing.Point(234, 69);
            this.cbTableName.Margin = new System.Windows.Forms.Padding(4);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.ShadowDecoration.Parent = this.cbTableName;
            this.cbTableName.Size = new System.Drawing.Size(150, 36);
            this.cbTableName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbTableName.TabIndex = 28;
            this.cbTableName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbUsedTable
            // 
            this.cbUsedTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbUsedTable.Animated = true;
            this.cbUsedTable.AutoRoundedCorners = true;
            this.cbUsedTable.BackColor = System.Drawing.Color.Transparent;
            this.cbUsedTable.BorderColor = System.Drawing.Color.Transparent;
            this.cbUsedTable.BorderRadius = 17;
            this.cbUsedTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUsedTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsedTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.cbUsedTable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbUsedTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbUsedTable.FocusedState.Parent = this.cbUsedTable;
            this.cbUsedTable.Font = new System.Drawing.Font("Helvetica World", 10.2F);
            this.cbUsedTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbUsedTable.FormattingEnabled = true;
            this.cbUsedTable.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbUsedTable.HoverState.Parent = this.cbUsedTable;
            this.cbUsedTable.ItemHeight = 30;
            this.cbUsedTable.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbUsedTable.ItemsAppearance.Parent = this.cbUsedTable;
            this.cbUsedTable.Location = new System.Drawing.Point(16, 69);
            this.cbUsedTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsedTable.Name = "cbUsedTable";
            this.cbUsedTable.ShadowDecoration.Parent = this.cbUsedTable;
            this.cbUsedTable.Size = new System.Drawing.Size(150, 36);
            this.cbUsedTable.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbUsedTable.TabIndex = 28;
            this.cbUsedTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbEmptyTableId
            // 
            this.cbEmptyTableId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbEmptyTableId.Animated = true;
            this.cbEmptyTableId.AutoRoundedCorners = true;
            this.cbEmptyTableId.BackColor = System.Drawing.Color.Transparent;
            this.cbEmptyTableId.BorderColor = System.Drawing.Color.Transparent;
            this.cbEmptyTableId.BorderRadius = 17;
            this.cbEmptyTableId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEmptyTableId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmptyTableId.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.cbEmptyTableId.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbEmptyTableId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbEmptyTableId.FocusedState.Parent = this.cbEmptyTableId;
            this.cbEmptyTableId.Font = new System.Drawing.Font("Helvetica World", 10.2F);
            this.cbEmptyTableId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbEmptyTableId.FormattingEnabled = true;
            this.cbEmptyTableId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbEmptyTableId.HoverState.Parent = this.cbEmptyTableId;
            this.cbEmptyTableId.ItemHeight = 30;
            this.cbEmptyTableId.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbEmptyTableId.ItemsAppearance.Parent = this.cbEmptyTableId;
            this.cbEmptyTableId.Location = new System.Drawing.Point(312, 8);
            this.cbEmptyTableId.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmptyTableId.Name = "cbEmptyTableId";
            this.cbEmptyTableId.ShadowDecoration.Parent = this.cbEmptyTableId;
            this.cbEmptyTableId.Size = new System.Drawing.Size(65, 36);
            this.cbEmptyTableId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbEmptyTableId.TabIndex = 28;
            this.cbEmptyTableId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbUsedTableId
            // 
            this.cbUsedTableId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbUsedTableId.Animated = true;
            this.cbUsedTableId.AutoRoundedCorners = true;
            this.cbUsedTableId.BackColor = System.Drawing.Color.Transparent;
            this.cbUsedTableId.BorderColor = System.Drawing.Color.Transparent;
            this.cbUsedTableId.BorderRadius = 17;
            this.cbUsedTableId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUsedTableId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsedTableId.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.cbUsedTableId.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbUsedTableId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(96)))), ((int)(((byte)(48)))));
            this.cbUsedTableId.FocusedState.Parent = this.cbUsedTableId;
            this.cbUsedTableId.Font = new System.Drawing.Font("Helvetica World", 10.2F);
            this.cbUsedTableId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbUsedTableId.FormattingEnabled = true;
            this.cbUsedTableId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(151)))), ((int)(((byte)(59)))));
            this.cbUsedTableId.HoverState.Parent = this.cbUsedTableId;
            this.cbUsedTableId.ItemHeight = 30;
            this.cbUsedTableId.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbUsedTableId.ItemsAppearance.Parent = this.cbUsedTableId;
            this.cbUsedTableId.Location = new System.Drawing.Point(241, 8);
            this.cbUsedTableId.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsedTableId.Name = "cbUsedTableId";
            this.cbUsedTableId.ShadowDecoration.Parent = this.cbUsedTableId;
            this.cbUsedTableId.Size = new System.Drawing.Size(65, 36);
            this.cbUsedTableId.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbUsedTableId.TabIndex = 28;
            this.cbUsedTableId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.Transparent;
            this.panelControl.Controls.Add(this.cBox2);
            this.panelControl.Controls.Add(this.cBox1);
            this.panelControl.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.panelControl.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.ShadowDecoration.Parent = this.panelControl;
            this.panelControl.Size = new System.Drawing.Size(550, 35);
            this.panelControl.TabIndex = 96;
            this.panelControl.UseTransparentBackground = true;
            // 
            // cBox2
            // 
            this.cBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox2.Animated = true;
            this.cBox2.BackColor = System.Drawing.Color.Transparent;
            this.cBox2.BorderColor = System.Drawing.Color.Empty;
            this.cBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.cBox2.FillColor = System.Drawing.Color.Transparent;
            this.cBox2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.cBox2.HoverState.Parent = this.cBox2;
            this.cBox2.IconColor = System.Drawing.Color.White;
            this.cBox2.Location = new System.Drawing.Point(469, 5);
            this.cBox2.Margin = new System.Windows.Forms.Padding(4);
            this.cBox2.Name = "cBox2";
            this.cBox2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.cBox2.ShadowDecoration.Parent = this.cBox2;
            this.cBox2.Size = new System.Drawing.Size(28, 24);
            this.cBox2.TabIndex = 24;
            this.cBox2.UseTransparentBackground = true;
            // 
            // cBox1
            // 
            this.cBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox1.Animated = true;
            this.cBox1.BackColor = System.Drawing.Color.Transparent;
            this.cBox1.BorderColor = System.Drawing.Color.Empty;
            this.cBox1.FillColor = System.Drawing.Color.Transparent;
            this.cBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.cBox1.HoverState.Parent = this.cBox1;
            this.cBox1.IconColor = System.Drawing.Color.White;
            this.cBox1.Location = new System.Drawing.Point(505, 5);
            this.cBox1.Margin = new System.Windows.Forms.Padding(4);
            this.cBox1.Name = "cBox1";
            this.cBox1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(49)))), ((int)(((byte)(46)))));
            this.cBox1.ShadowDecoration.Parent = this.cBox1;
            this.cBox1.Size = new System.Drawing.Size(28, 24);
            this.cBox1.TabIndex = 23;
            this.cBox1.UseTransparentBackground = true;
            // 
            // DragControl
            // 
            this.DragControl.ContainerControl = this;
            this.DragControl.TargetControl = this.panelControl;
            // 
            // ShadowForm
            // 
            this.ShadowForm.BorderRadius = 30;
            this.ShadowForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ShadowForm.TargetForm = this;
            // 
            // FSwitchTable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(550, 230);
            this.ControlBox = false;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 230);
            this.Name = "FSwitchTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSwitchTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSwitchTable_FormClosing);
            this.Load += new System.EventHandler(this.FSwitchTable_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelEvent.ResumeLayout(false);
            this.grInfo.ResumeLayout(false);
            this.grInfo.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse mainElipse;
        private Guna.UI2.WinForms.Guna2GradientPanel panelContainer;
        private Guna.UI2.WinForms.Guna2GroupBox grInfo;
        private Guna.UI2.WinForms.Guna2ComboBox cbTableName;
        private Guna.UI2.WinForms.Guna2ComboBox cbUsedTable;
        private Guna.UI2.WinForms.Guna2ComboBox cbEmptyTableId;
        private Guna.UI2.WinForms.Guna2ComboBox cbUsedTableId;
        private System.Windows.Forms.Label lb;
        private Guna.UI2.WinForms.Guna2ImageButton btnSwitch;
        private Guna.UI2.WinForms.Guna2GradientPanel panelEvent;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2Panel panelControl;
        private Guna.UI2.WinForms.Guna2ControlBox cBox2;
        private Guna.UI2.WinForms.Guna2ControlBox cBox1;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm;
    }
}