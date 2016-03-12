using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiamondDash.Interfaces
{
    public interface IDashboard : IDisposable
    {
        bool Locked { get; set; }
        int ColumnCount { get; }
        int RowCount { get; }
    }
}
