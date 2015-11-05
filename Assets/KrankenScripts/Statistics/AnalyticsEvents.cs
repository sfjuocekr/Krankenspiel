using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsEvents : MonoBehaviour
{
    private PlayerInfo _player;
    private bool _registeredScore = false;

    private void Awake()
    {
        _player = GameObject.Find("GUI").GetComponent<PlayerInfo>();
    }

    public void RegisterARTime(string _name, float _time, int _triggerTime, bool _failed)
    {
        Analytics.CustomEvent("AR Interaction", new Dictionary<string, object>
                {
                    {"AR Object", _name},
                    {"Time spend on object", _time},
                    {"Trigger time", _triggerTime},
                    {"Failed", _failed}
                });

            _player.AddScore(_failed ? -(_time / _triggerTime) : (_time / _triggerTime));
    }

    public void RegisterScore(string _name, float _time, float _score)
    {
        Analytics.CustomEvent("New score", new Dictionary<string, object>
                {
                    {"Player name", _name},
                    {"Time spend in level", _time},
                    {"Player score", _score}
                });
    }

    void OnDestroy()
    {
        if (_registeredScore) return;

        _registeredScore = true;

        RegisterScore(_player._playerName.text, Time.time - _player._startTime, int.Parse(_player._scoreText.text));
    }
}
