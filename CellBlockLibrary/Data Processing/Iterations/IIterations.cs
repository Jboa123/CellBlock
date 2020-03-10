namespace CellBlockLibrary
{
    public interface IIterations
    {
        bool ChangeHasOccured { get; set; }
        bool ProvesNoSolution { get; set; }
        Grid Grid { get; set; }
        void IterateUntilStatic();

        void setIterationGrid(Grid grid);
    }
}