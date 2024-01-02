using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : BaseUI
{
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button ButtonQuit;

    protected override void Awake()
    {
        base.Awake();

        ButtonPlay.onClick.AddListener(OnButtonPlayClicked);
        ButtonQuit.onClick.AddListener(OnButtonQuitClicked);
    }

    private void OnButtonPlayClicked()
    {
        GameManager.Instance.StateMachine.TransitionTo<GameplayState>();
    }

    private void OnButtonQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
