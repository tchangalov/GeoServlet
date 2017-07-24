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
    internal class Menu_Value_button1 : Button
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

            dataArr[0] = "1";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Value_button2 : Button
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

            dataArr[0] = "2";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Value_button3 : Button
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

            dataArr[0] = "3";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Value_button4 : Button
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

            dataArr[0] = "4";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }

    internal class Menu_Value_button5 : Button
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

            dataArr[0] = "5";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button6 : Button
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

            dataArr[0] = "6";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button7 : Button
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

            dataArr[0] = "7";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button8 : Button
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

            dataArr[0] = "8";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button9 : Button
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

            dataArr[0] = "9";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button10 : Button
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

            dataArr[0] = "10";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button15 : Button
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

            dataArr[0] = "15";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button20 : Button
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

            dataArr[0] = "20";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button25 : Button
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

            dataArr[0] = "25";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button30 : Button
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

            dataArr[0] = "30";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button35 : Button
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

            dataArr[0] = "35";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button40 : Button
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

            dataArr[0] = "40";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button45 : Button
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

            dataArr[0] = "45";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button50 : Button
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

            dataArr[0] = "50";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button55 : Button
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

            dataArr[0] = "55";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
    internal class Menu_Value_button60 : Button
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

            dataArr[0] = "60";
            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));
        }
    }
}
