using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : MonoBehaviour
{
    private bool _canGrab = false;
    public Transform grabPosition;
    private GameObject _lastPersonTouched;

    private void Update()
    {
        if (_canGrab && Input.GetKey(KeyCode.Space))
        {
            _lastPersonTouched.transform.position = grabPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            _canGrab = true;
            _lastPersonTouched = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            _canGrab = false;
        }
    }
}