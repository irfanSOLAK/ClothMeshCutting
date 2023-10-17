using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixState : MonoBehaviour, IObjectState
{
    GameObject _originalSlicable;

    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    private SelectionManager _selectionManager;


    private void Start()
    {
        _originalSlicable = GameObject.FindGameObjectWithTag("DynamicSoft");
        Instantiate(_originalSlicable);
        _originalSlicable.SetActive(false);
    }

    public void Handle(SelectionManager selectionManager)
    {
        _originalPosition = transform.localPosition;
        _originalRotation = transform.localRotation;

        if (!_selectionManager)
            _selectionManager = selectionManager;
    }

    public void DeactivateState()
    {
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject[] slicableObjects = GameObject.FindGameObjectsWithTag("DynamicSoft");

                for (int i = 0; i < slicableObjects.Length; i++)
                {
                    Destroy(slicableObjects[i]);
                }

                GameObject cloneSlicable = Instantiate(_originalSlicable);
                cloneSlicable.SetActive(true);
            }
        }

    }
}
