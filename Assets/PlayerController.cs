using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float _JumpHeight = 1.5f;

    private bool JUMPING = false;
    private bool GROUNDED = false;
    private bool FALLING = false;

    Rigidbody _RigidBody;
    //CapsuleCollider _CapsuleCollider;

	void Start ()
    {
        _RigidBody = GetComponent<Rigidbody>();
        //_CapsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }
	
    void OnCollisionStay (Collision _Collider)
    {
        if (_Collider.gameObject.name == "Floor" && GROUNDED)
        {
            JUMPING = false;
        }
    }

    void OnCollisionEnter(Collision _Collider)
    {
        if (_Collider.gameObject.name == "Floor")
        {
            GROUNDED = true;
        }
    }
    void OnCollisionExit(Collision _Collider)
    {
        if (_Collider.gameObject.name == "Floor")
        {
            GROUNDED = false;
        }
    }

    void Update ()
    {
        if (Input.GetButtonDown("Jump") && !JUMPING && GROUNDED)
        {
            JUMPING = true;
            GROUNDED = false;

            _RigidBody.velocity += Vector3.up * 100.0f * _JumpHeight;
        }

        if (GROUNDED && Input.GetAxis("Horizontal") != 0)
            _RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * 100.0f, _RigidBody.velocity.y, 0.0f);
        else if ((JUMPING || FALLING) && Input.GetAxis("Horizontal") != 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.99f, _RigidBody.velocity.y, 0.0f);
        else if ((JUMPING || FALLING) && Input.GetAxis("Horizontal") == 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.9f, _RigidBody.velocity.y, 0.0f);
        else if (Input.GetAxis("Horizontal") == 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.5f, _RigidBody.velocity.y, 0.0f);
        

        //if (_RigidBody.velocity.x > 100)
          //  _RigidBody.velocity = new Vector3(100.0f, _RigidBody.velocity.y, _RigidBody.velocity.z)
    }

    void FixedUpdate ()
    {
        if (_RigidBody.velocity.y < 0)
            FALLING = true;
        else
            FALLING = false;

        if (!GROUNDED)
            _RigidBody.velocity -= Vector3.down * Physics.gravity.y;
    }
}
