using CellBlockLibrary;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CellBlock
{
    interface IRunFullSolution
    {
        Grid Grid { get; set; }

        void RunSolution(List<TextBox> textBoxes);
        
    }
}