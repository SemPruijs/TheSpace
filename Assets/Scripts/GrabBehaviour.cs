using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : MonoBehaviour
{
    private bool _canGrab = false;
    private bool _isGrabbing;
    public Transform grabPosition;
    private GameObject _lastPersonTouched;
    private Vector3 _startGrabPosition;


    private void Start()
    {
        _startGrabPosition = grabPosition.localPosition;
    }

    private void Update()
    {
        if (_canGrab && Input.GetKey(KeyCode.Space))
        {
            _lastPersonTouched.transform.position = grabPosition.position;
            SetGrabPosition();
        }

        _isGrabbing = Input.GetKey(KeyCode.Space);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            _canGrab = true;
            if (!_isGrabbing)
            {
                _lastPersonTouched = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Person") && !_isGrabbing)
        {
            _canGrab = false;
        }
    }

    private void SetGrabPosition()
    {
        if ((int) Input.GetAxisRaw("Horizontal") == -1)
        {
            grabPosition.localPosition = new Vector3(_startGrabPosition.x * -1f, grabPosition.localPosition.y,
                grabPosition.localPosition.z);
        } else if ((int) Input.GetAxisRaw("Horizontal") == 1)
        {
            grabPosition.localPosition = _startGrabPosition;
        }
    }
}