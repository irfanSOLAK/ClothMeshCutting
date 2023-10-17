using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoState : MonoBehaviour, IObjectState
{
    private SelectionManager _selectionManager;

    public void Handle(SelectionManager selectionManager)
    {
        if (!_selectionManager)
            _selectionManager = selectionManager;
    }

    public void DeactivateState()
    {
        _selectionManager = null;
    }
}
