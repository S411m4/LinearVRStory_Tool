using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActionTrigger : MonoBehaviour, IActionTrigger
{
    public abstract bool GetConditionState();
}
