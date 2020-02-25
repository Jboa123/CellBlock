using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    public class PossibleBLockGeneration
    {
        public PossibleBLockGeneration(Grid grid)
        {
            Grid = grid;
        }
        private readonly Grid Grid;

        public void PopulateCells()
        {
            foreach (MainBlock MBlock in Grid.Blocks)
            {
                      CreatePossibleBlocks(MBlock);   // creates a list of all possible blocks for a block index. does not add blocks off the grid or blocks containing a different block index
            }
        }


        private void CreatePossibleBlocks(MainBlock MBlock)
        {
            List<int[]> PossibleDimensions = FillPossibleDimensions(MBlock);
            foreach (int[] dimension in PossibleDimensions)
            {
                int xOffset = dimension[0]-1, yOffset = dimension[1]-1;

                for (int i = -xOffset; i <= 0; i++)
                {
                    for (int j = -yOffset; j <= 0; j++)
                    {
                        CreatePossibleBlock(i, j, dimension[0], dimension[1], MBlock);
                    }

                }
            }
        }


        /// <summary>
        /// Creates a possible block by adding cells to a collection. If all the cells are lie within the grid and are not owned by another block, the possible block is valid.
        /// If the possible block is valid it is created and added to the relevant Block.PossibleBlocks
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="xDim"></param>
        /// <param name="yDim"></param>
        private void CreatePossibleBlock(int i, int j, int xDim, int yDim, MainBlock block)
        {
            //xPos and yPos represent coordinates of the TopLefTCell of the PossibleBlock.
            int xPos = block.DefinedCell.XPos + i, yPos = block.DefinedCell.YPos + j;
            HashSet<Cell> tempHash = new HashSet<Cell>();

            for (int k = 0; k < xDim; k++)
            {
                for (int l = 0; l < yDim; l++)
                {

                    if (Grid.AreValidCoordinates(xPos + k, yPos + l))
                    {
                        Cell tempCell = Grid.Cells[xPos + k, yPos + l];
                        if (!tempCell.IsOwnedByBlockOtherThan(block))
                        {
                            tempHash.Add(tempCell);
                        }else
                        {
                            return;
                        }

                    }else
                    {
                        return;
                    }



                }

            }



            PossibleBlock tempBlock = new PossibleBlock(block.Index, block.Area, block.DefinedCell, Grid) { Cells = tempHash, TopLeftCell = Grid.Cells[xPos, yPos] };
            tempBlock.Dimensions[0] = xDim;
            tempBlock.Dimensions[1] = yDim;
            block.PossibleBlocks.Add(tempBlock);
        }


            /// <summary>
            /// Gather all possible dimension pairs based on the this.Area in the form of int[2]. Adds all the arrays to a list.
            /// Considers rotations of a rectangle as different dimensions.
            /// </summary>
            private List<int[]> FillPossibleDimensions(MainBlock MBlock)
            {
                List<int[]> PossibleDimensions = new List<int[]>();
                {
                    for (int i = 1; i <= MBlock.Area; i++)
                    {
                        if (MBlock.Area % i == 0 && MBlock.Area/ i <= 7 && i <= 7)
                        {
                            PossibleDimensions.Add(new int[2] { i, MBlock.Area/ i });
                        }
                    }
                }
                return PossibleDimensions;
            }
        
    }
}
