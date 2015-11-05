using UnityEngine;
using System.Collections.Generic;

public class ARCollisionTracker : MonoBehaviour
{
    public List<GameObject> TrackedObjects;

    private Dictionary<GameObject, float> _collisions = new Dictionary<GameObject, float>();
    private GameObject _lastActiveCollider = null;
    private AnalyticsEvents _analytics;
    private float _triggerTime = 0f;
    private bool _justTriggered = false;

    private void Awake()
    {
        _analytics = gameObject.AddComponent<AnalyticsEvents>();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject))
        {
            _lastActiveCollider = _collider.gameObject;
            _triggerTime = Time.time;

            float _collisionTime;

            if (!_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collisions.Add(_collider.gameObject,  _triggerTime - Time.time);
            }
            else
            {
                _collisions.Remove(_collider.gameObject);
                _collisions.Add(_collider.gameObject, _collisionTime);
            }
        }
    }

    private void OnTriggerStay(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject) && _lastActiveCollider == _collider.gameObject)
        {
            float _collisionTime;

            if (_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collisionTime = Time.time - _triggerTime;

                if (_collisionTime >= Mathf.RoundToInt(_collisionTime) && _collisionTime <= Mathf.RoundToInt(_collisionTime) + Time.fixedDeltaTime && !_justTriggered)
                {
                    _collider.gameObject.SendMessage("CollisionTime", Mathf.RoundToInt(_collisionTime));

                    _justTriggered = true;
                }
                else
                    _justTriggered = false;

                _collisions.Remove(_collider.gameObject);
                _collisions.Add(_collider.gameObject, _collisionTime);
            }
            else
                OnTriggerEnter(_collider);
        }
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (_collider.gameObject == TrackedObjects.Contains(_collider.gameObject) && _lastActiveCollider == _collider.gameObject)
        {
            float _collisionTime;

            if (_collisions.TryGetValue(_collider.gameObject, out _collisionTime))
            {
                _collisionTime = Time.time - _triggerTime;

                if (Debug.isDebugBuild)
                    Debug.Log("OnTriggerExit => _collisionTime: " + _collisionTime + " Rounded:" + Mathf.RoundToInt(_collisionTime));

                _collider.gameObject.SendMessage("CollisionTime", Mathf.RoundToInt(-1));
                _collisions.Remove(_collider.gameObject);
                _analytics.RegisterARTime(_collider.name, _collisionTime, _collider.gameObject.GetComponent<MessageHandler>().TriggerTime, (_collider.gameObject.GetComponent<MessageHandler>().TriggerTime >= _collisionTime));
                _lastActiveCollider = null;
            }
        }
    }
    
    private void Update()
    {
        float _collisionTime;

        if (!GetComponentInChildren<MeshRenderer>().enabled && _lastActiveCollider != null && _collisions.TryGetValue(_lastActiveCollider, out _collisionTime))
        {
            _collisionTime = Time.time - _triggerTime;

            if (Debug.isDebugBuild)
                Debug.Log("Update => _collisionTime: " + _collisionTime + " Rounded:" + Mathf.RoundToInt(_collisionTime));

            _lastActiveCollider.SendMessage("CollisionTime", Mathf.RoundToInt(-1));
            _collisions.Remove(_lastActiveCollider);
            _analytics.RegisterARTime(_lastActiveCollider.name, _collisionTime, _lastActiveCollider.GetComponent<MessageHandler>().TriggerTime, (_lastActiveCollider.GetComponent<MessageHandler>().TriggerTime >= _collisionTime));
            _lastActiveCollider = null;
        }
    }
}
