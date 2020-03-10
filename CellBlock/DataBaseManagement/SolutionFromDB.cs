using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;

namespace CellBlock
{
    public class SolutionFromDB
    {

        public List<DBData> DataList { get; set; } = new List<DBData>();

        public Grid Grid { get; set; } = new Grid();

        /// <summary>
        /// Access SQL data base and retrieve data with a Puzzle_id matching the input integer. Returns a List, with each member containing information about a single block.
        /// </summary>
        /// <param name="PuzzleID"></param>

        public List<DBData> LoadDataFromID(int PuzzleID)
        {
            DataList = DataAccess.LoadCaseFromDB(PuzzleID);
            return DataList;
        }



        /// <summary>
        /// Fills the Grid with the data in This.DataList
        /// </summary>
        public void DataToGrid()
        {
            foreach(DBData data in DataList)
            {
                Grid.Blocks.Add(CreateBlockFromSavedData(data));
            }
        }


        /// <summary>
        /// Turn a DBData type into a MainBlock. Fills properties of each cell within the block.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private MainBlock CreateBlockFromSavedData(DBData data)
        {
            Cell defCell = Grid.Cells[data.DefCell_XPos, data.DefCell_YPos];
            MainBlock block = new MainBlock(data.Block_id, data.Area, defCell, Grid);

            for (int i = data.TopLeft_XPos; i < data.X_Dimension + data.TopLeft_XPos; i++)
            {
                for (int j = data.TopLeft_YPos; j < data.Y_Dimension + data.TopLeft_YPos; j++)
                {
                    Cell cell = Grid.Cells[i, j];
                    cell.OwnedBy = data.Block_id;
                    block.CertainCells.Add(cell);
                    block.TopLeftCell = defCell;
                }
            }

            return block;
        }
    }
}
