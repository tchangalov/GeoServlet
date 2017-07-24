using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using System.IO;

namespace GeoServlet
{
    internal class Menu_Unit_button1 : Button
    {
        protected override void OnClick()
        {
            //string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            //string[] dataArr = null;

            //using (StreamReader r = new StreamReader(config_file))
            //{
            //    string data = r.ReadToEnd();
            //    dataArr = data.Split(',');
            //}

            //dataArr[1] = "sec";
            //System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Unit_button2 : Button
    {
        protected override void OnClick()
        {
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            string[] dataArr = null;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
            }

            dataArr[1] = "min";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Unit_button3 : Button
    {
        protected override void OnClick()
        {
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            string[] dataArr = null;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
            }

            dataArr[1] = "hour";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Unit_button4 : Button
    {
        protected override void OnClick()
        {
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            string[] dataArr = null;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
            }

            dataArr[1] = "day";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Unit_button5 : Button
    {
        protected override void OnClick()
        {
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            string[] dataArr = null;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
            }

            dataArr[1] = "week";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Unit_button6 : Button
    {
        protected override void OnClick()
        {
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
            string[] dataArr = null;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
            }

            dataArr[1] = "month";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

}
