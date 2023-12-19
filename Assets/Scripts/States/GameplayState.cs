using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : BaseState
{
    private float TimeRemaining;

    private const float TIME_DURATION = 10;

    public override void OnStart(GameManager gameManager)
    {
        base.OnStart(gameManager);

        TimeRemaining = TIME_DURATION;

        //TODO display gameplay UI
        GameManager.InputManager.EnableGameplay();
        Debug.Log("OnStart GameplayState");
    }

    public override void OnTick()
    {
        base.OnTick();

        TimeRemaining -= Time.deltaTime;
        //TODO set UI timer

        if (TimeRemaining <= 0)
        {
            GameManager.StateMachine.TransitionTo<EndGameState>();
        }

        Debug.Log(TimeRemaining);
    }

    public override void OnEnd()
    {
        base.OnEnd();

        //TODO hide gameplay UI
        GameManager.InputManager.DisableGameplay();

        Debug.Log("OnEnd GameplayState");
    }
}
