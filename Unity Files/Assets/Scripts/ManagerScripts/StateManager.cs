public class StateManager
{
    public IObjectState CurrentState { get; set; }
    public IObjectState PreviousState { get; set; }

    private readonly SelectionManager _selectionManager;

    public StateManager(SelectionManager selectionManager)
    {
        _selectionManager = selectionManager;
    }

    public void Transition(IObjectState state)
    {
        if (CurrentState != null)
        {
            DeactivatePreviousState();
        }

        CurrentState = state;
        CurrentState.Handle(_selectionManager);
    }

    public void DeactivatePreviousState()
    {
        PreviousState = CurrentState;
        PreviousState.DeactivateState();
    }
}