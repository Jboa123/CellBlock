using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellBlockLibrary;

namespace _7by7
{
    public partial class ViewSavedSolutionsForm : Form
    {
        public ViewSavedSolutionsForm()
        {
            InitializeComponent();
            SavedSolutionsListBox.DataSource = DataAccess.GetUniqueIDList();

        }



        private List<TextBox> GUI = new List<TextBox>();
        public GUIManagement DS { get; set; } = new GUIManagement();

/*        private void SavedSolutionsListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Grid.ResetGrid();
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    Controls.Remove(ctrl);
                }
            }
            ListBox LBox = SavedSolutionsListBox;
            SolutionFromDB.LoadDataFromID(int.Parse(LBox.SelectedItem.ToString()));
            SolutionFromDB.DataToGrid();
            GUI = DS.CreateGUIFromData();

            foreach(TextBox txtBox in GUI)
            {
                this.Controls.Add(txtBox);
            }

        }*/

        private void ViewSavedSolutionsForm_Load(object sender, EventArgs e)
        {

        }

        private void ViewSolutionButton_Click(object sender, EventArgs e)
        {

        }
    }
}
