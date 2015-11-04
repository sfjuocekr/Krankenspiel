using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        NewPlayer();
        Application.LoadLevel(1);
    }

    private void NewPlayer(string _name = "unknown", string _gender = "unknown", int _birthYear = 1900)
    {
        Analytics.CustomEvent("Newlayer", new Dictionary<string, object>
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
}
