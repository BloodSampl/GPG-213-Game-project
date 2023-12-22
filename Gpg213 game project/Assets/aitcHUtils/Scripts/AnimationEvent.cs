using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public MyEvent[] customEvents;

    public void anim_CustomEvent(int eventIndex) 
    {
        customEvents[eventIndex].Invoke();
    }


}
[Serializable]
public class MyEvent : UnityEvent { }
