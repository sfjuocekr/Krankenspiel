using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for

        private Camera _camera;

        private Vector3 targetPosition = Vector3.zero;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            _camera = GameObject.Find("Camera").GetComponent<Camera>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpToTarget(new Vector3(100,100,0));
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

            /*
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(new Vector3(hit.point.x, hit.point.y, 0));

                    // use the values to move the character
                    character.Move(agent.desiredVelocity, false, false);
                }
            }
            else if (target != null)
            {
                agent.SetDestination(target.position);

                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
            }
            else
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);*/
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void JumpToTarget(Vector3 targetPosition)
        {
            //this.target = target;

            agent.Stop();

            character.Move(targetPosition, false, true);
            character.GetComponent<Rigidbody>().AddForce(targetPosition);
        }
    }
}
