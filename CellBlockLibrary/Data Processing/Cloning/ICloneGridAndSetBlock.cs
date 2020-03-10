using System.Collections.Generic;

namespace CellBlockLibrary
{
    public interface ICloneGridAndSetBlock
    {
        List<Grid> GetGridsWithSetBlocks();
        Grid OriginalGrid { get; set; }

        void SetClonesOriginalGrid(Grid grid);
    }
}