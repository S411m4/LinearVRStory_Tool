using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

public class LinearStoryActions : MonoBehaviour
{
    [Serializable]
    class ActionComponent
    {
        public bool useTrigger;
        public BaseActionTrigger trigger;
        public UnityEvent action;
    };

    [SerializeField] private UnityEvent initialAction;
    [SerializeField] private List<ActionComponent> actions = new List<ActionComponent>();
    [SerializeField] private UnityEvent endAction;
    private int index = 0;
    private bool endOfActions = false;

    private void Start()
    {
        initialAction?.Invoke();
    }

    private void Update()
    {
        if (endOfActions){ endAction?.Invoke(); return; }

        ActionComponent actionComponent = actions[index];

        if(actionComponent.trigger == null)
        {
            actionComponent.action?.Invoke();
            index++;
        }
        else if(actionComponent.useTrigger && actionComponent.trigger.GetConditionState() == true)
        {
            actionComponent.action?.Invoke();
            index++;
        }
        
        if(index >= actions.Count) { index = 0; endOfActions = true; }
    }

    private bool IsEndOfAction() { return endOfActions;}
}
