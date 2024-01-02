using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : BaseState
{
    public override void OnStart(GameManager gameManager)
    {
        base.OnStart(gameManager);

        GameManager.UIManager.EndGameUI.Enable(GameManager.Score);
    }

    public override void OnEnd()
    {
        base.OnEnd();

        GameManager.UIManager.EndGameUI.Disable();
    }
}
