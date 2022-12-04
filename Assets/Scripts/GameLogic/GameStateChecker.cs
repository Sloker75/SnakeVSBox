using UnityEngine;

public class GameStateChecker : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;

    private void OnEnable()
    {
        _snakeHead.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _snakeHead.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {

    }
}
