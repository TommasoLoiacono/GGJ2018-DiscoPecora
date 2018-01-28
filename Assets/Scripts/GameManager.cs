using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public static GameManager I;

    public GameObject UIManagerPrefab;

    public int timeToShutOffHightlight = 10;

    [HideInInspector]
    public UIManager UIMng;
    [HideInInspector]
    public DiscoPecoraGame DiscoPecora;
    [HideInInspector]
    public AudioManager AudioMng;


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
            case FlowState.Titles:
                    TitlesActions();
                break;
            case FlowState.MainMenu:
                if(_oldState == FlowState.Gameover)
                    MenuActions();
                break;
            case FlowState.Gameplay:
                if (_oldState == FlowState.MainMenu)
                    GameplayActions();
                if (_oldState == FlowState.Pause)
                    ReactivateGame();
                break;
            case FlowState.Pause:
                if (_oldState == FlowState.Gameplay)
                    PauseActions();
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

    void Start () {
        #region singleton
        if (I == null)
            I = this;
        else
            DestroyImmediate(gameObject);
        #endregion

        DiscoPecora = GetComponent<DiscoPecoraGame>();
        Init();                                                 //TODO: Da spostare nella macchina a stati
        Cursor.lockState = CursorLockMode.Confined;
	}

    private void Update()
    {
        if (CurrentState == FlowState.Gameplay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DiscoPecora.Accoppia();
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit(); 
        }
    }

    /// <summary>
    /// Create the UI and set the first State of the state machine to MainMenu state.
    /// </summary>
    public void Init()
    {
        UIMng = Instantiate(UIManagerPrefab, transform).GetComponent<UIManager>();
        UIMng.Init();
        CurrentState = FlowState.Titles;
    }

    void TitlesActions()
    {
        UIMng.TitlePanel.DOFade(1, 2).OnComplete(() => 
        {
            UIMng.TitlePanel.DOFade(0, 2).OnComplete(() => 
            {
                UIMng.TitlePanelBackGround.DOFade(0, 1).OnComplete(() => 
                {
                    UIMng.TitlePanelBackGround.gameObject.SetActive(false);
                    ChangeState(FlowState.MainMenu);
                });
            });
        });

    }
    IEnumerator ShutOffDx()
    {
        yield return new WaitForSeconds(timeToShutOffHightlight);
        UIMng.secondSheepOff.SetActive(true);
        UIMng.DeactivateSpotLight2();


    }
    IEnumerator ShutOffSx()
    {
        yield return new WaitForSeconds(timeToShutOffHightlight);
        UIMng.firstSheepOff.SetActive(true);
        UIMng.DeactivateSpotLight1();
    }

    /// <summary>
    /// The action when the current state is GamePlay
    /// </summary>
    void MenuActions()
    {
        UIMng.MenuActions();
    }

    /// <summary>
    /// The action when the current state is Gameplay
    /// </summary>
    void GameplayActions()
    {
        UIMng.GameplayActions();
        DiscoPecora.Init();
    }

    /// <summary>
    /// The actions when the old status was pause and you want to restart the gameplay
    /// </summary>
    void ReactivateGame()
    {
        UIMng.PauseActions(false);
        DiscoPecora.giocoAttivo = true;
    }

    /// <summary>
    /// The action when the current state is Pause
    /// </summary>
    void PauseActions()
    {
        UIMng.PauseActions(true);
        DiscoPecora.giocoAttivo = false;
    }

    /// <summary>
    /// The action when the current state is Gameover
    /// </summary>
    void GameOverActions()
    {

    }
}

public enum FlowState
{
    Titles,
    MainMenu,
    Gameplay,
    Pause,
    Gameover
}
