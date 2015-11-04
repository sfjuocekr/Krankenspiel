using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(Vector3.up, 5 * Time.deltaTime);
    }
}
