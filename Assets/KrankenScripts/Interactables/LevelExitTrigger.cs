using UnityEngine;

public class LevelExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
