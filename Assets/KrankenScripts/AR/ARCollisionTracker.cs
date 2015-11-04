using UnityEngine;
using System.Collections.Generic;

public class ARCollisionTracker : MonoBehaviour
{
    public List<GameObject> TrackedObjects;

    private Dictionary<GameObject, float> _collisions = new Dictionary<GameObject, float>();
    private GameObject _lastActiveCollider = null;

    private float _triggerTime;
    private AnalyticsEvents _analytics;

    void Awake()
    {
        _analytics = gameObject.AddComponent<AnalyticsEvents>();
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject))
        {
            float _collisionTime;

            if (!_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _triggerTime = Time.time;
                _lastActiveCollider = _collider.gameObject;
                _collisions.Add(_collider.gameObject,  _triggerTime - Time.time);
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
                _collisionTime = Time.time - _triggerTime;

                int _seconds = Mathf.RoundToInt(_collisionTime);

                if (_collisionTime >= _seconds && _collisionTime <= _seconds + Time.deltaTime)
                    _collider.gameObject.SendMessage("CollisionTime", _seconds);

                _collisions.Remove(_collider.gameObject);
                _collisions.Add(_collider.gameObject, _collisionTime);
            }
        }
        else
            OnTriggerEnter(_collider);
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
                _analytics.RegisterARTime(_collider.name, _collisionTime, _collider.gameObject.GetComponent<MessageHandler>().TriggerTime, (_collider.gameObject.GetComponent<MessageHandler>().TriggerTime >= _collisionTime));
                _lastActiveCollider = null;
            }
        }
    }

    void Update()
    {
        float _collisionTime;

        if (!GetComponent<MeshRenderer>().enabled && _lastActiveCollider != null && _collisions.TryGetValue(_lastActiveCollider, out _collisionTime))
        {
            _lastActiveCollider.SendMessage("CollisionTime", Mathf.RoundToInt(-1));
            _collisions.Remove(_lastActiveCollider);
            _analytics.RegisterARTime(_lastActiveCollider.name, _collisionTime, _lastActiveCollider.GetComponent<MessageHandler>().TriggerTime, (_lastActiveCollider.GetComponent<MessageHandler>().TriggerTime >= _collisionTime));
            _lastActiveCollider = null;
        }
    }
}
