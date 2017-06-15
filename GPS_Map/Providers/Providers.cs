
namespace GMap.NET.MapProviders
{
    using System;
    using GMap.NET.Projections;


    public abstract class IPTMapProviderBase : GMapProvider
    {

        #region GMapProvider Members
        public override Guid Id
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override PureProjection Projection
        {
            get { return GMap.NET.Projections.MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
        static string UrlFormat= "/{0}/{1}/{2}.png";
        public string EmptyTilePath = "http://192.168.0.50:90/tiles/noisy_grid.png";

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            //throw new NotImplementedException();
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);
            try
            {
                return GetTileImageUsingHttp(url);
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //если не найден возвращать тайл для пустого поля 
                return GetTileImageUsingHttp("http://192.168.0.50:90/tiles/noisy_grid.png");
                //Settings.Option.
            }
        }
        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, zoom, pos.X, pos.Y);
        }
        #endregion
    }

    /// <summary>
    /// gis_ua_loc
    /// </summary>
    public class IPTMap_gis_ua_topo_loc_Map_Provider : IPTMapProviderBase 
//    public class IPTMap_gis_ua_topo_loc_Map_Provider : GMapProvider
    {
        static string UrlFormat;
        public IPTMap_gis_ua_topo_loc_Map_Provider(string tileurl)
        {
            //UrlFormat = "http://localhost:98/tiles/gis_ua_topo" + "/{0}/{1}/{2}.png";
            UrlFormat = tileurl + "/{0}/{1}/{2}.png";
            //InvertedAxisY = true;
            //Area = new RectLatLng(_mbtiles.Bounds.West, _mbtiles.Bounds.North, _mbtiles.Bounds.East, _mbtiles.Bounds.South);
        }

        #region GMapProvider Members

        readonly Guid id = new Guid("354DB2ED-5E7B-44B2-9ACA-5929429208D6");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }

        readonly string name = "IPTMap_gis_ua_topo_loc_Map";
        public override string Name
        {
            get
            {
                return name;
            }
        }
        #endregion
        
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);
            try
            {
                return GetTileImageUsingHttp(url);
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //если не найден возвращать тайл для пустого поля 
                return GetTileImageUsingHttp(EmptyTilePath);
                //Settings.Option.
                
            }
        }
        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, zoom, pos.X, pos.Y);
        }
        
        
    }

    public class ukrweb_Map_Provider : IPTMapProviderBase
    {
        static string UrlFormat;
        public ukrweb_Map_Provider(string tileurl) { UrlFormat = tileurl + "/{0}/{1}/{2}.png"; }
        readonly Guid id = new Guid("E4D3B320-29B3-4883-B871-6887BDAD1213");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }
        readonly string name = "ukrweb_Map_Provider";
        public override string Name
        {
            get
            {
                return name;
            }
        }
        
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);
            try
            {
                return GetTileImageUsingHttp(url);
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //если не найден возвращать тайл для пустого поля 
                return GetTileImageUsingHttp(EmptyTilePath);
                //Settings.Option.

            }

        }

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, zoom, pos.X, pos.Y);
        }
        
    }
    public class kyiv_Map_Provider : IPTMapProviderBase
    {
        static string UrlFormat;
        public kyiv_Map_Provider(string tileurl)
        {
            UrlFormat = tileurl + "/{0}/{1}/{2}.jpg";
        }
        readonly Guid id = new Guid("A88C08D8-D0C7-47BE-899D-2BE554080869");
        public override Guid Id
        {
            get
            {
                return id;
            }
        }
        readonly string name = "kyiv_Map_Provider";
        public override string Name
        {
            get
            {
                return name;
            }
        }
        
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);
            try
            {
                return GetTileImageUsingHttp(url);
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //если не найден возвращать тайл для пустого поля 
                return GetTileImageUsingHttp(EmptyTilePath);
                //Settings.Option.

            }

        }

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, zoom, pos.X, pos.Y);
        }
        
    }

}
