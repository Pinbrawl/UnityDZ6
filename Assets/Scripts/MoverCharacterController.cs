using UnityEngine;

public class MoverCharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalTurnSensitivity;
    [SerializeField] private float _verticalTurnSensitivity;
    [SerializeField] private float _verticalMinAngle;
    [SerializeField] private float _verticalMaxAngle;
    [SerializeField] private float _gravityFactor;

    private Transform _transform;
    private CharacterController _characterController;
    private float _cameraAngle;
    private Vector3 _verticalVelocity;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _cameraAngle = _cameraTransform.localEulerAngles.x;
        _verticalVelocity = Vector3.zero;
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        _cameraAngle -= Input.GetAxis("Mouse Y") * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;

        _transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * _horizontalTurnSensitivity);
    }

    private void Move()
    {
        Vector3 forward = Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
        Vector3 moveDirection = right * Input.GetAxis("Horizontal") + forward * Input.GetAxis("Vertical");

        if (_characterController.isGrounded)
        {
            Jump();
        }
        else
        {
            Vector3 horizontalVelocity = _characterController.velocity;
            horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
        }

        _characterController.Move((moveDirection * _moveSpeed + _verticalVelocity) * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _verticalVelocity = Vector3.up * _jumpForce;
        else
            _verticalVelocity = Physics.gravity * _gravityFactor;
    }
}
