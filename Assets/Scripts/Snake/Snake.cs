using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;

    private SnakeInput _snakeInput;
    private TailSpawner _tailSpawner;
    private List<Segment> _tailSegments;

    private void Start()
    {
        _tailSpawner = GetComponent<TailSpawner>();
        _snakeInput = GetComponent<SnakeInput>();
        _tailSegments = _tailSpawner.Generate();
    }

    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * (_speed * Time.fixedDeltaTime));

        _snakeHead.transform.up = _snakeInput.GetDeractionToClick(_snakeHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        var previuosPosition = _snakeHead.transform.position;

        foreach (var tailSegment in _tailSegments)
        {
            var tempPosition = tailSegment.transform.position;
            tailSegment.transform.position = Vector2.Lerp(tailSegment.transform.position, 
                previuosPosition, 
                _tailSpringiness * Time.fixedDeltaTime);
            previuosPosition = tempPosition;
        }
        _snakeHead.Move(nextPosition);
    }
}
