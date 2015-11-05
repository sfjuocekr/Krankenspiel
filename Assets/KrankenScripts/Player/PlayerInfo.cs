using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private Text _playerName;
    private Text _scoreText;
    private float _score = 0.0f;

    private void Awake()
    {
        _playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        _scoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
    }

    private void Start()
    {
        _playerName.text = MenuButton.PlayerName;
    }

    public void AddScore(float _points)
    {
        _score += _points;

        if (_score < 0)
            _score = 0;

        _scoreText.text = Mathf.RoundToInt(_score).ToString();
    }
}
