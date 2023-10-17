using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private StateManager _stateManager;
    public IObjectState noState, stickState, cutState, fixState, removeState;

    public IObjectState CurrentState
    {
        get { return _stateManager.CurrentState; }
    }

    public void Awake()
    {
        _stateManager = new StateManager(this);
    }

    public void ChangeStateTo(IObjectState objectState)
    {
        _stateManager.Transition(objectState);
    }

    public void OnDisable()
    {
        _stateManager.DeactivatePreviousState();
    }

    public void SelectNoTool()
    {
        GameObject noTool = GameObject.FindGameObjectWithTag("NoTool");

        if (noState == null)
            noState = noTool.GetComponent<NoState>();

        if (CurrentState != noState)
            ChangeStateTo(noState);
    }

    public void SelectStick()
    {
        GameObject stick = GameObject.FindGameObjectWithTag("Stick");

        stick.GetComponent<MeshRenderer>().enabled = true;
        stick.GetComponent<CapsuleCollider>().enabled = true;

        if (stickState == null)
            stickState = stick.GetComponent<StickState>();

        if (CurrentState != stickState)
            ChangeStateTo(stickState);

    }

    public void SelectScissors()
    {
        GameObject scissors = GameObject.FindGameObjectWithTag("Scissors");

        scissors.GetComponent<MeshRenderer>().enabled = true;
        scissors.GetComponent<CapsuleCollider>().enabled = true;

        if (cutState == null)
            cutState = scissors.GetComponent<CutState>();

        if (CurrentState != cutState)
            ChangeStateTo(cutState);
    }

    public void SelectFixTool()
    {
        GameObject fixTool = GameObject.FindGameObjectWithTag("FixTool");

        fixTool.GetComponent<MeshRenderer>().enabled = true;
        fixTool.GetComponent<CapsuleCollider>().enabled = true;

        if (fixState == null)
            fixState = fixTool.GetComponent<FixState>();

        if (CurrentState != fixState)
            ChangeStateTo(fixState);
    }

    public void SelectRemoveTool()
    {
        GameObject removeTool = GameObject.FindGameObjectWithTag("Remove");

        removeTool.GetComponent<MeshRenderer>().enabled = true;
        removeTool.GetComponent<CapsuleCollider>().enabled = true;

        if (removeState == null)
            removeState = removeTool.GetComponent<RemoveState>();

        if (CurrentState != removeState)
            ChangeStateTo(removeState);
    }
}
