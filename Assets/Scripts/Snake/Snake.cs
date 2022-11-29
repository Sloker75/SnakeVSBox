using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;
    [SerializeField] private int _tailSize;

    private SnakeInput _snakeInput;
    private TailSpawner _tailSpawner;
    private List<Segment> _tailSegments;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _tailSpawner = GetComponent<TailSpawner>();
        _snakeInput = GetComponent<SnakeInput>();
        _tailSegments = _tailSpawner.Generate(_tailSize);

        SizeUpdated?.Invoke(_tailSegments.Count);
    }

    private void OnEnable()
    {
        _snakeHead.BlockCollided += OnBlockCollided;
        _snakeHead.BonusPicUp += OnBonusPicUp;
    }
    private void OnDisable()
    {
        _snakeHead.BlockCollided -= OnBlockCollided;
        _snakeHead.BonusPicUp -= OnBonusPicUp;
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

    private void OnBlockCollided()
    {
        var deletedSegment = _tailSegments[_tailSegments.Count - 1];
        _tailSegments.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);

        SizeUpdated?.Invoke(_tailSegments.Count);
    }

    private void OnBonusPicUp(int bonusValue)
    {
        _tailSegments.AddRange(_tailSpawner.Generate(bonusValue));

        SizeUpdated?.Invoke(_tailSegments.Count);
    }
}
