using UnityEngine;
using UnityEngine.UI;

public class GameStateChecker : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Snake _snake;
    [SerializeField] private SnakeHead _snakeHead;

    [Header("Finish")]
    [SerializeField] private FinishScreen _finishScreen;
    [SerializeField] private Button _reloadFinishButton;

    [Header("GameOver")]
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Button _reloadGameOverButton;

    private void OnEnable()
    {
        _snakeHead.Finish += OnFinish;
        _snake.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _snakeHead.Finish -= OnFinish;
        _snake.GameOver += OnGameOver;
    }

    private void OnFinish()
    {
        _finishScreen.gameObject.SetActive(true);
        _reloadFinishButton.interactable = true;
    }

    private void OnGameOver()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _reloadGameOverButton.interactable = true;
        _snakeHead.gameObject.SetActive(false);
    }
}
