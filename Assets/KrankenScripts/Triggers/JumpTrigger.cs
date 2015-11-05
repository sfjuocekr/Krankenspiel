using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] float JumpPower = 6.0f;

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
                Debug.Log("Jump!");

            _controller.m_jumpPower = JumpPower;
            _controller.m_Jump = true;
        }
    }

    private void Update()
    {
        if (Time.deltaTime - _justTriggered > 1)
            _justTriggered = 0f;
    }
}
