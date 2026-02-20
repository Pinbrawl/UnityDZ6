using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode KeyAddForce = KeyCode.Q;
    private KeyCode KeyShoot = KeyCode.W;
    private KeyCode KeyGetReady = KeyCode.E;

    public event Action ForceAdding;
    public event Action Shooting;
    public event Action GettingReady;

    private void Update()
    {
        if(Input.GetKeyDown(KeyAddForce))
            ForceAdding?.Invoke();

        if(Input.GetKeyDown(KeyShoot))
            Shooting?.Invoke();
        else if (Input.GetKeyDown(KeyGetReady))
            GettingReady?.Invoke();
    }
}
