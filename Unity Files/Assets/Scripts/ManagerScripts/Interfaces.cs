public interface IObjectState
{
    void Handle(SelectionManager selectionManager);
    void DeactivateState();
}