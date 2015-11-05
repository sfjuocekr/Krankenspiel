using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public GameObject Trigger;

    private void Start()
    {
        Trigger.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        Trigger.SetActive(true);
    }
}
