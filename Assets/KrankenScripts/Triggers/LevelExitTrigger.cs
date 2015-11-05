using UnityEngine;

public class LevelExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            Application.LoadLevel(0);
            //Application.UnloadLevel(1);
        }
    }
}
