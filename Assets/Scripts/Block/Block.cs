using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;

    private int leftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingProgress;

    private void Start()
    {
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
