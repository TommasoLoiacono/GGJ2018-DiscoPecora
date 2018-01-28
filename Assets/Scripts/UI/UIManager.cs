using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [HideInInspector]
    public GameplayPanelController gameplayCtrl;
    [HideInInspector]
    public MainMenuController mainMenuCtrl;

    public Image TitlePanelBackGround;
    public Image TitlePanel;
    public SpotLightController SpotLight1;
    public SpotLightController SpotLight2;
    public GameObject firstSheepOff;
    public GameObject secondSheepOff;
    public GameObject PausePanel;

    public void Init()
    {
        gameplayCtrl = GetComponentInChildren<GameplayPanelController>();
        mainMenuCtrl= GetComponentInChildren<MainMenuController>();
        gameplayCtrl.Init(this);
    }

    public void PauseActions(bool _isActive)
    {
        SetPausaPanelStatus(_isActive);
        if (_isActive)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ActivateSpotLight1()
    {
        SpotLight1.gameObject.SetActive(true);
    }

    public void DeactivateSpotLight1()
    {
        SpotLight1.gameObject.SetActive(false); 
    }

    public void ActivateSpotLight2()
    {
        SpotLight2.gameObject.SetActive(true);
    }

    public void DeactivateSpotLight2()
    {
        SpotLight2.gameObject.SetActive(false);
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

    void SetPausaPanelStatus(bool _isActive)
    {
        PausePanel.SetActive(_isActive);
    }
}
