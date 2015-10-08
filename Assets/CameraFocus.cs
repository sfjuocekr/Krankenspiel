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
        Vector3 _position = _FocusTarget.transform.position;
                _position.z = transform.position.z;

        transform.position = _position;
	}
}
