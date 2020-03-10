using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockLibrary
{
    /// <summary>
    /// Used to deep clone the Grid. Allowing
    /// </summary>
    public class DeepCloneGrid : IDeepCloneGrid
    {
        public DeepCloneGrid()
        {

        }

        public Grid OriginalGrid { get; set; }
        private Grid NewGrid { get; set; }

        public Grid CloneGrid()
        {
            NewGrid = new Grid();
            NewGrid.Blocks = CloneMainBlocksList();
            DeepCloneAllCells();
            return NewGrid;
        }

        /// <summary>
        /// Clones all MainBlocks in the original Grid. Each PossibleBlock in the MainBlock.PossibleBlocks is also Cloned
        /// Cells are not dealth with at this stage.
        /// </summary>
        /// <returns></returns>
        private List<MainBlock> CloneMainBlocksList()
        {
            //List will stroe references to the newly created Blocks
            List<MainBlock> newMainBlockList = new List<MainBlock>();

            foreach (MainBlock originalMainBlock in OriginalGrid.Blocks)
            {
                newMainBlockList.Add(DeepCloneMainBlock(originalMainBlock));
            }
            return newMainBlockList;
        }


        /// <summary>
        /// Clones a MainBlock in the original Grid. Each PossibleBlock in the MainBlock.PossibleBlocks is also Cloned
        /// Cells are not dealth with at this stage.
        /// </summary>
        /// <param name="originalMBlock"></param>
        /// <returns></returns>
        private MainBlock DeepCloneMainBlock(MainBlock originalMBlock)
        {
            ///sets new main bl
            MainBlock newMainBlock = new MainBlock(originalMBlock.Index, originalMBlock.Area, originalMBlock.DefinedCell, NewGrid);
            newMainBlock.PossibleBlocks = ClonePossibleBlocksList(originalMBlock);
            return newMainBlock;
        }



        /// <summary>
        /// Loops through each PossibleBlock for the input original block. Each PossibleBlock is deep cloned and added to a list. This list is returned
        /// The new PossibleBlocks reference the newGrid. Cells are not added at this stage.
        /// </summary>
        /// <param name="originalMainBlock"></param>
        /// <returns></returns>
        private List<PossibleBlock> ClonePossibleBlocksList(MainBlock originalMainBlock)
        {
            //This list will hold the new PossibleBlocks for a new MainBlock
            List<PossibleBlock> newPossibleBlocks = new List<PossibleBlock>();


            foreach (PossibleBlock originalPossibleBlock in originalMainBlock.PossibleBlocks)
            {
                //Deep clone each original PossibeBlock and add to the new PossibleBlock list
                newPossibleBlocks.Add(DeepClonePossibleBlock(originalPossibleBlock));
            }
            return newPossibleBlocks;
        }


        /// <summary>
        /// Clones a single PossibleBlock and returns it. The new PossibleBlock references the new Grid.
        /// </summary>
        /// <param name="originalPBlock"></param>
        /// <returns></returns>
        private PossibleBlock DeepClonePossibleBlock(PossibleBlock originalPBlock)
        {
            ///new Possible 
            PossibleBlock newPossibleBlock = new PossibleBlock(originalPBlock.Index, originalPBlock.Area, originalPBlock.DefinedCell, NewGrid);
            newPossibleBlock.Dimensions = originalPBlock.Dimensions;
            return newPossibleBlock;
            //TopLeftCell (Cell) and Cells(Hashset<Cell>) remain unfilled for now as the new cells have not been created yet.

        }

        /// <summary>
        /// Deep Clone all Cells.
        /// </summary>
        private void DeepCloneAllCells()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cell originalCell = OriginalGrid.Cells[i, j];
                    Cell newCell = DeepCloneCell(originalCell);
                    NewGrid.Cells[i, j] = newCell;
                }
            }
        }

        /// <summary>
        /// A new Cell is created. The new Cell has identical primitive data types but points to a new Grid.
        /// A new Dictionary of possible indexes is created. The  integer values are copied from the original cell to the new cell.
        /// </summary>
        /// <param name="orignalCell"></param>
        private Cell DeepCloneCell(Cell originalCell)
        {
            Cell newCell = new Cell(originalCell.XPos, originalCell.YPos, NewGrid);

            CreateNewCellPBlockReference(newCell, originalCell);
            if (originalCell.IsOwned)
            {
                newCell.SetOwnership(NewGrid.Blocks[originalCell.OwnedBy]);
            }


            return newCell;
        }

        /// <summary>
        /// The input Cells are the equivalent new and original. Gives the new Cell a reference to the correct new PossibleBlock via Cell.PossibleIndexs
        /// Adds the new Cell to all the relevant new PossibleBlocks.Cells.
        /// Sets the TopLeftCell of the new PossibleBlocks.
        /// </summary>
        /// <param name="newCell"></param>
        /// <param name="originalCell"></param>
        private void CreateNewCellPBlockReference(Cell newCell, Cell originalCell)
        {
            //PossibleIndexs is a dictionary of <int, List<PossibleBlock>>. The int represents the Blocks Index and the List<PossibleBlock> represents
            //all the PossibleBlocks of given index that contain this cell
            foreach (KeyValuePair<int, List<PossibleBlock>> KVP in originalCell.PossibleIndexs)
            {
                //create new PossibleBlock List that will be the value of the new Cell's PossibleIndexs. Will contain references to the new PossibleBlocks.
                List<PossibleBlock> newCellPBlockList = new List<PossibleBlock>();

                //The Key represents BlockIndex
                int blockIndex = KVP.Key;
                foreach (PossibleBlock originalPBlock in KVP.Value)
                {
                    //Search for the orignal Possible Block in original Grid.Blocks[relevant].PossibleBlocks and get the position in the list.
                    //The New and Original MainBlocks and PossibleBlocks have the equivalent block at the same position in the list.
                    //This will be used to generate reference to the new Possible Block.
                    int pBlockPosition = OriginalGrid.Blocks[blockIndex].PossibleBlocks.IndexOf(originalPBlock);

                    //Create reference to the new PossibleBlock that is equivalent to the original
                    PossibleBlock newPBlock = NewGrid.Blocks[blockIndex].PossibleBlocks[pBlockPosition];

                    //The new Cell is a Member of the new PossibleBlock
                    newPBlock.Cells.Add(newCell);

                    //The input Cells are the equivalents. If the original Cell is the TopLeftCell then the new Cell must also be
                    if (originalPBlock.TopLeftCell == originalCell)
                    {
                        newPBlock.TopLeftCell = newCell;
                    }

                    newCellPBlockList.Add(newPBlock);

                }
                newCell.PossibleIndexs.Add(blockIndex, newCellPBlockList);
            }
        }


    }
}
