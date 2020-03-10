using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;
using System.Windows.Forms;


namespace CellBlock
{
    class RunFullSolution : IRunFullSolution
    {
        //1 instance for the scope. This object holds a list of all Grid objects that have a solution
        // Also contains a dictionary of all the inputted values and their positions in the grid.
        IDisplaySolutionData _displaySolutionData;

        //Responsible for converting the inputted data to the prgorams data structures.
        IGUItoData _gUItoData;

        //Responsible for creating all the possible block objects
        IPossibleBlockGeneration _PossibleBlockGeneration;

        //Rsponsible for finding all solutions
        ISolvePuzzle _solvePuzzle;
        public RunFullSolution
        (
            IDisplaySolutionData displaySolutionData,
            IGUItoData gUItoData,
            IPossibleBlockGeneration possibleBlockGeneration,
            ISolvePuzzle solvePuzzle
        )
        {
            Grid = new Grid();
            _displaySolutionData = displaySolutionData;
            _gUItoData = gUItoData;
            _PossibleBlockGeneration = possibleBlockGeneration;
            _solvePuzzle = solvePuzzle;
        }
        public Grid Grid { get; set; }

        /// <summary>
        /// The full process.R eading the data inputted into the GUI, converting the data to the backend, finding all the solutions and loading the form to display the solution.
        /// </summary>
        /// <param name="textBoxes"></param>
        public void RunSolution(List<TextBox> textBoxes)
        {
            
            _gUItoData.Grid = Grid;
            _gUItoData.ReadGUIInput(textBoxes);


            _displaySolutionData.PredefinedCells = _gUItoData.PredefinedCells;

            _PossibleBlockGeneration.Grid = Grid;
            _PossibleBlockGeneration.CreateAllPossibleBlock();

            _solvePuzzle.UnsolvedGrids.Enqueue(Grid);
            _solvePuzzle.FindAllSolutions();

             SolutionForm newform = new SolutionForm(_displaySolutionData, new GUIManagement());
            
        }
    }
}
