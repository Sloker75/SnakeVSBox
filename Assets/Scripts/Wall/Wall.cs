using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Vector2Int _scaleValueRange;

    private int scaleVlaue;

    private void Start()
    {
        scaleVlaue = Random.Range(_scaleValueRange.x, _scaleValueRange.y);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + scaleVlaue, transform.localScale.z);
    }
}
