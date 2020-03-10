namespace CellBlockLibrary
{
    public interface IDeepCloneGrid
    {
        Grid CloneGrid();
        Grid OriginalGrid { get; set; }
    }
}