using System.Collections.Generic;
using System.Windows.Forms;
using CellBlockLibrary;

namespace CellBlock
{
    public interface IGUIManagement
    {
        void ClearTextBoxes(Control.ControlCollection Controls);
        List<TextBox> CreateBlankGUI();
        List<TextBox> CreateGUIFromData(Grid grid, Dictionary<int,int> PredefinedCells);
    }
}