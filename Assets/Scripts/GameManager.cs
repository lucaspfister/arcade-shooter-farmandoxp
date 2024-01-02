using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UIManager UIManager;

    public InputManager InputManager { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public int Score { get; private set; } = 0;

    private void Awake()
    {
        Instance = this;
        InputManager = new();
        StateMachine = new(this);
    }

    private void Start()
    {
        StateMachine.TransitionTo<GameplayState>();
    }

    private void Update()
    {
        StateMachine.OnTick();
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}
