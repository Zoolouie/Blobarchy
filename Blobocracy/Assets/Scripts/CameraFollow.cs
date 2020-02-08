using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    public float FollowSpeed = 2f;
    public Transform Target;
    public float z_position = -10;

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = z_position;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
