using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public GameObject Trigger;

    private void Start()
    {
        Trigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
            Trigger.SetActive(true);
    }
}
