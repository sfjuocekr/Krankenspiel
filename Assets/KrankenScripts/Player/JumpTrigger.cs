using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class JumpTrigger : MonoBehaviour
{
    private AutomatedControls _controller;

    void Awake()
    {
        _controller = GameObject.Find("Player").GetComponent<AutomatedControls>();
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.name == "Player")
        {
            Debug.Log("Jump!");
            _controller.m_Jump = true;
        }
    }
}
