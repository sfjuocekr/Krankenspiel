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

        public Camera _camera;

        private Vector3 targetPosition = Vector3.zero;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            _camera = GameObject.Find("TESTCAMERA").GetComponent<Camera>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition); //Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    targetPosition = new Vector3(hit.point.x, hit.point.y, 0);

                    target = null;

                    agent.SetDestination(targetPosition);

                    Debug.Log("mouse");
                }
            }
            else if (target != null)
            {
                targetPosition = target.position;

                target = null;

                agent.SetDestination(targetPosition);

                Debug.Log("target");
            }

            if (transform.position == targetPosition)
                targetPosition = Vector3.zero;

            if (targetPosition == Vector3.zero)
                character.Move(Vector3.zero, false, false);
            else
            {
                character.Move(agent.desiredVelocity, false, false);
            }

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
    }
}
