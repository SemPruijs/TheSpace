using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float trackingDelay;
    public float menuSize;
    public float inGameSize;
    public float deadSize;
    [Space(10)]
    public float floor0Size;
    public Vector3 floor0Position;

    private void LateUpdate()
    {
        if (GameManager.Instance.state == GameManager.State.InGame && !GameManager.Instance.inRoom)
        {
            var desiredPosition = target.transform.position + offset;
            var smoothedPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, trackingDelay * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public void InGameCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize = inGameSize;
    }

    public void MenuCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize = menuSize;
    }

    public void FloorZero()
    {
        gameObject.GetComponent<Camera>().orthographicSize = floor0Size;
        transform.position = floor0Position;
    }

    public void DeadCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize = deadSize;
    }
}
