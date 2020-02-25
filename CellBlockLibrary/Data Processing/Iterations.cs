using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class Iterations
    {
        
        public Iterations(Grid grid)
        {
            this.Grid = grid;

            ChangeHasOccured = false;
            ProvesNoSolution = false;
        }

        private readonly Grid Grid;

        private PossibleBlockRemoval PBlockRemove { get; set; }
        private GridAndCellIterations GridAndCell { get; set; }
        public bool ChangeHasOccured { get; set; }
        public bool ProvesNoSolution { get; set; }
        public void IterateUntilStatic()
        {
 
                do
                {
                ChangeHasOccured = false;
                PBlockRemove = new PossibleBlockRemoval(Grid);
                GridAndCell = new GridAndCellIterations(Grid);

                GridAndCell.ClearCellPossibleIndexs();
                GridAndCell.FillCellIndex();
                GridAndCell.CheckAllCellPossibleIndexs();
                GridAndCell.CheckAllCellMembership();
                PBlockRemove.RemoveImposBlocksAndsetCertain();



                if(GridAndCell.ProvesNoSolution || PBlockRemove.ProvesNoSolution)
                {
                    ProvesNoSolution = true;
                }

                if(GridAndCell.ChangeHasOccured || PBlockRemove.ChangeHasOccured)
                {
                    ChangeHasOccured = true;
                }

                } while (ChangeHasOccured);
            
        }

    }
}
