using UnityEngine;

public class PlayerSizeChanger : MonoBehaviour
{
    [SerializeField] private float _sizeChangeSpeed;
    [SerializeField] private float _sizeScale;
    [SerializeField] private float _maxSize = 3f;
    [SerializeField] private float _minSize = .7f;

    public delegate void ScaleAction(float speed);
    public static event ScaleAction OnSizeChange;

    private Rigidbody2D _rb;

    public void Increase()
    {
        if(transform.localScale.x < _maxSize && transform.localScale.y < _maxSize)
        {
            transform.localScale += new Vector3(_sizeScale * _sizeChangeSpeed * Time.deltaTime, _sizeScale * _sizeChangeSpeed * Time.deltaTime, 0f);
            OnSizeChange?.Invoke(transform.localScale.x);
        }
    }

    public void Decrease()
    {
        if (transform.localScale.x > _minSize && transform.localScale.y > _minSize)
        {
            transform.localScale -= new Vector3(_sizeScale * _sizeChangeSpeed * Time.deltaTime, _sizeScale * _sizeChangeSpeed * Time.deltaTime, 0f);
            OnSizeChange?.Invoke(transform.localScale.x);
        }
    }
}
