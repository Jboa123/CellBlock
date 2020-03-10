using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellBlockLibrary;

namespace CellBlock
{
    public class SolutionToDB
    {
        public SolutionToDB(Grid grid)
        {
            Grid = grid;
        }
        private readonly Grid Grid;

        private List<DBData> SaveData = new List<DBData>();
        public List<DBData> GetSaveDataList()
        {

            int puzzleKey = 0;      //represents each blocks contribution the to overall Puzzle_ID
            foreach (MainBlock block in Grid.Blocks)
            {
                DBData data = new DBData
                {
                    Block_id = block.Index,
                    Area = block.Area,
                    DefCell_XPos = block.DefinedCell.XPos,
                    DefCell_YPos = block.DefinedCell.YPos,
                    TopLeft_XPos = block.TopLeftCell.XPos,
                    TopLeft_YPos = block.TopLeftCell.YPos,
                    X_Dimension = block.FinalDimensions[0],
                    Y_Dimension = block.FinalDimensions[1]
                };

                SaveData.Add(data);
                puzzleKey += data.Area * data.Area * data.DefCell_XPos * data.DefCell_YPos * data.DefCell_YPos;
            }
            GenerateAndFillPuzzleID(puzzleKey);
            return SaveData;
        }

        private void GenerateAndFillPuzzleID(int ID)
        {
            foreach (DBData data in SaveData)
                data.Puzzle_id = ID;
        }
    }
}
