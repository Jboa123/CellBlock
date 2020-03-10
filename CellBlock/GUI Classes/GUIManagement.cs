using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CellBlockLibrary;

namespace CellBlock
{
    public class GUIManagement : IGUIManagement
    {
        public GUIManagement()
        {
            CreateBlankGUI();
        }
        private List<TextBox> VisualGrid { get; set; } = new List<TextBox>();

        /// <summary>
        /// Creates a list of 49 pain textboxes arranged in a 7x7 square to visually represent the grid.
        /// </summary>
        /// <returns></returns>
        public List<TextBox> CreateBlankGUI()
        {

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    TextBox txtBox = new TextBox();
                    txtBox.Location = new Point(40 * i + 40, 40 * j + 40);
                    txtBox.Name = ("Cell" + i + j);
                    txtBox.Text = "";
                    txtBox.Width = 30;
                    VisualGrid.Add(txtBox);
                }
            }
            return VisualGrid;
        }
        /// <summary>
        /// Takes in a solved grid to display. Each block is given a distinct colour and the orginal values in the cell are displayed.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="PredefinedCells"></param>
        /// <returns></returns>
        public List<TextBox> CreateGUIFromData(Grid grid, Dictionary<int,int> PredefinedCells)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    TextBox txtBox = VisualGrid[7 * i + j];
                    Cell cell = grid.Cells[i, j];
                    int index = cell.OwnedBy;

                    txtBox.BackColor = getColour(index);
                    txtBox.Text = "";

                }
            }

            foreach(KeyValuePair<int,int> KVP in PredefinedCells)
            {
                VisualGrid[KVP.Key].Text = KVP.Value.ToString();
            }
            return VisualGrid;
        }

        /// <summary>
        /// Removes the currenly displayed textboxs from the form, allowing a different se to be displayed
        /// </summary>
        /// <param name="Controls"></param>
        public void ClearTextBoxes(Control.ControlCollection Controls)
        {
            Action<Control.ControlCollection> ClearGui = null;

            ClearGui = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        controls.Remove(control);
                    }
            };

            ClearGui(Controls);
        }

        /// <summary>
        /// Maps integers to a defined colour.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Color getColour(int i)
        {
            switch (i)
            {
                case 1:
                    return Color.Aqua;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.BlueViolet;
                case 4:
                    return Color.Green;
                case 5:
                    return Color.Orange;
                case 6:
                    return Color.Pink;
                case 7:
                    return Color.Olive;
                case 8:
                    return Color.LightGreen;
                case 9:
                    return Color.LightGray;
                case 10:
                    return Color.LightSkyBlue;
                case 11:
                    return Color.LightYellow;
                case 12:
                    return Color.LavenderBlush;
                case 13:
                    return Color.Gold;
                case 14:
                    return Color.Indigo;
                case 15:
                    return Color.LightCyan;
                default:
                    return Color.Beige;

            }
        }
    }
}
