using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

	// Use this for initialization
	void Start ()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FixedUpdate ()
    {
        Vector3 _position = transform.position;

        _position.z = 0;
        transform.position = _position;
    }
}
