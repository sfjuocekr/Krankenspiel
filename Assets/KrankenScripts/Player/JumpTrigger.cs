using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public GameObject JumpTarget { get; private set; }

    void OnTriggerStay(Collider _collider)
    {
        if (JumpTarget != null && gameObject.activeSelf && _collider.name == "Player")
        {
            gameObject.SetActive(false);

            _collider.GetComponent<NavMeshCharacterControl>().JumpToTarget(JumpTarget.transform.position);
        }
    }
}
