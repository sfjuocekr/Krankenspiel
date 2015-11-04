using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Text _scoreText;

    private float _score = 0.0f;

    private void Awake()
    {
        _scoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
    }

    public void AddScore(float _points)
    {
        Debug.Log(_points);

        _score += _points;

        if (_score < 0)
            _score = 0;

        _scoreText.text = Mathf.RoundToInt(_score).ToString();
    }
}
