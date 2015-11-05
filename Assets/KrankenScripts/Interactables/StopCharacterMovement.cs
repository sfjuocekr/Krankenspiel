using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class StopCharacterMovement : MonoBehaviour
{
    public GameObject Target;

    private void OnTriggerStay(Collider _collider)
    {
        if (Target != null && gameObject.activeSelf)
        {
            _collider.GetComponent<AICharacterControl>().SetTarget(null);
        }
    }
}
