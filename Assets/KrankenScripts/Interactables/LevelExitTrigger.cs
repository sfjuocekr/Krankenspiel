using UnityEngine;

public class LevelExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider _collider)
    {
        // This is very dirty!
        if (_collider.name == "Player")
        {
            Destroy(_collider.gameObject);

            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
