using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager I;

    public GameObject UIManagerPrefab;
    public GameObject DiscoPecoraTheGamePrefab;

    [HideInInspector]
    public UIManager UIMng;
    [HideInInspector]
    public DiscoPecoraGame DiscoPecora;

    #region GameFlow StateMachine
    private FlowState _currentState;

    public FlowState CurrentState
    {
        get { return _currentState; }
        private set
        {
            FlowState oldState = _currentState;
            _currentState = value;
            OnStateChanged(_currentState, oldState);
        }
    }

    void OnStateChanged(FlowState _newState, FlowState _oldState)
    {
        switch (_newState)
        {
            case FlowState.MainMenu:
                if(_oldState == FlowState.Gameover)
                    MenuActions();
                break;
            case FlowState.Gameplay:
                if (_oldState == FlowState.MainMenu)
                    GameplayActions();
                break;
            case FlowState.Gameover:
                if (_oldState == FlowState.Gameplay)
                    GameOverActions();
                break;
        }
    }

    public void ChangeState(FlowState _stateToSet)
    {
        CurrentState = _stateToSet;
    }
    #endregion

    // Use this for initialization
    void Start () {
        if (I == null)
            I = this;
        else
            DestroyImmediate(gameObject);

        Cursor.lockState = CursorLockMode.Confined;
	}
	
    public void Init()
    {
        Instantiate(UIManagerPrefab, transform);
    }

    void MenuActions()
    {
        UIMng.MenuActions();
    }

    void GameplayActions()
    {
        UIMng.GameplayActions();
    }

    void GameOverActions()
    {

    }
}

public enum FlowState
{
    MainMenu,
    Gameplay,
    Gameover
}
