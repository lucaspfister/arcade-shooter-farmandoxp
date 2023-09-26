using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Transform Pivot;
    [SerializeField] private Transform ShotOrigin;
    [SerializeField] private float RotationSpeed;

    private void Start()
    {
        GameManager.Instance.InputManager.OnShoot += OnShoot;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector2 movement = GameManager.Instance.InputManager.Movement;
        float speed = RotationSpeed * Time.deltaTime;
        Pivot.Rotate(movement.y * speed, 0, 0, Space.Self);
        Pivot.Rotate(0, movement.x * speed, 0, Space.World);
    }

    private void OnDestroy()
    {
        GameManager.Instance.InputManager.OnShoot -= OnShoot;
    }

    private void OnShoot()
    {
        //TODO
        Debug.Log("SHOOT");
    }
}
