using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private CharacterController _characterController;
    private Player _player;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Vector3 forwardDirection = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 strafeDirection = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;

        if (forwardDirection != Vector3.zero || strafeDirection != Vector3.zero)
            Move(forwardDirection, strafeDirection);
    }

    private void Move(Vector3 forwardDirection, Vector3 strafeDirection)
    {
        Vector3 moveDirection = forwardDirection * Input.GetAxis("Vertical") * _player.PlayerSpeed + strafeDirection * Input.GetAxis("Horizontal") * _player.PlayerStrafeSpeed;

        if (_characterController.isGrounded)
            _characterController.Move(moveDirection * Time.deltaTime + Vector3.down);
        else
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);

        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * _player.HorizontalTurnSensitivity * Input.GetAxis("Mouse X"));
    }
}
