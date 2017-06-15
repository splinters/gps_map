using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Collections;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Net;

namespace GPS_Map
{

//    public static readonly GMap.NET.MapProviders.IPTMap_gis_ua_topo_Map_Provider IPTMap_gis_ua_topo_Map = GMap.NET.MapProviders.IPTMap_gis_ua_topo_Map_Provider.Instance;

    public partial class Form1 : Form
    {

        //Thread _gpsonmap;
        /// <summary>
        /// Class to keep track of string and color for lines in output window.
        /// </summary>
        private class Line
        {
            public string Str;
            public Color ForeColor;

            public Line(string str, Color color)
            {
                Str = str;
                ForeColor = color;
            }
        };

        #region GPRMC 
        /// <summary>
        /// структура записи GPRMC
        /// </summary>
        class GPRMC
        {
            // Поля класса
            public string date;
            public int time;
            public char status;
            public float lat;
            public float lon;
            public float asimuth;
            public float speed;
        }
        //String GPS = "$GPRMC,090232.999,Й,5027.48305,N,03038.02078,E,10.01,900.0,230517,,,A*60";
        GPRMC strGPRMC = new GPRMC();
        //Regex  "$GPRMC"
        /// <summary>
        ///  GGMM.MMMM  to GG.GGGGGG
        /// </summary>
        /// <param name="inp"></param>
        /// <param name="f"></param>
        void Grad(string inp, out float f)
        {
            float fG, fM;
            int posPoint = inp.IndexOf('.');
            string grd = inp.Substring(0, posPoint - 2);
            string min = inp.Substring(posPoint - 2, inp.Length + 2 - posPoint).Replace(".", ",");
            Single.TryParse(grd, out fG);
            Single.TryParse(min, out fM);
            f = fG + (fM / 60);
        }
        /// <summary>
        /// парсинг строки формата GPRMC
        /// "$GPRMC,090232.999,Й,5027.48305,N,03038.02078,E,10.01,900.0,230517,,,A*60"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        GPRMC parseGPRMC(string value)
        {
            GPRMC inputString = new GPRMC();
            float wrk;
            Char delimiter = ',';
            //textBoxComm.AppendText(value);
            try
            {
                String[] substring = value.Split(delimiter);
                //Single.TryParse(substring[1], out inputString.time);
                //date;
                

                inputString.time = Convert.ToInt32(substring[1].Substring(0, substring[1].IndexOf('.') - 1));
                inputString.date = substring[9];
                Grad(substring[3], out inputString.lat);
                Grad(substring[5], out inputString.lon);
                Single.TryParse(substring[8], out inputString.asimuth);
                inputString.status = substring[2][0];
                Single.TryParse(substring[7].Replace(".", ","), out wrk);
                inputString.speed = wrk / 1.852f;
                //Single.TryParse(substring[1].Replace(".", ","), out inputString.time);
            } catch (Exception)
            {
                inputString.status = 'V';
                textBoxComm.AppendText('\n'+value);
               // MessageBox.Show(value + "->"+ ex.Message);
            }
            return inputString;
        }
        #endregion

        ArrayList lines = new ArrayList();

        Font origFont;
        Font monoFont;

        public GMapProvider p_topo, p_ukrweb, p_kyiv;
        public GMapOverlay routes = new GMapOverlay("routes");
        public List<PointLatLng> points = new List<PointLatLng>();

        public Form1()
        {
            InitializeComponent();

            AcceptButton = buttonSend; //Send
            //CancelButton = button4; //Close

            outputList_Initialize();

            Settings.Read();
            TopMost = Settings.Option.StayOnTop;

            // let form use multiple fonts
            origFont = Font;
            FontFamily ff = new FontFamily("Courier New");
            monoFont = new Font(ff, 8, FontStyle.Regular);
            Font = Settings.Option.MonoFont ? monoFont : origFont;

            CommPort com = CommPort.Instance;
            com.StatusChanged += OnStatusChanged;
            com.DataReceived += OnDataReceived;
            com.Open();

            //_gpsonmap = null;
            //_gpsonmap = new Thread(readgps);
        }

        private void readgps()
        {
            //
            //Form1 fm = new Form1();
            //fm.textBoxComm.Text = DateTime.Now.ToShortTimeString();

            TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
            Thread.Sleep(waitTime);
        }

        //Переменная отвечающая за состояние нажатия 
        //левой клавиши мыши.
        private bool isLeftButtonDown = false;

        //Таймер для вывода
        private System.Windows.Forms.Timer blinkTimer = new System.Windows.Forms.Timer();

        //Переменная нового класса,
        //для замены стандартного маркера.
        private GPS_Map.GMapMarkerImage currentMarker;

        //Список маркеров.
        private GMapOverlay markerGPS;
        private GMapOverlay markersOverlay;

        private GMapMarker markerStart;
        private GMapMarker markerFinish;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Настройки для компонента GMap.
            gMap.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            ///с помощью правой кнопки мыши. 
            gMap.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMap.DragButton = MouseButtons.Left;

            gMap.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMap.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMap.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMap.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMap.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMap.NegativeMode = false;

            //Разрешаем полигоны.
            gMap.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMap.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMap.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            //18ти кратной приближение.
            gMap.Zoom = 10;

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            gMap.Dock = DockStyle.Fill;

            //Указываем что будем использовать карты Google.
            //            gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

            //gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.IPTMap_gis_ua_web_Map;
            //            gMap.MapProvider.RefererUrl = "http://192.168.0.115:90";
            //            gMap.MapProvider.ur  // ( = "http://192.168.0.115:90";
            //gMap.MapProvider = 
            //gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.IPTMap_gis_ua_web_Map;
            //                gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.IPTMap_gis_ua_web_loc_Map;

