using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TextController : MonoBehaviour
{
    private GameObject _focusTarget;
    private AutomatedControls _playerController;
    private Canvas _canvas;

    private float _initialOffset;

    private void Awake()
    {
        _focusTarget = GameObject.Find("Player");
        _playerController = _focusTarget.GetComponent<AutomatedControls>();
        _canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        _initialOffset = transform.position.y;
    }

    private void Update()
    {
        _canvas.enabled = !_playerController.m_Moving;

        if (_canvas.enabled)
        {
            Vector3 _position = _focusTarget.transform.position;
                    _position.y = _focusTarget.transform.position.y + _initialOffset;

            transform.position = _position;
        }
    }
}
