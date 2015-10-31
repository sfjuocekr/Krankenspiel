using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private Transform _controller;

    void Awake()
    {
        _controller = GameObject.Find("Target").GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            Quaternion _rotation = _controller.transform.rotation;
                       _rotation.y = -_rotation.y;

            _controller.transform.rotation = _rotation;
        }
    }
}