            // проваядеры
            /*
            p_topo   = new IPTMap_gis_ua_topo_loc_Map_Provider("http://localhost:98/tiles/gis_ua_topo");
            p_ukrweb = new IPTMap_gis_ua_topo_loc_Map_Provider("http://localhost:98/tiles/gis_ua_web");
            */
            p_topo = new IPTMap_gis_ua_topo_loc_Map_Provider(Settings.Option.TilePath + "/gis_ua_topo");
            //p_topo.MinZoom = 3; p_topo.MaxZoom = 12;
            p_ukrweb = new ukrweb_Map_Provider( Settings.Option.TilePath + "/gis_ua_web");
            //p_ukrweb
            //p_ukrweb.MinZoom = 9; p_ukrweb.MaxZoom = 12;
            p_kyiv   = new kyiv_Map_Provider(Settings.Option.TilePath + "/Kyivska_Zoom9-14");
            //p_kyiv.MaxZoom = 14; p_kyiv.MinZoom = 9;
            
            gMap.MapProvider = p_ukrweb;
            /*
            gMap.EmptyTileText = "немає даних..";
            gMap.EmptyTileColor = Color.Khaki;
            gMap.FillEmptyTiles = false;
            gMap.EmptyMapBackground = Color.Bisque;
            */
            
            //GMapProvider mbt = new GMap.NET.MapProviders.MBTilesMapProvider(@"D:\Data\Tiles\mbtiles\data\brovari.mbtiles");
            //gMap.MapProvider = mbt;

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy =
                System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials =
                System.Net.CredentialCache.DefaultCredentials;

            //Устанавливаем координаты центра карты для загрузки.
            gMap.Position = new GMap.NET.PointLatLng(50.460071, 30.634861);

            //Создаем новый список маркеров, с указанием компонента 
            //в котором они будут использоваться и названием списка.

            markersOverlay = new GMapOverlay("markersOverlay");
            //markerGPS =    new GMap.NET.WindowsForms.GMapOverlay(gMap, "marker");
            markerGPS = new GMapOverlay("markerGPS");  //gps marker

            //Устанавливаем свои методы на события.
            gMap.OnMapZoomChanged +=
                new MapZoomChanged(mapControl_OnMapZoomChanged);
            gMap.MouseClick +=
                new MouseEventHandler(mapControl_MouseClick);
            gMap.MouseDown +=
                new MouseEventHandler(mapControl_MouseDown);
            gMap.MouseUp +=
                new MouseEventHandler(mapControl_MouseUp);
            gMap.MouseMove +=
                new MouseEventHandler(mapControl_MouseMove);
            gMap.OnMarkerClick +=
                new MarkerClick(mapControl_OnMarkerClick);
            gMap.OnMarkerEnter +=
                new MarkerEnter(mapControl_OnMarkerEnter);
            gMap.OnMarkerLeave +=
                new MarkerLeave(mapControl_OnMarkerLeave);

            //Добавляем в элемент управления карты
            //список маркеров.
            gMap.Overlays.Add(markerGPS);
            gMap.Overlays.Add(markersOverlay);


            routes = new GMapOverlay("routes");

            /*
            
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(48.866383, 2.323575));
            points.Add(new PointLatLng(48.863868, 2.321554));
            points.Add(new PointLatLng(48.861017, 2.330030));
            GMapRoute route = new GMapRoute(points, "A walk in the park");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            gmap.Overlays.Add(routes);*/


            /*
             http://192.168.0.50:98/route/?point=50.2748162,%2030.380176&point=49.037868%2C32.255859&locale=uk&points_encoded=false
             hints
             patchs
             bbox
             points
             snapped_waypoints

                

             
             */
            /*
                        GMapOverlay routes = new GMapOverlay("routes");
                        List<PointLatLng> points = new List<PointLatLng>();
                        points.Add(new PointLatLng(50.2748162, 30.380176));  //$GPRMC,103905.001,A,5027.48162,N,03038.01757,E,00.00,000.0,010617,,,N*7D
                        points.Add(new PointLatLng(50.3,30.3));
                        GMapRoute route = new GMapRoute(points, "test route");
                        route.Stroke = new Pen(Color.Red, 3);
                        routes.Routes.Add(route);
                        gMap.Overlays.Add(routes);
            */

            /*
                        var webClient = new System.Net.WebClient();
                        //WebRequest request = WebRequest.Create(routeUrl + pointUrl);
                        var responseStr = webClient.DownloadString(Settings.Option.RouteUrl+"/route/?point=50.4580268859863,30.6336269378662&point=50.4190189027371,30.4747009277344&locale=uk&points_encoded=false");
                        //WebResponse wr = request.GetResponse();

                        //List<PointLatLng> points = new List<PointLatLng>();

                        JObject jResponse = JObject.Parse(responseStr);
                        JArray jCoordinates = (JArray)jResponse["paths"][0]["points"]["coordinates"];
                        foreach (JToken jcoord in jCoordinates.Children())
                        {
                            double lng = Convert.ToDouble(jcoord[0].ToString().Replace('.', ','));
                            double lat = Convert.ToDouble(jcoord[1].ToString().Replace('.', ','));
                            points.Add(new PointLatLng(lat, lng));
                        }

                        GMapOverlay routes = new GMapOverlay("routes");
                        GMapRoute route = new GMapRoute(points, "test route");
                        route.IsHitTestVisible = true;
                        route.Stroke = new Pen(Color.Red, 3);
                        routes.Routes.Add(route);
                        gMap.Overlays.Add(routes);

                        GMapMarker marker_ = new GMarkerCross(points[0]);
                        routes.Markers.Add(marker_);

                        gMap.ZoomAndCenterRoute(route);
            */



