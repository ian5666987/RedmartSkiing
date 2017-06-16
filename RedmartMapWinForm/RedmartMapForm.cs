using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extension.Debugger;
using System.IO;

namespace RedmartMapWinForm {
  //http://geeks.redmart.com/2015/01/07/skiing-in-singapore-a-coding-diversion/
  //http://geeks.redmart.com/2015/10/26/1000000th-customer-prize-another-programming-challenge/
  public partial class RedmartMapForm : Form {
    LogBoxForm logBox = new LogBoxForm(true);
    public RedmartMapForm() {
      InitializeComponent();      
    }

    private void buttonExecute_Click(object sender, EventArgs e) {
      logBox.WriteTimedLogLine("Evaluating map...");
      for (int j = 0; j < MapPoint.MapY; ++j)
        for (int i = 0; i < MapPoint.MapX; ++i)
          MapPoint.Evaluate(i, j);
      MapPoint maxPoint = MapPoint.MaxPoint;
      logBox.WriteTimedLogLine("Map evaluation completed!");
      if (maxPoint != null) {
        logBox.WriteTimedLogLine(maxPoint.ToString());
        textBoxResult.Text = "[" + maxPoint.Distance + ", " + maxPoint.Steepness + "] at (" + 
          maxPoint.PointX + ", " + maxPoint.PointY + ", " + maxPoint.Height + ")";
      }
    }

    private void buttonLoadMap_Click(object sender, EventArgs e) {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.InitialDirectory = Application.StartupPath;
      ofd.Multiselect = false;
      ofd.Filter = "Text files (*.txt)|*.txt";
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      try {
        logBox.WriteTimedLogLine("Opening " + ofd.FileName);
        using (StreamReader reader = new StreamReader(ofd.FileName)) {

          string line = reader.ReadLine();
          string[] sizes = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
          int x_size = int.Parse(sizes[0]);
          int y_size = int.Parse(sizes[1]);

          List<List<MapPoint>> map = new List<List<MapPoint>>(); //LINQ rocks!
          int j = 0;
          while ((line = reader.ReadLine()) != null) {
            int i = 0;
            map.Add(line.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x))
              .Select(x => new MapPoint { Height = int.Parse(x), PointX = i++, PointY = j }).ToList());
            ++j;
          }

          MapPoint.MapX = x_size;
          MapPoint.MapY = y_size;
          MapPoint.Map = map;

          reader.Close();

          labelFileName.Text = ofd.FileName;
          labelMapsize.Text = "Size: " + x_size + " x " + y_size;

          logBox.WriteTimedLogLine("Map loaded sucessfully!");
        }
      } catch (Exception ex) {
        logBox.WriteTimedLogLine(ex.ToString(), Color.Red);
      }
    }
  }
}
