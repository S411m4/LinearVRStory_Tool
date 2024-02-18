using Unity.VisualScripting;
using UnityEngine;

public class CountDown : BaseActionTrigger
{
    //either put a trigger collider to start counting as long as in collider
    //or manually set counter
    [Header("settings")]
    [SerializeField] private TriggerActionTrigger triggerCollider;
    [SerializeField] private float COUNTER_VALUE = 5f;

    private float _accumulator = 0;
    private bool _start = false;
    private bool _counterReached = false; //true when counter equals to zero
    private bool _deactivateITrigger = false;

    
    private void Awake()
    {
        if(triggerCollider != null)
        {
            triggerCollider.OnTriggerEnterAction += TriggerCollider_OnTriggerEnterAction;
            triggerCollider.OnTriggerExitAction += TriggerCollider_OnTriggerExitAction;
        }
    }

    private void Update()
    {
        if (triggerCollider != null && !_deactivateITrigger)
        {
            if (triggerCollider.GetConditionState() == false)
            {
                StopCounter();
            }
        }

        if (!_start) return;

        _accumulator -= Time.deltaTime;
        if (_accumulator <= 0)
        {
            _counterReached = true;
            _accumulator = 0;
            _start = false;
        }
       
      
    }

    private void StartCounter()
    {
        _accumulator = COUNTER_VALUE;
        _start = true;
        _counterReached = false;
    }
    public void StartCounter(float counterValue)
    {
        COUNTER_VALUE = counterValue;
        StartCounter();
    }
    
    private void StopCounter()
    {
        _start = false;
    }

    public override bool GetConditionState()
    {
        return _counterReached;
    }

    public void SetTriggerCollider(TriggerActionTrigger triggerCollider)
    {
        this.triggerCollider = triggerCollider;
        triggerCollider.OnTriggerEnterAction += TriggerCollider_OnTriggerEnterAction;
        triggerCollider.OnTriggerExitAction += TriggerCollider_OnTriggerExitAction;
    }

    public void UnsetTriggerCollider()
    {
        triggerCollider.OnTriggerEnterAction -= TriggerCollider_OnTriggerEnterAction;
        triggerCollider.OnTriggerExitAction -= TriggerCollider_OnTriggerExitAction;
        this.triggerCollider = null;
    }

    private void TriggerCollider_OnTriggerEnterAction()
    {
        StartCounter();
    }

    private void TriggerCollider_OnTriggerExitAction()
    {
        StopCounter();
    }






}