            //Хоча трохи надлишкова, ви можете скористатися наявними можливостями GMAP маршрутів малювати прості лінії. Це також має велику перевагу, що вона дозволяє визначити довжину цієї лінії(в км), якщо це необхідно.Ось як би ви намалювати один рядок:
            /*GMapRoute line_layer;
            GMapOverlay line_overlay

            line_layer = new GMapRoute("single_line");
            line_layer.Stroke = new Pen(Brushes.Black, 2); //width and color of line

            line_overlay.Routes.Add(line_layer);
            gMapControl1.Overlays.Add(line_overlay)

            //Once the layer is created, simply add the two points you want

            line_layer.Points.Add(new PointLatLng(lat, lon));
            line_layer.Points.Add(new PointLatLng(lat2, lon2));

            //Note that if you are using the MouseEventArgs you need to use local coordinates and convert them:
            line_layer.Points.Add(gMapControl1.FromLocalToLatLng(e.X, e.Y));

            //To force the draw, you need to update the route
            gMapControl1.UpdateRouteLocalPosition(line_layer);

            //you can even add markers at the end of the lines by adding markers to the same layer:

            GMapMarker marker_ = new GMarkerCross(p);
            line_overlay.Markers.Add(marker_);*/


        }

        //Метод, отвечающий за перемещение
        //маркера левой клавишей мыши
        //по карте и отображения подсказки с 
        //текущими координатами маркера.
        void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            //Проверка, что нажата левая клавиша мыши.
            if (e.Button == System.Windows.Forms.MouseButtons.Left && isLeftButtonDown)
            {
                if (currentMarker != null)
                {
                    PointLatLng point =
                        gMap.FromLocalToLatLng(e.X, e.Y);
                    //Получение координат маркера.
                    currentMarker.Position = point;
                    //Вывод координат маркера в подсказке.
                    currentMarker.ToolTipText =
                        string.Format("{0},{1}", point.Lat, point.Lng);
                    //if ( currentMarker.Overlay.Id == "markerGPS".ToString() ) 
                    //{
                    //    markerStart.Position = currentMarker.Position;
                    //}
                }
            } 
        }

        void mapControl_MouseUp(object sender, MouseEventArgs e) 
        {
            //Выполняем проверку, какая клавиша мыши была отпущена,
            //если левая, то устанавливаем переменной значение false.
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = false;
            }
        }

        void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            //Выполняем проверку, какая клавиша мыши была нажата,
            //если левая, то устанавливаем переменной значение true.
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = true;
            }
        }

        //Убираем квадрат выделения маркера
        //если нет действий с маркером.
        void mapControl_OnMarkerLeave(GMapMarker item)
        {
            if (item is GMapMarkerImage)
            {
                currentMarker = null;
                GMapMarkerImage m = item as GMapMarkerImage;
                m.Pen.Dispose();
                m.Pen = null;
            }
        }

        //Устанавливаем вокруг маркера красный квадрат
        //если маркер выделен клавишей Enter
        void mapControl_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarkerImage)
            {
                currentMarker = item as GMapMarkerImage;
                currentMarker.Pen = new Pen(Brushes.Red, 2);
            }
        }

        void mapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
        }

        void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            //Выполняем проверку, какая клавиша мыши была нажата,
            //если правая, то выполняем установку маркера.
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Если надо установить только один маркер,
                //то выполняем очистку списка маркеров
                markersOverlay.Markers.Clear();
                PointLatLng point = gMap.FromLocalToLatLng(e.X, e.Y);

                //Инициализируем новую переменную изображения и
                //загружаем в нее изображение маркера,
                //лежащее возле исполняемого файла
                Bitmap bitmap =
//                    Bitmap.FromFile(Application.StartupPath + @"\flag32.png") as Bitmap;
                Bitmap.FromFile(Application.StartupPath + @"\marker.png") as Bitmap;

                //Инициализируем новый маркер с использованием 
                //созданного нами маркера.
                GMapMarker marker = new GMapMarkerImage(point, bitmap);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                //В качестве подсказки к маркеру устанавливаем 
                //координаты где он устанавливается.
                //Данные о местоположении маркера, вы можете вывести в любой компонент
                //который вам нужен.
                //например:
                //textBo1.Text = point.Lat;
                //textBo2.Text = point.Lng;
                marker.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);

                //Добавляем маркер в список маркеров.
                markersOverlay.Markers.Add(marker);

                markerFinish = marker; // маркер финиша
            }
        }
        //Событие изменения масштаба
        void mapControl_OnMapZoomChanged()
        {
        }

        //Запускаем таймер при наведении на маркер
        private void buttonBeginBlink_Click(object sender, EventArgs e)
        {
            //Устанавливаем интервал срабатывания
            //таймера, равным одной секунде.
            blinkTimer.Interval = 1000;

            //Добавляем свое событие на каждое
            //срабатывание таймера.
            blinkTimer.Tick += new EventHandler(blinkTimer_Tick);

            //Запускаем таймер.
            blinkTimer.Start();
        }

        //Отрисовка красного квадрата при наведении на маркер
        void blinkTimer_Tick(object sender, EventArgs e)
        {
            foreach (GMapMarker m in markerGPS.Markers)
            {
                if (m is GMapMarkerImage)
                {
                    GMapMarkerImage marker = m as GMapMarkerImage;
                    if (marker.OutPen == null)
                        //Задаем цвет и ширину линии квадрата,
                        //отображаемого вокруг маркера
                        //на который наведен курсор.
                        marker.OutPen = new Pen(Brushes.Red, 2);
                    else
                    {
                        //Убираем красный квадрат.
                        marker.OutPen.Dispose();
                        marker.OutPen = null;
                    }
                }
            }
            //Перерисовываем карту.
            gMap.Refresh();
        }

        private void buttonStopBlink_Click(object sender, EventArgs e)
        {
            //Останавливаем таймер отображения квадрата.
            blinkTimer.Stop();
            foreach (GMapMarker m in markerGPS.Markers)
            {
                if (m is GMapMarkerImage)
                {
                    GMapMarkerImage marker = m as GMapMarkerImage;
                    marker.OutPen.Dispose();
                    marker.OutPen = null;
                }
            }
            //Перерисовываем карту.
            gMap.Refresh();
        }


