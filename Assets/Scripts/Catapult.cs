using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Catapult : MonoBehaviour
{
    readonly private string IsShootAnimatorName = "IsShoot";

    private Animator _animator;

    public event Action GettingReady;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool(IsShootAnimatorName, true);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetBool(IsShootAnimatorName, false);
            GettingReady?.Invoke();
        }
    }
}
