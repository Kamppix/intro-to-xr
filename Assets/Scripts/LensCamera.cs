using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LensCamera : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        Vector3 direction = transform.position - playerCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(direction, transform.parent.up);
    }
}
