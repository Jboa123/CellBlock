using System.Collections.Generic;
using System.Windows.Forms;
using CellBlockLibrary;

namespace CellBlock
{
    public interface IGUItoData
    {
        Dictionary<int,int> PredefinedCells { get; set; }

        Grid Grid { get; set; }

        void ReadGUIInput(List<TextBox> textBoxes);
    }
}