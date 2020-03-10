using System;
using System.Collections.Generic;
using System.Text;





namespace CellBlockLibrary
{
    public class Grid
    {
         public Grid()
         {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.Cells[i, j] = new Cell(i, j, this);
                }
            }
            SolvedCellCount = 0;
         }
        public int SolvedCellCount { get; set; }
        public  Cell[,] Cells { get; set; } = new Cell[7, 7]; //Grid made up of 7x7 block of cells

        public  List<MainBlock> Blocks { get; set; } = new List<MainBlock>(); // List of blocks. Sum of areas = 49, contains list of defined cells

        /// <summary>
        /// Are the input coordinates within the grid? if so returns true.
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <returns></returns>

        public bool HasSolution
        {
            get
            {
                if (SolvedCellCount == 49)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }

        public static bool AreValidCoordinates(int XPos, int YPos)
        {

            if (XPos >= 0 && XPos < 7 && YPos >= 0 && YPos < 7)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
