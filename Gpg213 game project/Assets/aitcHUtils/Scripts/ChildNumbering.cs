using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace aitcHUtils
{
    public class ChildNumbering : MonoBehaviour
    {
        [SerializeField]
        string newName;

        public void RenameChildren() 
        {
            if (newName != "" || string.IsNullOrEmpty(newName)) 
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.name = newName + (i + 1);
                }
            }
        }
    }
}
