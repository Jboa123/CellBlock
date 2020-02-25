using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CellBlockLibrary;

namespace _7by7
{
    public class GUIManagement
    {
        public GUIManagement()
        {
            CreateBlankGUI();
        }
        private List<TextBox> VisualGrid { get; set; } = new List<TextBox>();

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
                    txtBox.Width =30;
                    VisualGrid.Add(txtBox);
                }
            }
            return VisualGrid;
        }

        private List<TextBox> CreateGUIFromData(Grid grid)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    TextBox txtBox = VisualGrid[7*i + j];
                    Cell cell = grid.Cells[i, j];
                    int index = cell.OwnedBy;
                    
                    txtBox.BackColor = getColour(index);
                    txtBox.Text = "";

                    if (grid.PreDefinedCells.Contains(cell))
                    {
                        int initialValue = grid.Blocks[cell.OwnedBy].Area;
                        txtBox.Text = initialValue.ToString();     // shows intials number

        }
                }
            }
            return VisualGrid;
        }

        public void ShowSolutionForm(Grid grid)
        {
            VisualGrid = CreateGUIFromData(grid);
            SolutionForm newForm = new SolutionForm(VisualGrid);
            newForm.Show();
        }

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
