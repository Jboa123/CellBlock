using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;
using System.Windows.Forms;
namespace CellBlock
{
    public class GUItoData : IGUItoData
    {
        /// <summary>
        /// Holds the first instance of Grid that will have the GUI data copied into it.
        /// </summary>
        public Grid Grid { get; set; }

        /// <summary>
        /// Holds the inital values (representing the block area) as Value and the position of this value in the GUI as the Key
        /// </summary>
        public Dictionary<int, int> PredefinedCells { get; set; } = new Dictionary<int, int>();

        /// <summary>
        /// The information in the List<TextBox> representing the GUI, is converted to the backend data.
        /// Creates a main block foreach Textbox that contains a value. Sets the Blocks Index, Area and DefinedCell
        /// </summary>
        /// <param name="textBoxes"></param>
        public void ReadGUIInput(List<TextBox> textBoxes)
        {
            int blockIndex = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int textBoxIndex = 7 * i + j;
                    TextBox txtbox = textBoxes[textBoxIndex];
                    Cell cell = Grid.Cells[i, j];

                    if (txtbox.Text != "")
                    {
                        int blockArea;
                        blockArea = int.Parse(txtbox.Text);
                        MainBlock MBlock = new MainBlock(blockIndex++, blockArea, cell, Grid);
                        Grid.Blocks.Add(MBlock);
                        cell.SetOwnership(MBlock);
                        PredefinedCells.Add(textBoxIndex,blockArea);

                    }
                }
            }
        }


    }
}
