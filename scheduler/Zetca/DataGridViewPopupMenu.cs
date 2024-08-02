using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    public static class DataGridViewPopupMenu
    {
        //// <summary>
        //// Displays a popup menu for a DataGridView control at the specified location.
        ////
        //// Parameters:
        //// - dataGridView: The DataGridView control for which the popup menu should be displayed.
        //// - location: The location where the popup menu should be displayed, relative to the screen.
        //// </summary>
        //public static void ShowPopupMenu(DataGridView dataGridView, Point location)
        //{
        //    // Create a new ContextMenuStrip for the popup menu.
        //    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        //    // Add menu items to the ContextMenuStrip.
        //    ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Copy");
        //    ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Remove Template");

        //    // Add event handlers for the menu items.
        //    menuItem1.Click += (sender, e) => CopySelectedCells(dataGridView);
        //    menuItem2.Click += (sender, e) => DeleteSelectedCells(dataGridView);

        //    // Add the menu items to the ContextMenuStrip.
        //    contextMenuStrip.Items.Add(menuItem1);
        //    contextMenuStrip.Items.Add(menuItem2);

        //    // Show the ContextMenuStrip at the specified location.
        //    contextMenuStrip.Show(location);
        //}

        //// <summary>
        //// Copies the selected cells in the DataGridView to the clipboard.
        ////
        //// Parameters:
        //// - dataGridView: The DataGridView control from which the cells should be copied.
        //// </summary>
        //private static void CopySelectedCells(DataGridView dataGridView)
        //{
        //    // Check if any cells are selected.
        //    if (dataGridView.SelectedCells.Count > 0)
        //    {
        //        // Create a DataObject to hold the copied data.
        //        DataObject dataObject = dataGridView.GetClipboardContent();

        //        // Copy the data to the clipboard.
        //        Clipboard.SetDataObject(dataObject);
        //    }
        //}

        //// <summary>
        //// Deletes the contents of the selected cells in the DataGridView.
        ////
        //// Parameters:
        //// - dataGridView: The DataGridView control from which the cells should be deleted.
        //// </summary>
        //private static void DeleteSelectedCells(DataGridView dataGridView)
        //{
        //    // Check if any cells are selected.
        //    if (dataGridView.SelectedCells.Count > 0)
        //    {
        //        // Clear the contents of the selected cells.
        //        foreach (DataGridViewCell cell in dataGridView.SelectedCells)
        //        {
        //            cell.Value = null;
        //        }
        //    }
        //}
    }
}
