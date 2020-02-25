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
    public partial class _7by7Form : Form
    {
        public _7by7Form()
        {
            InitializeComponent();
            GUIManagement gridGUI = new GUIManagement();
            GUI = gridGUI.CreateBlankGUI();
            foreach(TextBox txtbox in GUI)
            {
                this.Controls.Add(txtbox);
            }

        }

        public List<TextBox> GUI { get; set; }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid();

           // TestCase4();

            GUItoData toData = new GUItoData(grid);
            toData.ReadGUIInput(GUI);       //Sets up Blocks and adds them to Grid.Blocks. Sets DefinedCells

            PossibleBLockGeneration dataIni = new PossibleBLockGeneration(grid);
            dataIni.PopulateCells();        //Creates all the Possible Blocks

            SolutionList Solutions = new SolutionList();

            SolvePuzzle solvePuzzle = new SolvePuzzle(grid, Solutions.SolvedGrids);
            solvePuzzle.Solve();


            foreach (Grid solvedGrid in Solutions.SolvedGrids)
            {
                GUIManagement newForm = new GUIManagement();
                newForm.ShowSolutionForm(solvedGrid);
            }

        }


        private void TestCase1()
        {
            this.Controls["Cell05"].Text = "3";
            this.Controls["Cell11"].Text = "6";
            this.Controls["Cell16"].Text = "4";
            this.Controls["Cell20"].Text = "4";
            this.Controls["Cell24"].Text = "6";
            this.Controls["Cell40"].Text = "2";
            this.Controls["Cell41"].Text = "6";
            this.Controls["Cell46"].Text = "8";
            this.Controls["Cell53"].Text = "7";
            this.Controls["Cell62"].Text = "3";
        }

        private void TestCase2()
        {
            this.Controls["Cell00"].Text = "3";
            this.Controls["Cell04"].Text = "5";
            this.Controls["Cell06"].Text = "2";
            this.Controls["Cell11"].Text = "6";
            this.Controls["Cell32"].Text = "9";
            this.Controls["Cell35"].Text = "6";
            this.Controls["Cell40"].Text = "2";
            this.Controls["Cell54"].Text = "3";
            this.Controls["Cell55"].Text = "4";
            this.Controls["Cell60"].Text = "4";
            this.Controls["Cell62"].Text = "5";
        }

        private void TestCase3()
        {
            this.Controls["Cell01"].Text = "2";
            this.Controls["Cell05"].Text = "5";
            this.Controls["Cell12"].Text = "6";
            this.Controls["Cell16"].Text = "4";
            this.Controls["Cell20"].Text = "6";
            this.Controls["Cell23"].Text = "2";
            this.Controls["Cell24"].Text = "2";
            this.Controls["Cell46"].Text = "6";
            this.Controls["Cell51"].Text = "4";
            this.Controls["Cell54"].Text = "4";
            this.Controls["Cell62"].Text = "4";
            this.Controls["Cell65"].Text = "4";
        }
        private void TestCase4()
        {
            this.Controls["Cell01"].Text = "3";
            this.Controls["Cell04"].Text = "4";
            this.Controls["Cell12"].Text = "4";
            this.Controls["Cell16"].Text = "5";
            this.Controls["Cell20"].Text = "6";
            this.Controls["Cell23"].Text = "3";
            this.Controls["Cell25"].Text = "2";
            this.Controls["Cell32"].Text = "4";
            this.Controls["Cell43"].Text = "6";
            this.Controls["Cell51"].Text = "4";
            this.Controls["Cell52"].Text = "3";
            this.Controls["Cell56"].Text = "2";
            this.Controls["Cell63"].Text = "3";
        }






        private void ViewSavedSolutions_Click(object sender, EventArgs e)
        {
            ViewSavedSolutionsForm newForm = new ViewSavedSolutionsForm();
            newForm.Show();
        }

        private void _7by7Form_Load(object sender, EventArgs e)
        {

        }
    }


}
