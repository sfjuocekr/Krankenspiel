using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ARCollisionTracker : MonoBehaviour
{
    public List<GameObject> TrackedObjects;
    private Dictionary<GameObject, float> _collisions = new Dictionary<GameObject, float>();

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject))
        {
            float _collisionTime;

            if (!_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collisions.Add(_collider.gameObject, 0.0f);
            }
        }
    }

    void OnTriggerStay(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject))
        {
            float _collisionTime;

            if (_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collisionTime += Time.deltaTime;

                int _seconds = Mathf.RoundToInt(_collisionTime);

                if (_collisionTime >= _seconds && _collisionTime <= _seconds + Time.deltaTime)
                    _collider.gameObject.SendMessage("CollisionTime", Mathf.RoundToInt(_seconds));

                _collisions.Remove(_collider.gameObject);
                _collisions.Add(_collider.gameObject, _collisionTime);
            }
        }
    }

    void OnTriggerExit(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject))
        {
            float _collisionTime;

            if (_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collider.gameObject.SendMessage("CollisionTime", Mathf.RoundToInt(-1));

                _collisions.Remove(_collider.gameObject);
            }
        }
    }
}
