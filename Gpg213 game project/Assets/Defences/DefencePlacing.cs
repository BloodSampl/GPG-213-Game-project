using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePlacing : MonoBehaviour
{
    //[SerializeField] Camera cam;
    //[SerializeField] LayerMask layerMask;
    DefenceSelector defence;
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;

    private void Start()
    {
        defence = GetComponent<DefenceSelector>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,float.MaxValue))
        {
            transform.position = hit.point;
        }
    }
    private void Update()
    {
        defence = GetComponent<DefenceSelector>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,float.MaxValue))
        {
            transform.position = hit.point;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
