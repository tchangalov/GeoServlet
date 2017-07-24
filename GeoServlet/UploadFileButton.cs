using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace GeoServlet
{
    internal class UploadFileButton : ArcGIS.Desktop.Framework.Contracts.Button
    {
        protected override void OnClick()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            System.IO.Stream myStream = null;

            openFileDialog1.InitialDirectory = ArcGIS.Desktop.Core.Project.Current.URI;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile() ) != null)
                    {
                        using (myStream)
                        {
                            using (var reader = new System.IO.StreamReader(myStream, Encoding.UTF8))
                            {
                                string value = reader.ReadToEnd();
                                //ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show($"{value}");

                                string uri = ArcGIS.Desktop.Core.Project.Current.URI;

                                string GeoServlet_directory = System.IO.Directory.GetParent(uri) + $"\\GeoServlet";

                                string GeoServlet_file = GeoServlet_directory + $"\\{System.IO.Path.GetFileName(openFileDialog1.FileName)}";

                                System.IO.Directory.CreateDirectory(GeoServlet_directory); // If the directory already exists, this method does nothing.

                                System.IO.FileInfo file = new System.IO.FileInfo(GeoServlet_file);
            
                                System.IO.File.WriteAllText(GeoServlet_file, value);
                            }

                            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";
                            string[] dataArr = null;

                            using (StreamReader r = new StreamReader(config_file))
                            {
                                string data = r.ReadToEnd();
                                dataArr = data.Split(',');
                            }

                            dataArr[2] = System.IO.Path.GetFileName(openFileDialog1.FileName);
                            System.IO.File.WriteAllText(config_file, String.Join(",", dataArr));

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            //ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show()
        }
    }
}
