using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private Transform _controller;

    private void Awake()
    {
        _controller = GameObject.Find("DirectionHelper").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            if (Debug.isDebugBuild)
                Debug.Log("Turn!");

            Quaternion _rotation = _controller.transform.rotation;
                       _rotation.y = -_rotation.y;

            _controller.transform.rotation = _rotation;
        }
    }
}
