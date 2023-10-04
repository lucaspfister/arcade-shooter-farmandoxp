using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float Duration;

    private Rigidbody Rigidbody;
    private Action<CannonBall> Callback;
    private bool IsShooting = false;
    private float CurrentDuration;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 force, Action<CannonBall> callback)
    {
        Rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(true);
        Callback = callback;
        Rigidbody.AddForce(force, ForceMode.Impulse);
        CurrentDuration = 0;
        IsShooting = true;
    }

    private void Update()
    {
        if (!IsShooting) return;

        CurrentDuration += Time.deltaTime;

        if (CurrentDuration >= Duration)
        {
            IsShooting = false;
            Callback?.Invoke(this);
        }
    }
}
