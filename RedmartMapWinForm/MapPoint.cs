using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmartMapWinForm {
  public class MapPoint {
    public int Height { get; set; }
    public int Distance { get { return evaluation == null ? -1 : evaluation.Distance + 1; } }
    public int Steepness { get { return evaluation == null ? -1 : evaluation.Steepness; } }
    public int PointX { get; set; } //additional info, not necessary
    public int PointY { get; set; } //additional info, not necessary
    private MapEvaluation evaluation { get; set; } = new MapEvaluation();
    public bool IsEvaluated { get; set; }

    //All statics are for evaluation
    private static bool mapIsInitialized { get; set; }
    private static List<List<MapPoint>> map;
    public static List<List<MapPoint>> Map { get { return map; }
      set {
        if (value != null)
          mapIsInitialized = true;
        map = value;
      } } //define once for all
    public static int MapX { get; set; }
    public static int MapY { get; set; }
    public static MapPoint MaxPoint {
      get {
        return mapIsInitialized ?
          map.SelectMany(x => x)
            .OrderByDescending(x => x.evaluation.Distance)
            .ThenByDescending(x => x.evaluation.Steepness)
            .FirstOrDefault()
          : null;
      }
    }

    public static MapEvaluation Evaluate(int x, int y) {
      if (!mapIsInitialized)
        return null;

      if (Map[y][x].IsEvaluated)
        return Map[y][x].evaluation;

      MapEvaluation result = new MapEvaluation();
      List<MapEvaluation> evaluations = new List<MapEvaluation>();

      //evaluate left
      if (x > 0 && Map[y][x].Height > Map[y][x - 1].Height) {
        result = Evaluate(x - 1, y);
        evaluations.Add(new MapEvaluation { Distance = result.Distance + 1, Steepness = result.Steepness + Map[y][x].Height - Map[y][x - 1].Height });
      }

      //evaluate right
      if (x < MapX - 1 && Map[y][x].Height > Map[y][x+1].Height) {
        result = Evaluate(x + 1, y);
        evaluations.Add(new MapEvaluation { Distance = result.Distance + 1, Steepness = result.Steepness + Map[y][x].Height - Map[y][x+1].Height });
      }

      //evaluate up
      if (y > 0 && Map[y][x].Height > Map[y-1][x].Height) {
        result = Evaluate(x, y - 1);
        evaluations.Add(new MapEvaluation { Distance = result.Distance + 1, Steepness = result.Steepness + Map[y][x].Height - Map[y - 1][x].Height });
      }

      //evaluate down
      if (y < MapY - 1 && Map[y][x].Height > Map[y + 1][x].Height) {
        result = Evaluate(x, y + 1);
        evaluations.Add(new MapEvaluation { Distance = result.Distance + 1, Steepness = result.Steepness + Map[y][x].Height - Map[y + 1][x].Height });
      }

      Map[y][x].IsEvaluated = true;
      if (evaluations.Count <= 0)
        return Map[y][x].evaluation;

      MapEvaluation maxEvaluation = evaluations
        .OrderByDescending(v => v.Distance)
        .ThenByDescending(v => v.Steepness)
        .FirstOrDefault();

      Map[y][x].evaluation.Distance = maxEvaluation.Distance;
      Map[y][x].evaluation.Steepness = maxEvaluation.Steepness;
      return maxEvaluation;
    }

    public override string ToString() {
      return Height + ", " + IsEvaluated + ", " + evaluation.ToString();
    }
  }

  public class MapEvaluation {
    public int Distance { get; set; }
    public int Steepness { get; set; }

    public override string ToString() {
      return Distance + ", " + Steepness;
    }
  }
}
