using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class SolvePuzzle
    {
        public SolvePuzzle(Grid grid, List<Grid> solvedGridList)
        {
            Grid = grid;
            SolvedGridList = solvedGridList;
        }

        private readonly Grid Grid;
        List<Grid> SolvedGridList = new List<Grid>();

        public void Solve()
        { 

            Iterations iteration = new Iterations(Grid);
            iteration.IterateUntilStatic(); // Iterates though removing PossibleBlocks until no change occurs. Cases with no solution are caught here

            if(Grid.HasSolution)
            {
                SolvedGridList.Add(Grid);
            }else if(iteration.ProvesNoSolution)
            {
                return;

            }else
            {
                MainBlock largestUnsolved = GetLargestUnsolvedMBlock();

                foreach (PossibleBlock possibleBlock in largestUnsolved.PossibleBlocks)
                {
                    DeepCloneGrid cloneGrid = new DeepCloneGrid(Grid);
                    Grid newGrid = cloneGrid.CloneGrid();
                    PossibleBlock toTry = GetEquivalentPossibleBlock(possibleBlock, newGrid);
                    toTry.SetAsMainBlock();

                    SolvePuzzle sol = new SolvePuzzle(newGrid, SolvedGridList);
                    sol.Solve();
                }



            }

        }

        private PossibleBlock GetEquivalentPossibleBlock(PossibleBlock originalPBlock, Grid newGrid)
        {
           int PBlockPosition =  Grid.Blocks[originalPBlock.Index].PossibleBlocks.IndexOf(originalPBlock);
           return newGrid.Blocks[originalPBlock.Index].PossibleBlocks[PBlockPosition];
        }


        private MainBlock GetLargestUnsolvedMBlock()
        {
            MainBlock largestUnsolved = new MainBlock(){Area = 0};
            foreach (MainBlock MBlock in Grid.Blocks)
            {
                if(MBlock.PossibleBlocks.Count!= 1 && MBlock.Area>largestUnsolved.Area)
                {
                    largestUnsolved = MBlock;
                }
            }
            return largestUnsolved;
        }
    }
}
