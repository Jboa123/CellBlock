using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class Iterations : IIterations
    {
        IPossibleBlockRemoval _possibleBlockRemoval;
        IGridAndCellIterations _gridAndCellIterations;
        public Iterations(IPossibleBlockRemoval possibleBlockRemoval, IGridAndCellIterations gridAndCellIterations)
        {
            _possibleBlockRemoval = possibleBlockRemoval;
            _gridAndCellIterations = gridAndCellIterations;
            ChangeHasOccured = false;
            ProvesNoSolution = false;
        }

        public Grid Grid { get; set; }

        public bool ChangeHasOccured { get; set; }
        public bool ProvesNoSolution { get; set; }
        public void IterateUntilStatic()
        {
            ResetNoSolutionBoolsToFalse();

            do
            {
                ResetChangeBoolsTofalse();


                _gridAndCellIterations.ClearCellPossibleIndexs();
                _gridAndCellIterations.FillCellIndex();
                _gridAndCellIterations.CheckAllCellPossibleIndexs();
                _gridAndCellIterations.CheckAllCellMembership();
                _possibleBlockRemoval.RemoveImposBlocksAndsetCertain();



                if (_gridAndCellIterations.ProvesNoSolution || _possibleBlockRemoval.ProvesNoSolution)
                {
                    ProvesNoSolution = true;
                }

                if (_gridAndCellIterations.ChangeHasOccured || _possibleBlockRemoval.ChangeHasOccured)
                {
                    ChangeHasOccured = true;
                }

            } while (ChangeHasOccured);

        }

        private void ResetChangeBoolsTofalse()
        {
            ChangeHasOccured = false;
            _gridAndCellIterations.ChangeHasOccured = false;
            _possibleBlockRemoval.ChangeHasOccured = false;
        }

        private void ResetNoSolutionBoolsToFalse()
        {
            this.ProvesNoSolution = false;
            _gridAndCellIterations.ProvesNoSolution = false;
            _possibleBlockRemoval.ProvesNoSolution = false;
        }

        public void setIterationGrid(Grid grid)
        {
            this.Grid = grid;
            _possibleBlockRemoval.Grid = grid;
            _gridAndCellIterations.Grid = grid;
        }
    }
}
