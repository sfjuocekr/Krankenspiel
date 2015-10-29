using UnityEngine;
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
                transform.position = new Vector3(0, 0, transform.position.z);
        }
        else
        {
            Vector3 _position = _FocusTarget.transform.position;
                    _position.y = _FocusTarget.transform.position.y + 8;
                    _position.z = transform.position.z;

            transform.position = _position;

            //transform.LookAt(_FocusTarget.transform, Vector3.up);
        }
	}
}
