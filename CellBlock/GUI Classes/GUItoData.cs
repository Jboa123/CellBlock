using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;
using System.Windows.Forms;
namespace _7by7
{
    public class GUItoData
    {

        public GUItoData(Grid grid)
        {
            Grid = grid;
        }

        private Grid Grid { get; set; }

        /// <summary>
        /// The information in the List<TextBox> representing the GUI, is converted to the backend data.
        /// Creates a main block foreach Textbox that contains a value. Sets the Blocks Index, Area and DefinedCell
        /// </summary>
        /// <param name="textBoxes"></param>
        public  void ReadGUIInput(List<TextBox> textBoxes)
        {
            int blockIndex = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    TextBox txtbox = textBoxes[7*i+j];
                    Cell cell = Grid.Cells[i, j];
  
                    if (txtbox.Text != "")
                    {   
                        int blockArea;
                        blockArea = int.Parse(txtbox.Text);
                        MainBlock MBlock = new MainBlock(blockIndex++, blockArea, cell, Grid);
                        Grid.Blocks.Add(MBlock);
                        Grid.PreDefinedCells.Add(cell);
                        cell.SetOwnership(MBlock);

                    }
                }
            }
        }


    }
}
