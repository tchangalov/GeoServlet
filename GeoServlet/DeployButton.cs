using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using Microsoft.Win32.TaskScheduler;

namespace GeoServlet
{
    internal class DeployButton : Button
    {

        protected override void OnClick()
        {
          
            string config_file = System.IO.Directory.GetParent(ArcGIS.Desktop.Core.Project.Current.URI) + $"\\GeoServlet\\config.txt";

            // declare variables beforehand 
            string[] dataArr = null;
            string uri, GeoServlet_directory, GeoServlet_file;

            using (StreamReader r = new StreamReader(config_file))
            {
                string data = r.ReadToEnd();
                dataArr = data.Split(',');
                uri = ArcGIS.Desktop.Core.Project.Current.URI;
                GeoServlet_directory = System.IO.Directory.GetParent(uri) + $"\\GeoServlet";
                GeoServlet_file = GeoServlet_directory + $"\\{dataArr[2]}";
            }

            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();

                td.RegistrationInfo.Description = $"Creating scheduled task for {dataArr[2]}, running every {dataArr[0]} {dataArr[1]}";

                var trigger = new TimeTrigger();

                if (dataArr[1] == "min")
                {
                    trigger.Repetition.Interval = TimeSpan.FromMinutes(Convert.ToInt32(dataArr[0]));
                }
                else if (dataArr[1] == "hour")
                {
                    trigger.Repetition.Interval = TimeSpan.FromHours(Convert.ToInt32(dataArr[0]));
                }
                else if (dataArr[1] == "day")
                {
                    trigger.Repetition.Interval = TimeSpan.FromDays(Convert.ToInt32(dataArr[0]));
                }

                else if (dataArr[1] == "week")
                {
                    trigger.Repetition.Interval = TimeSpan.FromDays(Convert.ToInt32(dataArr[0])*7);
                }

                else if (dataArr[1] == "month")
                {
                    trigger.Repetition.Interval = TimeSpan.FromDays(Convert.ToInt32(dataArr[0]) * 30);
                }

                else
                {
                    throw new Exception();
                }

                td.Settings.Hidden = true;

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(trigger);

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(GeoServlet_file, null, GeoServlet_directory));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition("task_" + dataArr[2] + "_" + Guid.NewGuid(), td);

                ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show($"Configuration Successful for {dataArr[2]}");
            }
        }
    }
}
