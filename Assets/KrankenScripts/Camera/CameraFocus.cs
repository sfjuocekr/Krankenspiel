using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private GameObject FocusTarget;
    private float _initialOffset;

    private void Awake()
    {
        FocusTarget = GameObject.Find("Player");
    }

    private void Start()
    {
        _initialOffset = transform.position.y;
    }

    private void Update()
    {
        if (FocusTarget == null)
        {
            FocusTarget = GameObject.Find("Player");

            if (FocusTarget == null)
                transform.position = new Vector3(0, 0, transform.position.z);
        }
        else
        {
            Vector3 _position = FocusTarget.transform.position;
            _position.y = FocusTarget.transform.position.y + _initialOffset;
            _position.z = transform.position.z;

            transform.position = _position;
        }
    }
}
