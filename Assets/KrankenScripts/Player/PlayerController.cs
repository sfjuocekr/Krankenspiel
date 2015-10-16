using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float JumpHeight = 1.5f;

    private bool JUMPING = false;
    private bool GROUNDED = false;
    private bool FALLING = false;

    Rigidbody _RigidBody;

	void Start ()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision _collision)
    {
        //Debug.Log("Enter: " + _Collider.gameObject.tag);

        /*if (_Collider.gameObject.tag == "Floor")
        {
            GROUNDED = true;
        }*/
    }

    void OnCollisionStay(Collision _collision)
    {
        //Debug.Log("Stay: " + _Collider.gameObject.tag);

        if (_collision.gameObject.tag == "Floor" && GROUNDED)
        {
            JUMPING = false;
        }
        else if (_collision.gameObject.tag == "Floor" && !GROUNDED)
        {
            GROUNDED = true;
        }
    }

    void OnCollisionExit(Collision _collision)
    {
        //Debug.Log("Exit: " + _Collider.gameObject.tag);

        if (_collision.gameObject.tag == "Floor")
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

            _RigidBody.velocity += Vector3.up * JumpHeight;
        }

        if (GROUNDED && Input.GetAxis("Horizontal") != 0)
            _RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * Physics.gravity.y, _RigidBody.velocity.y, 0.0f);
        else if ((JUMPING || FALLING) && Input.GetAxis("Horizontal") != 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.99f, _RigidBody.velocity.y, 0.0f);
        else if ((JUMPING || FALLING) && Input.GetAxis("Horizontal") == 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.9f, _RigidBody.velocity.y, 0.0f);
        else if (Input.GetAxis("Horizontal") == 0 && _RigidBody.velocity.x != 0)
            _RigidBody.velocity = new Vector3(_RigidBody.velocity.x * 0.5f, _RigidBody.velocity.y, 0.0f);

        //Debug.Log("GROUNDED: " + GROUNDED.ToString() + ", FALLING: " + FALLING.ToString() + ", JUMPING: " + JUMPING.ToString());
    }

    void FixedUpdate ()
    {
        if (_RigidBody.velocity.y < 0)
            FALLING = true;
        else
            FALLING = false;

        if (!GROUNDED)
            _RigidBody.velocity -= Vector3.down * Physics.gravity.y * 0.1f;
    }
}
