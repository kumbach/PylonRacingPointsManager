using System;
using System.Text;

namespace ClubPylonManager {
  public abstract class AbstractReport {
    protected readonly StringBuilder ReportData;

    protected AbstractReport() {
      ReportData = new StringBuilder();
    }

    public abstract string GenerateReport();

    protected void AddLine(string text) {
      ReportData.Append(text);
      ReportData.Append(Environment.NewLine);
    }

    protected void Add(string text) {
      ReportData.Append(text);
    }

    protected void NewLine() {
      ReportData.Append(Environment.NewLine);
    }
  }
}