using UnityEngine;
using System.Collections;

public class LevelExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider _collider)
    {
        Destroy(_collider.gameObject);

        Application.LoadLevel(Application.loadedLevel);
    }
}
