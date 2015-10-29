using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class JumpTrigger : MonoBehaviour
{
    public GameObject JumpTarget;

    void OnTriggerStay(Collider _collider)
    {
        if (JumpTarget != null && gameObject.activeSelf && _collider.name == "Player")
        {
            //gameObject.SetActive(false);

            _collider.GetComponent<AICharacterControl>().JumpToTarget(JumpTarget.transform);

            //_collider.GetComponent<Rigidbody>().velocity += Vector3.up * 100;

            Debug.Log("Jumped!");
        }
    }
}
