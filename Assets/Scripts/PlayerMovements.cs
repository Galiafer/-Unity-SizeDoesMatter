using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _multiplier = 1f;
    private float _additionalMuliplier = 1.5f;
    private Vector3 _direction = new Vector3(1f, 0f, 0f);

    private void OnEnable() => PlayerSizeChanger.OnSizeChange += Multiplier;

    private void OnDisable() => PlayerSizeChanger.OnSizeChange -= Multiplier;

    public void Move()
    {
        if(Input.GetAxisRaw("Horizontal") == 1f)
        {
            transform.position += _direction * (_speed / _multiplier) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            transform.position -= _direction * (_speed / _multiplier) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
    }

    public void Jump() => _rb.AddForce(Vector2.up * (_multiplier * _additionalMuliplier / _jumpForce), ForceMode2D.Impulse);

    private void Multiplier(float scale) => _multiplier = scale;
}
