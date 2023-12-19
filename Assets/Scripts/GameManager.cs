using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public InputManager InputManager { get; private set; }
    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        Instance = this;
        InputManager = new();
        StateMachine = new(this);

        StateMachine.TransitionTo<GameplayState>();
    }

    private void Update()
    {
        StateMachine.OnTick();
    }
}
