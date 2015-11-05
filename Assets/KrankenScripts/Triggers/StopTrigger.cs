using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class StopTrigger : MonoBehaviour
{
    private AutomatedControls _controller;
    private float _justTriggered = 0f;

    private void Awake()
    {
        _controller = GameObject.Find("Player").GetComponent<AutomatedControls>();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            if (_justTriggered > 0) return;

            _justTriggered = Time.deltaTime;

            if (Debug.isDebugBuild)
                Debug.Log("Stop!");

            _controller.m_Moving = false;
        }
    }

    private void Update()
    {
        if (Time.deltaTime - _justTriggered > 1)
            _justTriggered = 0f;
    }
}
