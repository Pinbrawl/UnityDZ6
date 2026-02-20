using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceAdder : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void OnEnable()
    {
        _inputReader.ForceAdding += AddForce;
    }

    private void OnDisable()
    {
        _inputReader.ForceAdding -= AddForce;
    }

    private void AddForce()
    {
        _rigidbody.AddForce(_transform.forward * _force);
    }
}
