using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public event UnityAction BlockCollided;
    public event UnityAction Finish;
    public event UnityAction<int> BonusPicUp;

    private void Start() => _rigidbody2D = GetComponent<Rigidbody2D>();

    public void Move(Vector3 newPossition) => _rigidbody2D.MovePosition(newPossition);

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent(out Block block))
        {
            block.Fill();
            BlockCollided?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bonus bonus))
            BonusPicUp?.Invoke(bonus.PicUp());
        else if (collision.TryGetComponent(out Finish finish))
            Finish?.Invoke();
    }

}
