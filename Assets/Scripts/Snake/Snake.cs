using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;

    private TailSpawner _tailSpawner;

    private void Start()
    {
        _tailSpawner = GetComponent<TailSpawner>();
        _tailSpawner.Generate();
    }

    private void FixedUpdate()
    {
        _snakeHead.Move(_snakeHead.transform.position + _snakeHead.transform.up * (_speed * Time.fixedDeltaTime));
    }
}
