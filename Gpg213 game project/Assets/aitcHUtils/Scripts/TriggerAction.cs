using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class TriggerAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("On entering this tag, run the onTrigger event")]
    string triggerTag;

    public TriggerEvent onTrigger;

    BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
            onTrigger.Invoke();
    }
}

[System.Serializable]
public class TriggerEvent : UnityEvent { }
