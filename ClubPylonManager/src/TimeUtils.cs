using System;

namespace PylonRacingPointsManager {
  public class TimeUtils {
    private const double MaxTime = 9.0 * 60.0;

    public static string ConvertDoubleTimeToString(double time) {
      if (time <= 0 || time > MaxTime) {
        return "NT";
      }

      double timeval = time;
      int minutes = (int) Math.Floor(time / 60);
      timeval -= minutes * 60;

      int seconds = (int) Math.Floor(timeval);
      timeval -= seconds;

      double hundreths = Math.Round(timeval * 100, 0);

      return $"{minutes:D1}:{seconds:D2}.{(int) hundreths:D2}";
    }

    public static double ConvertHeatStringToSeconds(string heatTime) {
      if (!string.IsNullOrWhiteSpace(heatTime) && heatTime.Length == 7) {
        double.TryParse(heatTime.Substring(0, 1), out var mins);
        double.TryParse(heatTime.Substring(2, 2), out var secs);
        double.TryParse(heatTime.Substring(5), out var huns);

        return (mins * 60.0) + secs + (huns / 100.0);
      }

      return 0;
    }
  }
}