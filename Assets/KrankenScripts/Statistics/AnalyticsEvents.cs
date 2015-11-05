using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsEvents : MonoBehaviour
{
    private PlayerScore _player;

    private void Awake()
    {
        _player = GameObject.Find("GUI").GetComponent<PlayerScore>();
    }

    public void RegisterARTime(string _name, float _time, int _triggerTime, bool _failed)
    {
        Analytics.CustomEvent("AR Interaction", new Dictionary<string, object>
                {
                    {"AR Object", _name},
                    {"Time spend", _time},
                    {"Trigger time", _triggerTime},
                    {"Failed", _failed}
                });

            _player.AddScore(_failed ? -(_time / _triggerTime) : (_time / _triggerTime));
    }
}
