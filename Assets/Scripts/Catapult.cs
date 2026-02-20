using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private readonly string _isShootAnimatorName = "IsShoot";

    private Animator _animator;

    public event Action GettingReady;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputReader.Shooting += Shoot;
        _inputReader.GettingReady += GetReady;
    }

    private void OnDisable()
    {
        _inputReader.Shooting -= Shoot;
        _inputReader.GettingReady -= GetReady;
    }

    private void Shoot()
    {
        _animator.SetBool(_isShootAnimatorName, true);
    }

    private void GetReady()
    {
        _animator.SetBool(_isShootAnimatorName, false);
        GettingReady?.Invoke();
    }
}
