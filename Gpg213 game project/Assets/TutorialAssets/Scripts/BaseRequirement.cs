using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRequirement : MonoBehaviour
{
    protected bool isCompleted = false;

    public bool IsCompleted { get => isCompleted; }

    public Action onRequirementMet;

    protected void RequirementMet() 
    {
        isCompleted = true;
        onRequirementMet.Invoke();
    }

    public abstract void SetupRequirement();
    public abstract void ClearRequirement();
}
