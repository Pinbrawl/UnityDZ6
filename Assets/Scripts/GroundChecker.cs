using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundDistance;

    private Transform _transform;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        IsGrounded = Physics.Raycast(_transform.position, -_transform.up, _groundDistance);
    }
}
