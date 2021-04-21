using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float trackingDelay;

    private void LateUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.InGame)
        {
            var desiredPosition = target.transform.position + offset;
            var smoothedPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, trackingDelay * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
