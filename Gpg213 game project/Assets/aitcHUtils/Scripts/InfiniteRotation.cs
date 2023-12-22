using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 2f;
    [SerializeField]
    RotationAxis axis;
    public enum RotationAxis { X_Axis, Y_Axis, Z_Axis }
    Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        switch (axis)
        {
            case RotationAxis.X_Axis:
                rotationVector = new Vector3(1, 0, 0);
                break;
            case RotationAxis.Y_Axis:
                rotationVector = new Vector3(0, 1, 0);
                break;
            case RotationAxis.Z_Axis:
                rotationVector = new Vector3(0, 0, 1);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
    }
}
