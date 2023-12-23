using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public void onClick_OpenLink(string url) 
    {
        Application.OpenURL(url);
    }
}
