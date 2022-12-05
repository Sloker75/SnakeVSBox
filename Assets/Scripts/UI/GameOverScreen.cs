using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _gameOverScoreText;

    private void Update() => _gameOverScoreText.text = $"Your Score: {_score.ScoreValue}";
}
