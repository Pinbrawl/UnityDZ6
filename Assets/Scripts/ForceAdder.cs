using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceAdder : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _rigidbody.AddForce(_transform.forward * _force);
    }
}
