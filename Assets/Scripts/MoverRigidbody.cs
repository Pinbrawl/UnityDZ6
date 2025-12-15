using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverRigidbody : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _obstacleDistance;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void Update()
    {
        CheckGround();

        if(Mathf.Abs(_playerTransform.position.x - _transform.position.x) > _maxDistance || Mathf.Abs(_playerTransform.position.y - _transform.position.y) > _maxDistance || Mathf.Abs(_playerTransform.position.z - _transform.position.z) > _maxDistance) 
        {
            Move();
            Jump();
        }
    }

    private void Move()
    {
        _transform.LookAt(new Vector3(_playerTransform.position.x, _transform.position.y, _playerTransform.position.z));
        _rigidbody.velocity = _transform.forward * _moveSpeed * Time.deltaTime + new Vector3(0, _rigidbody.velocity.y, 0);
    }

    private void Jump()
    {
        if(Physics.Raycast(_transform.position + new Vector3(0, -0.9f, 0), _transform.forward, _obstacleDistance) && _isGrounded)
            _rigidbody.AddForce(0, _jumpForce, 0, ForceMode.Impulse);

        Debug.DrawRay(_transform.position + new Vector3(0, -0.9f, 0), _transform.forward, Color.red, _obstacleDistance);
    }

    private void CheckGround()
    {
        if(Physics.Raycast(_transform.position, -_transform.up, _groundDistance))
            _isGrounded = true;
        else
            _isGrounded = false;
    }
}
