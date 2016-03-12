using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiamondDash.Entities;
using DiamondDash.Interfaces;

namespace DiamondDash.Helpers
{
    public static class Helper
    {

        public static Diamond InUp(this Diamond diamond)
        {
            int currentIndex = diamond.Index;
            Diamond result = null;
            if (currentIndex > -1 && diamond.Parent != null && currentIndex + 1 < diamond.Parent.Controls.Count)
                result = diamond.Parent.Controls[currentIndex + 1] as Diamond;
            
            return result;                
        }

        public static Diamond InDown(this Diamond diamond)
        {
            
            int currentIndex = diamond.Index;
            Diamond result = null;
            if (currentIndex > 0 && diamond.Parent != null && currentIndex < diamond.Parent.Controls.Count)
                result = diamond.Parent.Controls[currentIndex - 1] as Diamond;
            
            return result;
        }

        public static Diamond InLeft(this Diamond diamond)
        {
            Dashboard board = null;
            Diamond result = null;
            int currentIndex = 0;
            if (diamond.Parent != null)
            {
                board = (diamond.Parent.Parent as Dashboard);

                if (board != null && board.HasChildren)
                {
                    try
                    {
                        currentIndex = board.Controls.GetChildIndex(diamond.Parent);
                    }
                    catch (Exception ex) { currentIndex = -1; System.Diagnostics.Trace.WriteLine(ex.Message); }

                    if (currentIndex > 0 && currentIndex < board.Controls.Count && diamond.Index < board.Controls[currentIndex - 1].Controls.Count)
                        result = board.Controls[currentIndex - 1].Controls[diamond.Index] as Diamond;
                }
            }
            return result;
        }

        public static Diamond InRight(this Diamond diamond)
        {
            Dashboard board = null;
            Diamond result = null; 
            int currentIndex = 0;
            if (diamond.Parent != null)
            {
                board = (diamond.Parent.Parent as Dashboard);

                if (board != null && board.HasChildren)
                {
                    try 
                    {
                        currentIndex = board.Controls.GetChildIndex(diamond.Parent);
                    }
                    catch (Exception ex) { currentIndex = -1; System.Diagnostics.Trace.WriteLine(ex.Message); }

                    if (currentIndex > -1 && currentIndex + 1 < board.Controls.Count && diamond.Index < board.Controls[currentIndex + 1].Controls.Count)
                        result = board.Controls[currentIndex + 1].Controls[diamond.Index] as Diamond;
                }
            }
            return result;
        }

        public static Dashcolumn InLeft(this Dashcolumn column)
        {
            Dashboard board = null;
            Dashcolumn result = null;
            int currentIndex = 0;

            board = (column.Parent as Dashboard);

                if (board != null && board.HasChildren)
                {
                    try
                    {
                        currentIndex = board.Controls.GetChildIndex(column);
                    }
                    catch (Exception ex) { currentIndex = -1; System.Diagnostics.Trace.WriteLine(ex.Message); }

                    if (currentIndex > 0 && currentIndex - 1 < board.Controls.Count)
                        result = board.Controls[currentIndex - 1] as Dashcolumn;
                }
            
            return result;
        }

        public static Dashcolumn InRight(this Dashcolumn column)
        {
            Dashboard board = null;
            Dashcolumn result = null;
            int currentIndex = 0;

            board = (column.Parent as Dashboard);

            if (board != null && board.HasChildren)
            {
                try
                {
                    currentIndex = board.Controls.GetChildIndex(column);
                }
                catch (Exception ex) { currentIndex = -1; System.Diagnostics.Trace.WriteLine(ex.Message); }

                if (currentIndex > -1 && currentIndex + 1 < board.Controls.Count)
                    result = board.Controls[currentIndex + 1] as Dashcolumn;
            }

            return result;
        }



    }
}
