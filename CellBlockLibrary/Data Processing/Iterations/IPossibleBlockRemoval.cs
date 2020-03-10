namespace CellBlockLibrary
{
    public interface IPossibleBlockRemoval
    {
        bool ChangeHasOccured { get; set; }
        bool ProvesNoSolution { get; set; }
        Grid Grid { get; set; }
        void RemoveImposBlocksAndsetCertain();
    }
}