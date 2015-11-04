using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsEvents : MonoBehaviour
{
    private PlayerScore _player;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerScore>();
    }

    private void Start()
    {
        AddPlayer("Sjoer", "Male", 1985);
    }

    public void AddPlayer(string _name = "unknown", string _gender = "unknown", int _birthYear = 1900)
    {
        Analytics.CustomEvent("AddPlayer", new Dictionary<string, object>
        {
            { "player_name", _name},
            { "player_gender", _gender},
            { "player_birthYear", _birthYear}
        });

        switch (_gender)
        {
            case "Male":
                Analytics.SetUserGender(Gender.Male);
                break;
            case "Female":
                Analytics.SetUserGender(Gender.Female);
                break;
            case "Unknown":
                Analytics.SetUserGender(Gender.Unknown);
                break;
        }

        Analytics.SetUserBirthYear(_birthYear);
    }

    public void RegisterARTime(string _name, float _time, int _triggerTime, bool _failed)
    {
        Debug.Log(_failed);

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
