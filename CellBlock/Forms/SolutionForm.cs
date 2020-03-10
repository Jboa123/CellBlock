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


namespace CellBlock
{
    public partial class SolutionForm : Form
    {

        public SolutionForm(IDisplaySolutionData data, IGUIManagement gUIManagement)
        {
            Data = data;
            _gUIManagement = gUIManagement;
            InitializeComponent();

           SolutionsListBox.DataSource = data.GetIndexedList();
           SolutionsListBox.DisplayMember = "Index";


            this.Show();


        }
        private IGUIManagement _gUIManagement;
        private IDisplaySolutionData Data;
        private List<TextBox> txtBoxes;




        private void SolutionForm_Load(object sender, EventArgs e)
        {

        }



        private void SaveToSQLDBButton_Click(object sender, EventArgs e)
        {
/*            List<DBData> dataList = SolutionToDB.GetSaveDataList();
            DataAccess.SaveDataToDB(dataList);*/

        }

        private void SolutionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Grid grid = Data.SolvedGrids[SolutionsListBox.SelectedIndex];
         ///   _gUIManagement.ClearTextBoxes(this.Controls);
            txtBoxes = _gUIManagement.CreateGUIFromData(grid, Data.PredefinedCells);
            foreach (TextBox textBox in txtBoxes)
            {
                this.Controls.Add(textBox);
            }
        }


    }


}
