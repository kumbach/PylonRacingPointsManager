using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClubPylonManager
{
    public abstract class AbstractReport
    {
        protected StringBuilder rep;

        protected AbstractReport()
        {
            rep = new StringBuilder();
        }

        public abstract string GenerateReport();

        protected void AddLine(string text) {
            rep.Append(text);
            rep.Append(Environment.NewLine);
        }

        protected void Add(string text) {
            rep.Append(text);
        }

        protected void NewLine() {
            rep.Append(Environment.NewLine);
        }

    }
}