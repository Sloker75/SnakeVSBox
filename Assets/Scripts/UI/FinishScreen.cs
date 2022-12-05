using UnityEngine;
using TMPro;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _finishScoreText;

    private void Update() => _finishScoreText.text = $"Your Score: {_score.ScoreValue}";

}
