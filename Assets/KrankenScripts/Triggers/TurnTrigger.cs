using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private Transform _controller;
    private GameObject _camera;

    private void Awake()
    {
        _controller = GameObject.Find("DirectionHelper").GetComponent<Transform>();
        _camera = GameObject.Find("ARCamera");
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            if (Debug.isDebugBuild)
                Debug.Log("Turn!");

            // Player
            Quaternion _rotation = _controller.transform.rotation;
                       _rotation.y = -_rotation.y;

            _controller.transform.rotation = _rotation;

            // ARCamera
            _rotation = _camera.transform.rotation;
            _rotation.y = -_rotation.y;

            _camera.transform.rotation = _rotation;
        }
    }
}
