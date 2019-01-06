namespace Snake.UI
{
    public interface IMoveCommandFactory
    {
        IMoveCommand Create(MoveDirection direction);
    }
}