//        void mapControl_Addmarker(PointLatLng point)
        GMapMarker mapControl_Addmarker(PointLatLng point)
        {
            //Если надо установить только один маркер,
            //то выполняем очистку списка маркеров
            markersOverlay.Markers.Clear();

                //Инициализируем новую переменную изображения и
                //загружаем в нее изображение маркера,
                //лежащее возле исполняемого файла
                Bitmap bitmap =
//                    Bitmap.FromFile(Application.StartupPath + @"\flag32.png") as Bitmap;
                                Bitmap.FromFile(Application.StartupPath + @"\marker.png") as Bitmap;

                //Инициализируем новый маркер с использованием 
                //созданного нами маркера.
                GMapMarker marker = new GMapMarkerImage(point, bitmap);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                //В качестве подсказки к маркеру устанавливаем 
                //координаты где он устанавливается.
                //Данные о местоположении маркера, вы можете вывести в любой компонент
                //который вам нужен.
                //например:
                //textBo1.Text = point.Lat;
                //textBo2.Text = point.Lng;
                marker.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);

                //Добавляем маркер в список маркеров.
                markersOverlay.Markers.Add(marker);
                
            return marker;
        }

        GMapMarker mapControl_AddGPSmarker(PointLatLng point)
        {
            //Если надо установить только один маркер,
            //то выполняем очистку списка маркеров
            markerGPS.Markers.Clear();

            //Инициализируем новую переменную изображения и
            //загружаем в нее изображение маркера,
            //лежащее возле исполняемого файла
            Bitmap bitmap =
                   Bitmap.FromFile(Application.StartupPath + @"\flag32.png") as Bitmap;
            //                Bitmap.FromFile(Application.StartupPath + @"\marker.png") as Bitmap;

            //Инициализируем новый маркер с использованием 
            //созданного нами маркера.
            GMapMarker marker = new GMapMarkerImage(point, bitmap);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            //В качестве подсказки к маркеру устанавливаем 
            //координаты где он устанавливается.
            //Данные о местоположении маркера, вы можете вывести в любой компонент
            //который вам нужен.
            //например:
            //textBo1.Text = point.Lat;
            //textBo2.Text = point.Lng;
            marker.ToolTipText = string.Format("{0},{1}", point.Lat, point.Lng);

            //Добавляем маркер в список маркеров.
            markerGPS.Markers.Add(marker);
            return marker;
        }

        /// <summary>
        /// output string to log file
        /// </summary>
        /// <param name="stringOut">string to output</param>
        public void logFile_writeLine(string stringOut)
        {
            if (Settings.Option.LogFileName != "")
            {
                Stream myStream = File.Open(Settings.Option.LogFileName,
                    FileMode.Append, FileAccess.Write, FileShare.Read);
                if (myStream != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream, Encoding.UTF8);
                    myWriter.WriteLine(stringOut);
                    myWriter.Close();
                }
            }
        }

        #region Output window

        string filterString = "";
        bool scrolling = true;
        Color receivedColor = Color.Green;
        Color sentColor = Color.Blue;

        /// <summary>
        /// context menu for the output window
        /// </summary>
        ContextMenu popUpMenu;

        /// <summary>
        /// check to see if filter matches string
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns>true if matches filter</returns>
        bool outputList_ApplyFilter(String s)
        {
            if (filterString == "")
            {
                return true;
            }
            else if (s == "")
            {
                return false;
            }
            else if (Settings.Option.FilterUseCase)
            {
                return (s.IndexOf(filterString) != -1);
            }
            else
            {
                string upperString = s.ToUpper();
                string upperFilter = filterString.ToUpper();
                return (upperString.IndexOf(upperFilter) != -1);
            }
        }

        /// <summary>
        /// clear the output window
        /// </summary>
        void outputList_ClearAll()
        {
            lines.Clear();
            partialLine = null;

            outputList.Items.Clear();
        }

        /// <summary>
        /// refresh the output window
        /// </summary>
        void outputList_Refresh()
        {
            outputList.BeginUpdate();
            outputList.Items.Clear();
            foreach (Line line in lines)
            {
                if (outputList_ApplyFilter(line.Str))
                {
                    outputList.Items.Add(line);
                }
            }
            outputList.EndUpdate();
            outputList_Scroll();
        }

        /// <summary>
        /// add a new line to output window
        /// </summary>
        Line outputList_Add(string str, Color color)
        {
            Line newLine = new Line(str, color);
            lines.Add(newLine);

            if (outputList_ApplyFilter(newLine.Str))
            {
                outputList.Items.Add(newLine);
                outputList_Scroll();
            }

            //параллельно отображать на карте координату точки
            if (checkBoxGPSPosition.Checked)
            {

                //String GPS = newLine.Str;
                String GPS = '\r'.ToString()+"$GPRMC,103905.001,A,5027.48162,N,03038.01757,E,00.00,000.0,010617,,,N*7D";
                Regex regexGPS = new Regex(".GPS:");  //, RegexOptions.IgnoreCase)
                Regex regexGPRMC = new Regex("GPRMC");  //, RegexOptions.IgnoreCase)

                GPS = GPS.Replace('\r',' ').Replace('\n',' ').Trim();
                if (regexGPRMC.IsMatch(GPS))
                    {
                    textBoxComm.AppendText(GPS);
                    strGPRMC = parseGPRMC(GPS);
                    labelStatus.Text = strGPRMC.status.ToString();
                    if (strGPRMC.status == 'A')
                    {

                        labelGPS.Text = strGPRMC.lat.ToString() + ":" + strGPRMC.lon.ToString();
                        markerStart = mapControl_AddGPSmarker(new PointLatLng(strGPRMC.lat, strGPRMC.lon));

                        gMap.Position = new GMap.NET.PointLatLng(strGPRMC.lat, strGPRMC.lon);
                        gMap.Zoom = 14;
                        tabControlMap.SelectedIndex = 0;
                        //Перерисовываем карту.
                        gMap.Refresh();
                    } else
                    {

                        //labelGPS.Text = strGPRMC.status.ToString();
                    }
                }
                if (regexGPS.IsMatch(GPS))
                {
                    
                    string[] st = str.Split();
                    //int i = 0;
                    double Lat, Lon;
                    string sc = st[1];
                    sc = sc.Replace(',', ' ').Trim();
                    sc = sc.Replace(',', ' ').Trim().Replace('.', ',');
                    Lat = Convert.ToDouble(sc);
                    sc = st[2].Replace(',', ' ').Trim().Replace('.', ',');
                    Lon = Convert.ToDouble(sc);

                    labelGPS.Text = Lat.ToString() + ":" + Lon.ToString();
                    //marker = new GMapMarker(new PointLatLng(lat, lng));
                    markerStart = mapControl_AddGPSmarker(new PointLatLng(Lat, Lon));
                    //foreach (GMapMarker m in markerGPS.Markers)
                    //MessageBox.Show(Lat.ToString()+" - "+ Lon.ToString());
                    //Устанавливаем координаты центра карты 
                    gMap.Position = new GMap.NET.PointLatLng(Lat, Lon);
                    gMap.Zoom = 14;
                    tabControlMap.SelectedIndex = 0;
                    //Перерисовываем карту.
                    gMap.Refresh();


                }
            }


            return newLine;
        }

        /// <summary>
        /// Update a line in the output window.
        /// </summary>
        /// <param name="line">line to update</param>
        void outputList_Update(Line line)
        {
            // should we add to output?
            if (outputList_ApplyFilter(line.Str))
            {
                // is the line already displayed?
                bool found = false;
                for (int i = 0; i < outputList.Items.Count; ++i)
                {
                    int index = (outputList.Items.Count - 1) - i;
                    if (line == outputList.Items[index])
                    {
                        // is item visible?
                        int itemsPerPage = (int)(outputList.Height / outputList.ItemHeight);
                        if (index >= outputList.TopIndex &&
                            index < (outputList.TopIndex + itemsPerPage))
                        {
                            // is there a way to refresh just one line
                            // without redrawing the entire listbox?
                            // changing the item value has no effect
                            outputList.Refresh();
                        }
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    // not found, so add it
                    outputList.Items.Add(line);
                }
            }
        }

        /// <summary>
        /// Initialize the output window
        /// </summary>
        private void outputList_Initialize()
        {
            // owner draw for listbox so we can add color
            outputList.DrawMode = DrawMode.OwnerDrawFixed;
            outputList.DrawItem += new DrawItemEventHandler(outputList_DrawItem);
            outputList.ClearSelected();

            // build the outputList context menu
            popUpMenu = new ContextMenu();
            popUpMenu.MenuItems.Add("&Copy", new EventHandler(outputList_Copy));
            popUpMenu.MenuItems[0].Visible = true;
            popUpMenu.MenuItems[0].Enabled = false;
            popUpMenu.MenuItems[0].Shortcut = Shortcut.CtrlC;
            popUpMenu.MenuItems[0].ShowShortcut = true;
            popUpMenu.MenuItems.Add("Copy All", new EventHandler(outputList_CopyAll));
            popUpMenu.MenuItems[1].Visible = true;
            popUpMenu.MenuItems.Add("Select &All", new EventHandler(outputList_SelectAll));
            popUpMenu.MenuItems[2].Visible = true;
            popUpMenu.MenuItems[2].Shortcut = Shortcut.CtrlA;
            popUpMenu.MenuItems[2].ShowShortcut = true;
            popUpMenu.MenuItems.Add("Clear Selected", new EventHandler(outputList_ClearSelected));
            popUpMenu.MenuItems[3].Visible = true;
            outputList.ContextMenu = popUpMenu;
        }

        /// <summary>
        /// draw item with color in output window
        /// </summary>
        void outputList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && e.Index < outputList.Items.Count)
            {
                Line line = (Line)outputList.Items[e.Index];

                // if selected, make the text color readable
                Color color = line.ForeColor;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    color = Color.Black;    // make it readable
                }

                e.Graphics.DrawString(line.Str, e.Font, new SolidBrush(color),
                    e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Scroll to bottom of output window
        /// </summary>
        void outputList_Scroll()
        {
            if (scrolling)
            {
                int itemsPerPage = (int)(outputList.Height / outputList.ItemHeight);
                outputList.TopIndex = outputList.Items.Count - itemsPerPage;
            }
        }

        /// <summary>
        /// Enable/Disable copy selection in output window
        /// </summary>
        private void outputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            popUpMenu.MenuItems[0].Enabled = (outputList.SelectedItems.Count > 0);
        }

        /// <summary>
        /// copy selection in output window to clipboard
        /// </summary>
        private void outputList_Copy(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// copy all lines in output window
        /// </summary>
        private void outputList_CopyAll(object sender, EventArgs e)
        {
            int iCount = outputList.Items.Count;
            if (iCount > 0)
            {
                String[] source = new String[iCount];
                for (int i = 0; i < iCount; ++i)
                {
                    source[i] = ((Line)outputList.Items[i]).Str;
                }

                String dest = String.Join("\r\n", source);
                Clipboard.SetText(dest);
            }
        }

        /// <summary>
        /// select all lines in output window
        /// </summary>
        private void outputList_SelectAll(object sender, EventArgs e)
        {
            outputList.BeginUpdate();
            for (int i = 0; i < outputList.Items.Count; ++i)
            {
                outputList.SetSelected(i, true);
            }
            outputList.EndUpdate();
        }

        /// <summary>
        /// clear selected in output window
        /// </summary>
        private void outputList_ClearSelected(object sender, EventArgs e)
        {
            outputList.ClearSelected();
            outputList.SelectedItem = -1;
        }

        #endregion

        #region Event handling - data received and status changed

        /// <summary>
        /// Prepare a string for output by converting non-printable characters.
        /// </summary>
        /// <param name="StringIn">input string to prepare.</param>
        /// <returns>output string.</returns>
        private String PrepareData(String StringIn)
        {
            // The names of the first 32 characters
            string[] charNames = { "NUL", "SOH", "STX", "ETX", "EOT",
                "ENQ", "ACK", "BEL", "BS", "TAB", "LF", "VT", "FF", "CR", "SO", "SI",
                "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB",
                "ESC", "FS", "GS", "RS", "US", "Space"};

            string StringOut = "";

            foreach (char c in StringIn)
            {
                if (Settings.Option.HexOutput)
                {
                    StringOut = StringOut + String.Format("{0:X2} ", (int)c);
                }
                else if (c < 32 && c != 9)
                {
                    StringOut = StringOut + "<" + charNames[c] + ">";

                    //Uglier "Termite" style
                    //StringOut = StringOut + String.Format("[{0:X2}]", (int)c);
                }
                else
                {
                    StringOut = StringOut + c;
                }
            }
            return StringOut;
        }

        /// <summary>
        /// Partial line for AddData().
        /// </summary>
        private Line partialLine = null;

        /// <summary>
        /// Add data to the output.
        /// </summary>
        /// <param name="StringIn"></param>
        /// <returns></returns>
        private Line AddData(String StringIn)
        {
            String StringOut = PrepareData(StringIn);

            // if we have a partial line, add to it.
            if (partialLine != null)
            {
                // tack it on
                partialLine.Str = partialLine.Str + StringOut;
                outputList_Update(partialLine);
                return partialLine;
            }

            return outputList_Add(StringOut, receivedColor);
        }

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);

        /// <summary>
        /// Handle data received event from serial port.
        /// </summary>
        /// <param name="data">incoming data</param>
        public void OnDataReceived(string dataIn)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnDataReceived), new object[] { dataIn });
                return;
            }

            // pause scrolling to speed up output of multiple lines
            bool saveScrolling = scrolling;
            scrolling = false;

            // if we detect a line terminator, add line to output
            int index;
            while (dataIn.Length > 0 &&
                ((index = dataIn.IndexOf("\r")) != -1 ||
                (index = dataIn.IndexOf("\n")) != -1))
            {
                String StringIn = dataIn.Substring(0, index);
                dataIn = dataIn.Remove(0, index + 1);

                logFile_writeLine(AddData(StringIn).Str);
                partialLine = null;	// terminate partial line
            }

            // if we have data remaining, add a partial line
            if (dataIn.Length > 0)
            {
                partialLine = AddData(dataIn);
            }

            // restore scrolling
            scrolling = saveScrolling;
            outputList_Scroll();
        }

        /// <summary>
        /// Update the connection status
        /// </summary>
        public void OnStatusChanged(string status)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }

            textBoxConnection.Text = status;
        }

        #endregion



        private void textBoxConnection_Click(object sender, MouseEventArgs e)
        {
            CommPort com = CommPort.Instance;
            if (com.IsOpen)
            {
                com.Close();
            }
            else
            {
                com.Open();
            }
            outputList.Focus();
        }

        /// <summary>
        /// Change filter
        /// </summary>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            filterString = textBoxFilter.Text;
            outputList_Refresh();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            TopMost = false;

            Form2 form2 = new Form2();
            form2.ShowDialog();

            TopMost = Settings.Option.StayOnTop;
            Font = Settings.Option.MonoFont ? monoFont : origFont;
        }

        private void checkBoxGPS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGPSPosition.Checked)
            {
                //считать координаты и поместить на карту маркер
                //карту переместить к маркеру
                //CommPort com = CommPort.Instance;
                //com.DataReceived
                //_gpsonmap.Start();

                //_gpsonmap.

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TopMost = false;

            AboutBox about = new AboutBox();
            about.ShowDialog();

            TopMost = Settings.Option.StayOnTop;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            outputList_ClearAll();
        }


        private void textBoxConnection_Click(object sender, EventArgs e)
        {
            CommPort com = CommPort.Instance;
            if (com.IsOpen)
            {
                com.Close();
            }
            else
            {
                com.Open();
            }
            outputList.Focus();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            filterString = textBoxFilter.Text;
            outputList_Refresh();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            TopMost = false;

            AboutBox about = new AboutBox();
            about.ShowDialog();

            TopMost = Settings.Option.StayOnTop;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string command = textBoxCommand.Text;
            textBoxCommand.Text = "";
            textBoxCommand.Focus();

            if (command.Length > 0)
            {
                CommPort com = CommPort.Instance;
                com.Send(command);

                if (Settings.Option.LocalEcho)
                {
                    outputList_Add(command + "\n", sentColor);
                }
            }
        }

        private void buttonToggleScrolling_Click(object sender, EventArgs e)
        {
            scrolling = !scrolling;
            outputList_Scroll();
        }

        private void Send_GPS_L_Drozd()
        {
            string command = "GPS L";
            textBoxCommand.Text = "GPS L";
            textBoxCommand.Focus();

            if (command.Length > 0)
            {
                CommPort com = CommPort.Instance;
                com.Send(command);

                if (Settings.Option.LocalEcho)
                {
                    outputList_Add(command + "\n", sentColor);
                }
            }
        }

        private void buttonCicle_Click(object sender, EventArgs e)
        {
            //запустить цикл вычитки координат в цикле
            // погасить элементы настройки
            // создать тред
            //textBoxCommand.Enabled = false;
            textBoxFilter.Text = ".gps";
            Send_GPS_L_Drozd();
            //textBoxCommand.Refresh();
//            buttonSend_Click(sender, e);

            /*
                        System.Threading.Thread.Sleep(50);
                        CommPort com = CommPort.Instance;
                        com.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            */

        }

        private static void DataReceivedHandler(
                                        object sender,
                                        SerialDataReceivedEventArgs e)
        {

            //Regex regex = new Regex(".GPS:");  //, RegexOptions.IgnoreCase)
            //string str = "";
            //System.Threading.Thread.Sleep(500);
        }

        private void radioButtonOpenstreet_CheckedChanged(object sender, EventArgs e)
        {
            gMap.MapProvider = p_topo;
            if ( gMap.Zoom > p_topo.MaxZoom ) { gMap.Zoom = (double) p_topo.MaxZoom; }
        }

        private void radioButtonWeb_CheckedChanged(object sender, EventArgs e)
        {
            gMap.MapProvider = p_ukrweb;
        }

        private void radioButtonKyiv_CheckedChanged(object sender, EventArgs e)
        {
            gMap.MapProvider = p_kyiv;
        }

        private void gMap_OnMapZoomChanged()
        {
            labelZoom.Text = "Zoom: "+gMap.Zoom.ToString();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            gMap.Zoom = ((int)gMap.Zoom) + 1;
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            gMap.Zoom = ((int)gMap.Zoom + 0.99) - 1;
        }

        private void buttonWeb_Click(object sender, EventArgs e)
        {
            //webBrowserMap.Url = System.Uri (buttonWeb.Text);
        }

        private string utf8tocp1251(string str) 
        {
            return Encoding.Default.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Default, Encoding.Default.GetBytes(str)));
        }

        private void buttonRoute_Click(object sender, EventArgs e)
        {
            //построить запрос на сервис маршрутов от точки GPS до точки "куда"

            //            string url = "http://192.168.0.50:98/route/?point=50.2748162,%2030.380176&point=49.037868%2C32.255859&locale=uk&points_encoded=false";

            /*
             
        Adding the route to the map
        Now the MapRoute instance has been created, but it won’t show yet. We’ll need to do two more things: wrap the route up in a GMapRoute instance so that it can be named and shown, and then added it to an overlay. This neatly follows how everything else works in GMap.NET: everything goes into an overlay. So the first thing to check is something doesn’t show up is always, “Did I forget to add it to my overlay?”


        GMapRoute r = new GMapRoute(route.Points, "My route");
        GMapRoute r = new GMapRoute(route.Points, "My route");

         The GMapRoute constructor takes a set of points. This means that although we had our mapping provider calculate the points for us, we could stick in a list of points ourselves, as well. Let’s add the GMapRoute instance to an overlay now, and add the overlay to our map:

        C#
        
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        routesOverlay.Routes.Add(r);
        gmap.Overlays.Add(routesOverlay);
        
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        routesOverlay.Routes.Add(r);
        gmap.Overlays.Add(routesOverlay);             

        Styling the route
        By default, a route is drawn using a fat, semitransparent blue line. This can be changed. The GMapRoute class provides a Stroke member that is an instance of Pen. Beware: do not create a new instance of Pen and assign it to the Stroke member, as this will create a memory leak. Instead, assign the Pen attributes directly like so:


        r.Stroke.Width = 2;
        r.Stroke.Color = Color.SeaGreen;

        r.Stroke.Width = 2;
        r.Stroke.Color = Color.SeaGreen;
        Happy GMap.NET developing!
             
             */

            // markerStart = mapControl_AddGPSmarker(new PointLatLng(50.458269, 30.633616));
            if (markerStart != null)
            {
                try
                {
                    string routeUrl = Settings.Option.RouteUrl;
                    string pointUrl = "/route/?point=" + markerStart.Position.Lat.ToString().Replace(',', '.') + "," + markerStart.Position.Lng.ToString().Replace(',', '.') +
                        "&point=" + markerFinish.Position.Lat.ToString().Replace(',', '.') + "," + markerFinish.Position.Lng.ToString().Replace(',', '.') + "&locale=uk&points_encoded=false";

                    var webClient = new System.Net.WebClient();
                    //WebRequest request = WebRequest.Create(routeUrl + pointUrl);
                    var responseStr = webClient.DownloadString(routeUrl + pointUrl);
                    //WebResponse wr = request.GetResponse();

                    responseStr = Encoding.Default.GetString(Encoding.Convert(Encoding.UTF8, Encoding.Default, Encoding.Default.GetBytes(responseStr)));

                    JObject jResponse = JObject.Parse(responseStr);
                    //JObject jPoints = jResponse[ 1 ]["points"];
                    //JToken  jP = JToken.Parse("patchs");

                    JArray jCoordinates = (JArray)jResponse["paths"][0]["points"]["coordinates"];
                    JArray jBBOX = (JArray)jResponse["paths"][0]["bbox"];
                    JArray jInstructions = (JArray)jResponse["paths"][0]["instructions"];
                    string pointsType = (string)jResponse.SelectToken("paths[0].points.type");

                    //IList<string> CoordList = jCoordinates.ToList();
                    //            foreach (JValue jcoord in jCoordinates.Values())
                    points.Clear(); // очистить коллекцию точек
                    routes.Clear(); // очистить маршрутный оверлей
                                    /*
                                                        foreach (JToken jcoord in jCoordinates.Children())
                                                        {
                                                            //                jcoord.ToString();
                                                            double lng = Convert.ToDouble(jcoord[0].ToString().Replace('.', ','));
                                                            double lat = Convert.ToDouble(jcoord[1].ToString().Replace('.', ','));
                                                            points.Add(new PointLatLng(lat, lng));

                                                        }
                                    */
                    for (int i = 0; i < jCoordinates.Count(); i++)
                    {
                        double lng = Convert.ToDouble(jCoordinates[i][0].ToString().Replace('.', ','));
                        double lat = Convert.ToDouble(jCoordinates[i][1].ToString().Replace('.', ','));
                        points.Add(new PointLatLng(lat, lng));

                        var crossmarker = new GMarkerCross(new PointLatLng(lat, lng));
                        //var marker = new 
                        if (jInstructions.Count() >= i) {
                            try
                            {
                                crossmarker.Tag = jInstructions[i].SelectToken("text").ToString() + " " + jInstructions[i].SelectToken("distance").ToString() + " м.";
                            } catch {
                               // MessageBox.Show(i.ToString());
                            }
                        }
                        crossmarker.ToolTipText = i.ToString();
                        routes.Markers.Add(crossmarker);

                    }


                    //Encoding utf8 = Encoding.GetEncoding("UTF-8");
                    //Encoding win1251 = Encoding.GetEncoding("Windows-1251");
                    listBoxInstructions.Items.Clear();
                    for (int i = 0; i < jInstructions.Count(); i++)
                    {
                        //listBoxInstructions.Items.Add( utf8tocp1251 (jInstructions[i].SelectToken("text").ToString()) + " - " + utf8tocp1251(jInstructions[i].SelectToken("street_name").ToString())) ;
                        //listBoxInstructions.Items.Add(jInstructions[i].SelectToken("text").ToString() + " " + jInstructions[i].SelectToken("distance").ToString() + " м.");

                        var interval = Convert.ToInt16(jInstructions[i].SelectToken("interval")[1].ToString());
//                        MessageBox.Show(interval.ToString() + " " + jCoordinates[i][0].ToString().Replace('.', ',') + ":" + jCoordinates[i][1].ToString().Replace('.', ','));
                        //Инициализируем новую переменную изображения и
                        //загружаем в нее изображение маркера,
                        //лежащее возле исполняемого файла
                        Bitmap bitmap =
                        //                    Bitmap.FromFile(Application.StartupPath + @"\flag32.png") as Bitmap;
                        Bitmap.FromFile(Application.StartupPath + @"\img\" + getRouteSignName(jInstructions[i].SelectToken("sign").ToString()) + ".png") as Bitmap;                        //Инициализируем новый маркер с использованием 
                        //созданного нами маркера.
                        var marker = new GMapMarkerImage(new PointLatLng(Convert.ToDouble(jCoordinates[interval][1].ToString().Replace('.', ',')), Convert.ToDouble(jCoordinates[interval][0].ToString().Replace('.', ','))), bitmap);
                        marker.ToolTipText = jInstructions[i].SelectToken("text").ToString() + " " + jInstructions[i].SelectToken("distance").ToString() + " м.";
                        routes.Markers.Add(marker);

                        listBoxInstructions.Items.Add(
                            getRouteSignName( jInstructions[i].SelectToken("sign").ToString()) + " " +
                            jInstructions[i].SelectToken("text").ToString() + " " + jInstructions[i].SelectToken("distance").ToString() + " м.");

                        // + " - " + jInstructions[i].SelectToken("street_name").ToString());
                        //listBoxInstructions.Items.Add(jInstructions[i].SelectToken("text").ToString());
                        //                    listBoxInstructions.Items.Add(jInstructions[i][4].ToString());
                        //s =  jInstructions[i].SelectToken("distance") + jInstructions[i].SelectToken("sign");
                        //listBoxInstructions.Items.Add(s);

                    }

                    GMapRoute route = new GMapRoute(points, "Маршрут");
                    route.IsHitTestVisible = true;
                    route.Stroke = new Pen(Color.Red, 3);

                    routes.Routes.Clear();
                    routes.Routes.Add(route);
                    gMap.Overlays.Add(routes);

                    GMapMarker marker_ = new GMarkerCross(points[0]);
                    routes.Markers.Add(marker_);
                    gMap.ZoomAndCenterRoute(route);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }


        public string getRouteSignName( string sign)
        {
            if (sign == "-7")
                return "keep_left";
            if (sign == "-3")
                return "sharp_left";
            else if (sign == "-2")
                return "left";
            else if (sign == "-1")
                return "slight_left";
            else if (sign == "0")
                return "continue";
            else if (sign == "1")
                return "slight_right";
            else if (sign == "2")
                return "right";
            else if (sign == "3")
                return "sharp_right";
            else if (sign == "4")
                return "marker-icon-red";
            else if (sign == "5")
                return "marker-icon-blue";
            else if (sign == "6")
                return "roundabout";
            else if (sign == "7")
                return "keep_right";
            else if (sign == "101")
                return "pt_start_trip";
            else if (sign == "102")
                return "pt_transfer_to";
            else if (sign == "103")
                return "pt_end_trip";
            else
                // throw "did not find sign " + sign;
                return "unknown";
        }

        private void gMap_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            if (item is GMapRoute)
            {
                var currentRoute = item as GMapRoute;
                currentRoute.Stroke = new Pen(Brushes.Green, 2);
                //MessageBox.Show(currentRoute.Points.ToString());
                //currentRoute.Overlay.Markers
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommPort com = CommPort.Instance;
            if (com.IsOpen)
            {
                com.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CommPort com = CommPort.Instance;
            //if (com.IsOpen)
            //{
            //    com.Close();
            //}
            
        }

        private void buttonStatic_Click(object sender, EventArgs e)
        {
            StaticImage st = new StaticImage(this);
            st.Owner = this;
            st.Show();
        }
    }
}
