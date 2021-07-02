using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovements _playerMovements;
    [SerializeField] private PlayerSizeChanger _sizeChanger;
    [SerializeField] private GroundChecker _groundChecker;
    
    private void Update()
    {
        _playerMovements.Move();

        #region Scale Controlling
        if (Input.GetKey(KeyCode.W))
            _sizeChanger.Increase();

        if (Input.GetKey(KeyCode.S))
            _sizeChanger.Decrease();
        #endregion

        #region Jump Controlling
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded())
            _playerMovements.Jump();
        #endregion

        #region Animation Controlling
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            _animator.SetBool("isRunning", true);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _animator.SetBool("isRunning", false);
        #endregion
    }
}
