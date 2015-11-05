using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class MenuButton : MonoBehaviour
{
    public static string PlayerName = "unknown";
    public static int PlayerGender = 2;
    public static int PlayerBirthYear = 1900;

    public void StartGame()
    {
        NewPlayer(PlayerName, PlayerGender, PlayerBirthYear);

        Application.LoadLevel(1);
    }

    private void NewPlayer(string _name = "unknown", int _gender = 2, int _birthYear = 1950)
    {
        Analytics.CustomEvent("Newlayer", new Dictionary<string, object>
        {
            { "player_name", _name},
            { "player_gender", _gender},
            { "player_birthYear", _birthYear}
        });

        switch (_gender)
        {
            case 0:
                Analytics.SetUserGender(Gender.Male);
                break;
            case 1:
                Analytics.SetUserGender(Gender.Female);
                break;
            case 2:
                Analytics.SetUserGender(Gender.Unknown);
                break;
        }

        Analytics.SetUserBirthYear(_birthYear);
    }

    public void SetName(string _name)
    {
        PlayerName = _name;
    }
    public void SetGender(int _gender)
    {
        PlayerGender = _gender;
    }
    public void SetYear(string _year)
    {
        PlayerBirthYear = int.Parse(_year);
    }
}
