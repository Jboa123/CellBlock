namespace CellBlockLibrary
{
    public interface IPossibleBlockGeneration
    {
        Grid Grid { get; set; }
        void CreateAllPossibleBlock();
    }
}