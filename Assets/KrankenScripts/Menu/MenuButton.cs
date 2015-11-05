using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;
using System.Security.Cryptography;
using System.Text;

public class MenuButton : MonoBehaviour
{
    public static string PlayerName = "Anonymous";
    public static int PlayerGender = 2;
    public static int PlayerBirthYear = 1900;

    public void StartGame()
    {
        NewPlayer(PlayerName, PlayerGender, PlayerBirthYear);

        Application.LoadLevel(1);
    }

    private void NewPlayer(string _name, int _gender, int _birthYear)
    {
        if (_name == "Anonymous")
        {
            SHA1 _SHA = SHA1.Create();
            byte[] _bytes = ASCIIEncoding.ASCII.GetBytes((Time.time * Random.Range(-255, 255) * Random.Range(-255, 255)).ToString());
            byte[] _hash = _SHA.ComputeHash(_bytes);
            StringBuilder _stringBuilder = new StringBuilder();

            for (int i = 0; i < _hash.Length; i++)
                _stringBuilder.Append(_hash[i].ToString("x2"));

            PlayerName += _stringBuilder.ToString();

            Debug.Log(PlayerName);
        }

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
