using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;

    private int leftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingProgress;

    private void Start()
    {
        _spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingProgress?.Invoke(leftToFill);
    }

    public void Fill()
    {
        _filling++;
        FillingProgress?.Invoke(leftToFill);
        if (_filling == _destroyPrice)
            GameObject.Destroy(gameObject);
    }
}
