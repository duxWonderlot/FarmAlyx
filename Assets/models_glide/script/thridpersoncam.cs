using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thridpersoncam : MonoBehaviour
{
    public float mouseSene = 10;
    float yaw;
    float pitch;
    public Transform target;
    public float distanceOffset;
    public Vector2 minmax = new Vector2(-40, 85);
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSene;
        pitch -= Input.GetAxis("Mouse Y") * mouseSene;
        pitch = Mathf.Clamp(pitch , minmax.x,minmax.y);
        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * distanceOffset;
    }
}
