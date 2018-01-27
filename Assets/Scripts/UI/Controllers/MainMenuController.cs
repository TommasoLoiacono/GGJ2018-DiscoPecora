using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    /// <summary>
    /// Called by the button Play
    /// </summary>
    public void StartGame()
    {
        GameManager.I.ChangeState(FlowState.Gameplay);    
    }

    /// <summary>
    /// Called by the button Exit
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }

}
