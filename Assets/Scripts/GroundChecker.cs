using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _rayPosition;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _rayDist;

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(_rayPosition.position, Vector2.down, _rayDist, _layerMask))
            return true;

        return false;
    }
}
