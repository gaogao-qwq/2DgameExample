using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollw : MonoBehaviour
{
    bool isFollow;
    float distance;
    float xSpeed = 0.0f;

    public float smoothTime = 0.3f;
    public float followSpace = 1.0f;
    public Transform followPlayer;

    private void FixedUpdate() {
        distance = Mathf.Abs(followPlayer.position.x - transform.position.x);
        if (distance > followSpace)
        {
            isFollow = true;
        }
        if(isFollow)
        {
            transform.position = new Vector3(Mathf.SmoothDamp(
            transform.position.x, followPlayer.position.x,ref xSpeed, smoothTime),
            transform.position.y, transform.position.z);
        }
        if(Mathf.Abs(transform.position.x - followPlayer.position.x) < 0.05f)
        {
            isFollow = false;
        }
    }

    private void OnDrawGizmos() {
        Debug.DrawLine(new Vector3(followSpace + transform.position.x, 5, 0),
                       new Vector3(followSpace + transform.position.x, -5, 0));
        Debug.DrawLine(new Vector3(-followSpace + transform.position.x, 5, 0),
                       new Vector3(-followSpace + transform.position.x, -5, 0));
    }
}
