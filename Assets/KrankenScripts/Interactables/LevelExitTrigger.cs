using UnityEngine;

public class LevelExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider _collider)
    {
        // This is very dirty!
        Destroy(_collider.gameObject);

        Application.LoadLevel(Application.loadedLevel);
    }
}
