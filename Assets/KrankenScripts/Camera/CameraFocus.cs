﻿using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour
{
    public GameObject _FocusTarget;
	
	void Start ()
    {
	    if (_FocusTarget == null)
        {
            _FocusTarget = GameObject.Find("Player");
        }
	}
	
	void Update ()
    {
        if (_FocusTarget == null)
        {
            _FocusTarget = GameObject.Find("Player");

            if (_FocusTarget == null)
                transform.position = new Vector3(0, 0, -100);
        }
        else
        {
            Vector3 _position = _FocusTarget.transform.position;
                    _position.z = transform.position.z;

            transform.position = _position;
        }
	}
}