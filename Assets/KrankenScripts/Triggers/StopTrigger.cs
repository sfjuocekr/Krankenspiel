using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class StopTrigger : MonoBehaviour
{
    private AutomatedControls _controller;

    private void Awake()
    {
        _controller = GameObject.Find("Player").GetComponent<AutomatedControls>();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            if (Debug.isDebugBuild)
                Debug.Log("Stop!");

            _controller.m_Moving = false;
        }
    }
}
