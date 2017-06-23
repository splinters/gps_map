namespace GPS_Map
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("старт", 4);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainerMap = new System.Windows.Forms.SplitContainer();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.buttonRoute = new System.Windows.Forms.Button();
            this.labelZoom = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewRouting = new System.Windows.Forms.ListView();
            this.columnHeaderInstructions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListRouteSign = new System.Windows.Forms.ImageList(this.components);
            this.textBoxComm = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAto = new System.Windows.Forms.RadioButton();
            this.radioButtonWeb = new System.Windows.Forms.RadioButton();
            this.radioButtonTopo = new System.Windows.Forms.RadioButton();
            this.radioButtonKyiv = new System.Windows.Forms.RadioButton();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelGPS = new System.Windows.Forms.Label();
            this.checkBoxGPSPosition = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEmulation = new System.Windows.Forms.Button();
            this.tabControlMap = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPageGPS = new System.Windows.Forms.TabPage();
            this.outputList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCicle = new System.Windows.Forms.Button();
            this.buttonToggleScrolling = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.textBoxConnection = new System.Windows.Forms.TextBox();
            this.tabPageBrowser = new System.Windows.Forms.TabPage();
            this.webBrowserMap = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonWeb = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMap)).BeginInit();
            this.splitContainerMap.Panel1.SuspendLayout();
            this.splitContainerMap.Panel2.SuspendLayout();
            this.splitContainerMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControlMap.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.tabPageGPS.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.tabPageBrowser.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMap
            // 
            this.splitContainerMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMap.Location = new System.Drawing.Point(3, 2);
            this.splitContainerMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMap.Name = "splitContainerMap";
            // 
            // splitContainerMap.Panel1
            // 
            this.splitContainerMap.Panel1.Controls.Add(this.gMap);
            // 
            // splitContainerMap.Panel2
            // 
            this.splitContainerMap.Panel2.Controls.Add(this.buttonRoute);
            this.splitContainerMap.Panel2.Controls.Add(this.labelZoom);
            this.splitContainerMap.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerMap.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerMap.Panel2.Controls.Add(this.buttonZoomOut);
            this.splitContainerMap.Panel2.Controls.Add(this.buttonZoomIn);
            this.splitContainerMap.Panel2.Controls.Add(this.labelStatus);
            this.splitContainerMap.Panel2.Controls.Add(this.labelGPS);
            this.splitContainerMap.Panel2.Controls.Add(this.checkBoxGPSPosition);
            this.splitContainerMap.Panel2.Controls.Add(this.panel3);
            this.splitContainerMap.Size = new System.Drawing.Size(813, 637);
            this.splitContainerMap.SplitterDistance = 542;
            this.splitContainerMap.TabIndex = 1;
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(542, 637);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            this.gMap.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gMap_OnRouteClick);
            this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMap_OnMapZoomChanged);
            // 
            // buttonRoute
            // 
            this.buttonRoute.Location = new System.Drawing.Point(15, 250);
            this.buttonRoute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(77, 26);
            this.buttonRoute.TabIndex = 8;
            this.buttonRoute.Text = "Маршрут";
            this.buttonRoute.UseVisualStyleBackColor = true;
            this.buttonRoute.Click += new System.EventHandler(this.buttonRoute_Click);
            // 
            // labelZoom
            // 
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(12, 228);
            this.labelZoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(42, 17);
            this.labelZoom.TabIndex = 2;
            this.labelZoom.Text = "zoom";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 282);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewRouting);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxComm);
            this.splitContainer1.Size = new System.Drawing.Size(267, 355);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 9;
            // 
            // listViewRouting
            // 
            this.listViewRouting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInstructions});
            this.listViewRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listViewRouting.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewRouting.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listViewRouting.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewRouting.Location = new System.Drawing.Point(0, 0);
            this.listViewRouting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewRouting.MultiSelect = false;
            this.listViewRouting.Name = "listViewRouting";
            this.listViewRouting.Size = new System.Drawing.Size(267, 234);
            this.listViewRouting.SmallImageList = this.imageListRouteSign;
            this.listViewRouting.TabIndex = 3;
            this.listViewRouting.UseCompatibleStateImageBehavior = false;
            this.listViewRouting.View = System.Windows.Forms.View.Details;
            this.listViewRouting.SelectedIndexChanged += new System.EventHandler(this.listViewRouting_SelectedIndexChanged);
            // 
            // columnHeaderInstructions
            // 
            this.columnHeaderInstructions.Text = "Маршрутний лист";
            this.columnHeaderInstructions.Width = 441;
            // 
            // imageListRouteSign
            // 
            this.imageListRouteSign.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRouteSign.ImageStream")));
            this.imageListRouteSign.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListRouteSign.Images.SetKeyName(0, "alt_route.png");
            this.imageListRouteSign.Images.SetKeyName(1, "continue.png");
            this.imageListRouteSign.Images.SetKeyName(2, "gpx.png");
            this.imageListRouteSign.Images.SetKeyName(3, "left.png");
            this.imageListRouteSign.Images.SetKeyName(4, "marker-from.png");
            this.imageListRouteSign.Images.SetKeyName(5, "marker-icon-blue.png");
            this.imageListRouteSign.Images.SetKeyName(6, "marker-icon-green.png");
            this.imageListRouteSign.Images.SetKeyName(7, "marker-icon-red.png");
            this.imageListRouteSign.Images.SetKeyName(8, "marker-small-blue.png");
            this.imageListRouteSign.Images.SetKeyName(9, "marker-small-green.png");
            this.imageListRouteSign.Images.SetKeyName(10, "marker-small-red.png");
            this.imageListRouteSign.Images.SetKeyName(11, "marker-to.png");
            this.imageListRouteSign.Images.SetKeyName(12, "pt_end_trip.png");
            this.imageListRouteSign.Images.SetKeyName(13, "pt_start_trip.png");
            this.imageListRouteSign.Images.SetKeyName(14, "pt_transfer_to.png");
            this.imageListRouteSign.Images.SetKeyName(15, "right.png");
            this.imageListRouteSign.Images.SetKeyName(16, "roundabout.png");
            this.imageListRouteSign.Images.SetKeyName(17, "sharp_left.png");
            this.imageListRouteSign.Images.SetKeyName(18, "sharp_right.png");
            this.imageListRouteSign.Images.SetKeyName(19, "slight_left.png");
            this.imageListRouteSign.Images.SetKeyName(20, "slight_right.png");
            this.imageListRouteSign.Images.SetKeyName(21, "unknown.png");
            // 
            // textBoxComm
            // 
            this.textBoxComm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxComm.Location = new System.Drawing.Point(0, 0);
            this.textBoxComm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxComm.Multiline = true;
            this.textBoxComm.Name = "textBoxComm";
            this.textBoxComm.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxComm.Size = new System.Drawing.Size(267, 117);
            this.textBoxComm.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonAto);
            this.groupBox1.Controls.Add(this.radioButtonWeb);
            this.groupBox1.Controls.Add(this.radioButtonTopo);
            this.groupBox1.Controls.Add(this.radioButtonKyiv);
            this.groupBox1.Location = new System.Drawing.Point(44, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(218, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basemaps";
            // 
            // radioButtonAto
            // 
            this.radioButtonAto.AutoSize = true;
            this.radioButtonAto.Location = new System.Drawing.Point(8, 108);
            this.radioButtonAto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAto.Name = "radioButtonAto";
            this.radioButtonAto.Size = new System.Drawing.Size(95, 21);
            this.radioButtonAto.TabIndex = 3;
            this.radioButtonAto.Text = "Зона АТО";
            this.radioButtonAto.UseVisualStyleBackColor = true;
            this.radioButtonAto.CheckedChanged += new System.EventHandler(this.radioButtonAto_CheckedChanged);
            // 
            // radioButtonWeb
            // 
            this.radioButtonWeb.AutoSize = true;
            this.radioButtonWeb.Checked = true;
            this.radioButtonWeb.Location = new System.Drawing.Point(8, 52);
            this.radioButtonWeb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonWeb.Name = "radioButtonWeb";
            this.radioButtonWeb.Size = new System.Drawing.Size(106, 21);
            this.radioButtonWeb.TabIndex = 2;
            this.radioButtonWeb.TabStop = true;
            this.radioButtonWeb.Text = "ІПТ Україна";
            this.radioButtonWeb.UseVisualStyleBackColor = true;
            this.radioButtonWeb.CheckedChanged += new System.EventHandler(this.radioButtonWeb_CheckedChanged);
            // 
            // radioButtonTopo
            // 
            this.radioButtonTopo.AutoSize = true;
            this.radioButtonTopo.Location = new System.Drawing.Point(8, 23);
            this.radioButtonTopo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTopo.Name = "radioButtonTopo";
            this.radioButtonTopo.Size = new System.Drawing.Size(62, 21);
            this.radioButtonTopo.TabIndex = 1;
            this.radioButtonTopo.Text = "Топо";
            this.radioButtonTopo.UseVisualStyleBackColor = true;
            this.radioButtonTopo.CheckedChanged += new System.EventHandler(this.radioButtonOpenstreet_CheckedChanged);
            // 
            // radioButtonKyiv
            // 
            this.radioButtonKyiv.AutoSize = true;
            this.radioButtonKyiv.Location = new System.Drawing.Point(8, 80);
            this.radioButtonKyiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonKyiv.Name = "radioButtonKyiv";
            this.radioButtonKyiv.Size = new System.Drawing.Size(85, 21);
            this.radioButtonKyiv.TabIndex = 0;
            this.radioButtonKyiv.Text = "Київська";
            this.radioButtonKyiv.UseVisualStyleBackColor = true;
            this.radioButtonKyiv.CheckedChanged += new System.EventHandler(this.radioButtonKyiv_CheckedChanged);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonZoomOut.Location = new System.Drawing.Point(7, 49);
            this.buttonZoomOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(32, 30);
            this.buttonZoomOut.TabIndex = 7;
            this.buttonZoomOut.Text = " -";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonZoomIn.Location = new System.Drawing.Point(7, 12);
            this.buttonZoomIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(32, 30);
            this.buttonZoomIn.TabIndex = 6;
            this.buttonZoomIn.Text = " + ";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Location = new System.Drawing.Point(15, 198);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(42, 19);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "-- : --";
            // 
            // labelGPS
            // 
            this.labelGPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGPS.AutoSize = true;
            this.labelGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelGPS.Location = new System.Drawing.Point(15, 172);
            this.labelGPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGPS.Name = "labelGPS";
            this.labelGPS.Size = new System.Drawing.Size(42, 19);
            this.labelGPS.TabIndex = 4;
            this.labelGPS.Text = "-- : --";
            // 
            // checkBoxGPSPosition
            // 
            this.checkBoxGPSPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxGPSPosition.AutoSize = true;
            this.checkBoxGPSPosition.Location = new System.Drawing.Point(52, 149);
            this.checkBoxGPSPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxGPSPosition.Name = "checkBoxGPSPosition";
            this.checkBoxGPSPosition.Size = new System.Drawing.Size(119, 21);
            this.checkBoxGPSPosition.TabIndex = 0;
            this.checkBoxGPSPosition.Text = "GPS Позиція ";
            this.checkBoxGPSPosition.UseVisualStyleBackColor = true;
            this.checkBoxGPSPosition.CheckedChanged += new System.EventHandler(this.checkBoxGPS_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEmulation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 282);
            this.panel3.TabIndex = 10;
            // 
            // buttonEmulation
            // 
            this.buttonEmulation.Location = new System.Drawing.Point(12, 114);
            this.buttonEmulation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEmulation.Name = "buttonEmulation";
            this.buttonEmulation.Size = new System.Drawing.Size(27, 28);
            this.buttonEmulation.TabIndex = 0;
            this.buttonEmulation.Text = "Е";
            this.toolTip1.SetToolTip(this.buttonEmulation, "Емуляція отримання координати GPS");
            this.buttonEmulation.UseVisualStyleBackColor = true;
            this.buttonEmulation.Click += new System.EventHandler(this.buttonEmulation_Click);
            // 
            // tabControlMap
            // 
            this.tabControlMap.Controls.Add(this.tabPageMap);
            this.tabControlMap.Controls.Add(this.tabPageGPS);
            this.tabControlMap.Controls.Add(this.tabPageBrowser);
            this.tabControlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMap.Location = new System.Drawing.Point(0, 0);
            this.tabControlMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMap.Name = "tabControlMap";
            this.tabControlMap.SelectedIndex = 0;
            this.tabControlMap.Size = new System.Drawing.Size(827, 670);
            this.tabControlMap.TabIndex = 2;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.splitContainerMap);
            this.tabPageMap.Location = new System.Drawing.Point(4, 25);
            this.tabPageMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageMap.Size = new System.Drawing.Size(819, 641);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Карта";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // tabPageGPS
            // 
            this.tabPageGPS.Controls.Add(this.outputList);
            this.tabPageGPS.Controls.Add(this.panel1);
            this.tabPageGPS.Controls.Add(this.panelMenu);
            this.tabPageGPS.Location = new System.Drawing.Point(4, 25);
            this.tabPageGPS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageGPS.Name = "tabPageGPS";
            this.tabPageGPS.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageGPS.Size = new System.Drawing.Size(819, 641);
            this.tabPageGPS.TabIndex = 1;
            this.tabPageGPS.Text = "GPS термінал";
            this.tabPageGPS.UseVisualStyleBackColor = true;
            // 
            // outputList
            // 
            this.outputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputList.FormattingEnabled = true;
            this.outputList.HorizontalScrollbar = true;
            this.outputList.IntegralHeight = false;
            this.outputList.ItemHeight = 16;
            this.outputList.Location = new System.Drawing.Point(3, 48);
            this.outputList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputList.Name = "outputList";
            this.outputList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.outputList.Size = new System.Drawing.Size(813, 516);
            this.outputList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCicle);
            this.panel1.Controls.Add(this.buttonToggleScrolling);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSend);
            this.panel1.Controls.Add(this.textBoxCommand);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 564);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 75);
            this.panel1.TabIndex = 2;
            // 
            // buttonCicle
            // 
            this.buttonCicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCicle.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonCicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCicle.Location = new System.Drawing.Point(740, 43);
            this.buttonCicle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCicle.Name = "buttonCicle";
            this.buttonCicle.Size = new System.Drawing.Size(67, 28);
            this.buttonCicle.TabIndex = 14;
            this.buttonCicle.Text = "Q";
            this.buttonCicle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCicle.UseVisualStyleBackColor = true;
            this.buttonCicle.Click += new System.EventHandler(this.buttonCicle_Click);
            // 
            // buttonToggleScrolling
            // 
            this.buttonToggleScrolling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToggleScrolling.Location = new System.Drawing.Point(658, 10);
            this.buttonToggleScrolling.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonToggleScrolling.Name = "buttonToggleScrolling";
            this.buttonToggleScrolling.Size = new System.Drawing.Size(147, 28);
            this.buttonToggleScrolling.TabIndex = 13;
            this.buttonToggleScrolling.Text = "Скролинг";
            this.buttonToggleScrolling.UseVisualStyleBackColor = true;
            this.buttonToggleScrolling.Click += new System.EventHandler(this.buttonToggleScrolling_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Команда:";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSend.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonSend.Location = new System.Drawing.Point(659, 42);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(67, 28);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommand.Location = new System.Drawing.Point(99, 46);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(553, 24);
            this.textBoxCommand.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Фільтр:";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilter.Location = new System.Drawing.Point(99, 14);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(553, 24);
            this.textBoxFilter.TabIndex = 8;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonAbout);
            this.panelMenu.Controls.Add(this.button2);
            this.panelMenu.Controls.Add(this.buttonSet);
            this.panelMenu.Controls.Add(this.textBoxConnection);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(3, 2);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(813, 46);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(749, 6);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(56, 28);
            this.buttonAbout.TabIndex = 4;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(658, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Очистити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSet.Location = new System.Drawing.Point(433, 6);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(137, 28);
            this.buttonSet.TabIndex = 2;
            this.buttonSet.Text = "Налаштування";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // textBoxConnection
            // 
            this.textBoxConnection.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxConnection.Location = new System.Drawing.Point(9, 7);
            this.textBoxConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxConnection.Name = "textBoxConnection";
            this.textBoxConnection.ReadOnly = true;
            this.textBoxConnection.Size = new System.Drawing.Size(416, 26);
            this.textBoxConnection.TabIndex = 0;
            this.textBoxConnection.Click += new System.EventHandler(this.textBoxConnection_Click);
            // 
            // tabPageBrowser
            // 
            this.tabPageBrowser.Controls.Add(this.webBrowserMap);
            this.tabPageBrowser.Controls.Add(this.panel2);
            this.tabPageBrowser.Location = new System.Drawing.Point(4, 25);
            this.tabPageBrowser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBrowser.Name = "tabPageBrowser";
            this.tabPageBrowser.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBrowser.Size = new System.Drawing.Size(819, 641);
            this.tabPageBrowser.TabIndex = 2;
            this.tabPageBrowser.Text = "Browser";
            this.tabPageBrowser.UseVisualStyleBackColor = true;
            // 
            // webBrowserMap
            // 
            this.webBrowserMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserMap.Location = new System.Drawing.Point(3, 414);
            this.webBrowserMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowserMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMap.Name = "webBrowserMap";
            this.webBrowserMap.Size = new System.Drawing.Size(813, 225);
            this.webBrowserMap.TabIndex = 0;
            this.webBrowserMap.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonWeb);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 42);
            this.panel2.TabIndex = 1;
            // 
            // buttonWeb
            // 
            this.buttonWeb.Location = new System.Drawing.Point(440, 2);
            this.buttonWeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWeb.Name = "buttonWeb";
            this.buttonWeb.Size = new System.Drawing.Size(73, 25);
            this.buttonWeb.TabIndex = 1;
            this.buttonWeb.Text = "go";
            this.buttonWeb.UseVisualStyleBackColor = true;
            this.buttonWeb.Click += new System.EventHandler(this.buttonWeb_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(424, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "http://91.218.192.103:88/pfolio/leaf1/grouplayer.html";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 670);
            this.Controls.Add(this.tabControlMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS термінал з картами";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerMap.Panel1.ResumeLayout(false);
            this.splitContainerMap.Panel2.ResumeLayout(false);
            this.splitContainerMap.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMap)).EndInit();
            this.splitContainerMap.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControlMap.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.tabPageGPS.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.tabPageBrowser.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.SplitContainer splitContainerMap;
        private System.Windows.Forms.CheckBox checkBoxGPSPosition;
        private System.Windows.Forms.TabControl tabControlMap;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.TabPage tabPageGPS;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.TextBox textBoxConnection;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToggleScrolling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ListBox outputList;
        private System.Windows.Forms.Button buttonCicle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonWeb;
        private System.Windows.Forms.RadioButton radioButtonTopo;
        private System.Windows.Forms.RadioButton radioButtonKyiv;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.TextBox textBoxComm;
        private System.Windows.Forms.Label labelGPS;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.TabPage tabPageBrowser;
        private System.Windows.Forms.WebBrowser webBrowserMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonWeb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonRoute;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEmulation;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ImageList imageListRouteSign;
        private System.Windows.Forms.ListView listViewRouting;
        private System.Windows.Forms.ColumnHeader columnHeaderInstructions;
        private System.Windows.Forms.RadioButton radioButtonAto;
    }
}

