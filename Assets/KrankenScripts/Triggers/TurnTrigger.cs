using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private Transform _controller;
    private GameObject _camera;
    private GameObject _ARPlane;
    private float _justTriggered = 0f;

    private void Awake()
    {
        _controller = GameObject.Find("DirectionHelper").GetComponent<Transform>();
        _camera = GameObject.Find("ARCamera");
        _ARPlane = GameObject.Find("ARTranslationPlane");
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            if (_justTriggered > 0) return;

            _justTriggered = Time.deltaTime;

            if (Debug.isDebugBuild)
                Debug.Log("Turn!");

            // Player
            Quaternion _rotation = _controller.transform.rotation;
            _rotation.y = -_rotation.y;

            _controller.transform.rotation = _rotation;

            // ARCamera
            /*_rotation = _camera.transform.rotation;
            _rotation.y = -_rotation.y;

            _camera.transform.rotation = _rotation;*/
        }
    }

    private void Update()
    {
        if (Time.deltaTime - _justTriggered > 1)
            _justTriggered = 0f;
    }
}
