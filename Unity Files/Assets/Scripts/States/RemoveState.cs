using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveState : MonoBehaviour, IObjectState
{
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    private SelectionManager _selectionManager;

    private bool isRemovable;

    public bool IsRemovable
    {
        get { return isRemovable; }
    }




    public void Handle(SelectionManager selectionManager)
    {
        _originalPosition = transform.localPosition;
        _originalRotation = transform.localRotation;
        isRemovable = true;

        if (!_selectionManager)
            _selectionManager = selectionManager;
    }

    public void DeactivateState()
    {
        isRemovable = false;
        _selectionManager = null;
        transform.SetPositionAndRotation(_originalPosition, _originalRotation); // Original position and rotation they can be changed
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectionManager)
        {
            GetComponent<ObjectsMotion>().ControlWithTouchInput();
        }

    }
}
