using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [HideInInspector]
    public Text _playerName { get; private set; }
    [HideInInspector]
    public Text _scoreText { get; private set; }
    [HideInInspector]
    public float _startTime { get; private set; }

    private float _score = 0.0f;

    private void Awake()
    {
        _playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        _scoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
    }

    private void Start()
    {
        _playerName.text = MenuButton.PlayerName;
        _startTime = Time.time;
    }

    public void AddScore(float _points)
    {
        _score += _points;

        if (_score < 0)
            _score = 0;

        _scoreText.text = Mathf.RoundToInt(_score * 10).ToString();
    }
}
