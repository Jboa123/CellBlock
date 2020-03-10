namespace CellBlockLibrary
{
    public interface IGridAndCellIterations
    {
        bool ChangeHasOccured { get; set; }
        bool ProvesNoSolution { get; set; }
        Grid Grid { get; set; }
        void CheckAllCellMembership();
        void CheckAllCellPossibleIndexs();
        void ClearCellPossibleIndexs();
        void FillCellIndex();
    }
}