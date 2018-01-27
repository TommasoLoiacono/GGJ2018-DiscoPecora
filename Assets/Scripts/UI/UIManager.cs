using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [HideInInspector]
    public GameplayPanelController gameplayCtrl;
    [HideInInspector]
    public MainMenuController mainMenuCtrl;

    public void Init()
    {
        gameplayCtrl = GetComponentInChildren<GameplayPanelController>();
        mainMenuCtrl= GetComponentInChildren<MainMenuController>();
        gameplayCtrl.Init();
    }

    public  void MenuActions()
    {
        gameplayCtrl.gameObject.SetActive(false);
        mainMenuCtrl.gameObject.SetActive(true);
    }

    public void GameplayActions()
    {
        gameplayCtrl.gameObject.SetActive(true);
        mainMenuCtrl.gameObject.SetActive(false);
    }
    
    public void GameOverActions()
    {

    }
}
