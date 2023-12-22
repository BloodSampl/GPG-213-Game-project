using aitcHUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    [SerializeField] float guideShowTime = 2f;
    [SerializeField] BaseRequirement[] requirements;
    Text guideTxt;
    GameObject nextBtn;

    string guideStr;
    int currReq = -1;

    private void Awake()
    {
        guideTxt = GetComponentInChildren<Text>();
        nextBtn = GetComponentInChildren<Button>().gameObject;

        guideStr = guideTxt.text;
        guideTxt.text = "";
        nextBtn.SetActive(false);

        foreach (var requirement in requirements)
        {
            requirement.onRequirementMet = CheckForRequirement;
        }

        if (requirements.Length > 0) 
        {
            currReq = 0;
            requirements[currReq].SetupRequirement();
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        MiscUtils.DoWithDelay(this, ()=>
        {
            UIUtils.TypeText(this, guideTxt, guideStr, () =>
            {
                MiscUtils.DoWithDelay(this, () => { CheckForRequirement(); }, 2f);
            }, null, 0.025f);
        }, 1f);
    }

    void CheckForRequirement() 
    {
        if (requirements.Length == 0) 
            nextBtn.SetActive(true);
        else 
        {
            bool allRequirementCompleted = true;
            int requirementsCompleted = 0;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (!requirements[i].IsCompleted)
                    allRequirementCompleted = false;
                else
                    requirementsCompleted++;
            }

            if (allRequirementCompleted) 
            {
                foreach (var requirement in requirements)
                {
                    requirement.ClearRequirement();
                }

                nextBtn.SetActive(true);
            }
            else 
            {
                currReq = requirementsCompleted; // currReq is index starting from 0. So if 0 reqCompleted, first requirement with set
                requirements[currReq].SetupRequirement();
                if(currReq - 1 >= 0) requirements[currReq -1 ].ClearRequirement();
            }
        }
    }
}
