using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour
{
    public GameObject JumpTarget;

    void OnTriggerStay(Collider _collider)
    {
        if (JumpTarget != null && gameObject.activeSelf && _collider.name == "Player")
        {
            //gameObject.SetActive(false);

            _collider.GetComponent<NavMeshCharacterControl>().JumpToTarget(JumpTarget.transform.position);

            //_collider.GetComponent<Rigidbody>().velocity += Vector3.up * 100;

            Debug.Log("Jumped!");
        }
    }
}
