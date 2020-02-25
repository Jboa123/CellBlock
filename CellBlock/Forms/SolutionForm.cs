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
    public partial class SolutionForm : Form
    {

        public SolutionForm(List<TextBox> textBoxes)
        {


            InitializeComponent();
            foreach (TextBox txtbox in textBoxes)
            {
                this.Controls.Add(txtbox);
            }
        }



        private void SolutionForm_Load(object sender, EventArgs e)
        {

        }



        private void SaveToSQLDBButton_Click(object sender, EventArgs e)
        {
/*            List<DBData> dataList = SolutionToDB.GetSaveDataList();
            DataAccess.SaveDataToDB(dataList);*/

        }
    }


}
