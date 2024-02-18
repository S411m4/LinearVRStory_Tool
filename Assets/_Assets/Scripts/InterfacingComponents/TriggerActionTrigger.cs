using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class TriggerActionTrigger : BaseActionTrigger, IActionTrigger
{
    //either use as an action trigger in action system
    //or drag to counter system to keep counting as long as trigger stay

    public Action OnTriggerEnterAction;
    public Action OnTriggerExitAction;

    private bool _conditionState = false;
    public enum TriggerStates
    {
        Enter, Exit
    }
    [SerializeField] private TriggerStates _state;

    private void Awake()
    {
        this.GetComponent<Collider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterAction?.Invoke();
        if (_state == TriggerStates.Enter) { _conditionState = true; }
        else { _conditionState = false; }
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitAction?.Invoke();
        if (_state == TriggerStates.Exit) { _conditionState = true; }
        else { _conditionState = false; }
    }

    public override bool GetConditionState()
    {
        return _conditionState;
    }
}
