using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class SolvePuzzle : ISolvePuzzle
    {
        IIterations _iterations;
        ICloneGridAndSetBlock _cloneGridAndSetBlock;
        IDisplaySolutionData _displaySolutionData;

        public SolvePuzzle(IDisplaySolutionData displaySolutionData, IIterations iterations, ICloneGridAndSetBlock cloneGridAndSetBlock)
        {
            
            _iterations = iterations;
            _cloneGridAndSetBlock = cloneGridAndSetBlock;
            _displaySolutionData = displaySolutionData;
        }

        private Grid CurrentGrid { get; set; }

        public Queue<Grid> UnsolvedGrids { get; set; } = new Queue<Grid>();

        public void FindAllSolutions()
        {
            while(UnsolvedGrids.Count != 0)
            {
                CurrentGrid = UnsolvedGrids.Dequeue();
                SetNewGrid(CurrentGrid);
                SolveCurrentGrid();
            }
        }
        private void SolveCurrentGrid()
        {


            _iterations.IterateUntilStatic(); // Iterates though removing PossibleBlocks until no change occurs. Cases with no solution are caught here

            if (CurrentGrid.HasSolution)
            {
                _displaySolutionData.SolvedGrids.Add(CurrentGrid);
            }
            else if (_iterations.ProvesNoSolution)
            {
                return;
            }
            else
            {
                List<Grid> TempUnsolvedGridList = _cloneGridAndSetBlock.GetGridsWithSetBlocks();

                foreach(Grid unsolvedGrid in TempUnsolvedGridList)
                {
                    UnsolvedGrids.Enqueue(unsolvedGrid);
                }
                

            }

        }

        private void SetNewGrid(Grid grid)
        {
            this.CurrentGrid = grid;
            _iterations.setIterationGrid(grid);
            _cloneGridAndSetBlock.SetClonesOriginalGrid(grid);
        }
    }
}
