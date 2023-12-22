using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRequirement : BaseRequirement
{
    [SerializeField] int inputsRequired = 4;

    int wasdInputCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            wasdInputCount++;

            if (wasdInputCount >= inputsRequired && !IsCompleted)
                RequirementMet();
        }
    }

    public override void ClearRequirement()
    {
        gameObject.SetActive(false);
    }

    public override void SetupRequirement()
    {
        gameObject.SetActive(true);
    }
}
