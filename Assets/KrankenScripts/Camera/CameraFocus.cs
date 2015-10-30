using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public GameObject FocusTarget;

    private float _initialOffset;

    void Start()
    {
        if (FocusTarget == null)
        {
            FocusTarget = GameObject.Find("Player");
        }

        _initialOffset = transform.position.y;
    }

    void Update()
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
