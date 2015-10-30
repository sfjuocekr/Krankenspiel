using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class NavMeshCharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target; // target to aim for

    private Camera _camera;

    private Vector3 targetPosition = Vector3.zero;

    // Use this for initialization
    private void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        _camera = GameObject.Find("Camera").GetComponent<Camera>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpToTarget(new Vector3(100, 100, 0));
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), 0.0f);

                target = null;

                agent.SetDestination(targetPosition);
                agent.Resume();

                Debug.Log("mouse");
            }
        }
        else if (target != null)
        {
            targetPosition = target.position;

            target = null;

            agent.SetDestination(targetPosition);
            agent.Resume();

            Debug.Log("target");
        }

        if (Mathf.Round(transform.position.x) == targetPosition.x && Mathf.Round(transform.position.y) == targetPosition.y)
        {
            agent.Stop();
            targetPosition = Vector3.zero;

            Debug.Log("stop");
        }

        if (targetPosition == Vector3.zero)
            character.Move(Vector3.zero, false, false);
        else
            character.Move(agent.desiredVelocity, false, false);
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void JumpToTarget(Vector3 targetPosition)
    {
        agent.Stop();

        character.Move(targetPosition, false, true);
        character.GetComponent<Rigidbody>().AddForce(targetPosition);
    }
}
