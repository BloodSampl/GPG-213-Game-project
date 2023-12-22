using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRequirement : BaseRequirement
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsCompleted)
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
