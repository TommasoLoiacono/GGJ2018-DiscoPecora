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

    public void Init()
    {
        gameplayCtrl = GetComponentInChildren<GameplayPanelController>();
        mainMenuCtrl= GetComponentInChildren<MainMenuController>();
        gameplayCtrl.Init(this);
    }

    public void ActivateSpotLight()
    {
        SpotLight1.gameObject.SetActive(true);
    }

    public void DeactivateSpotLight()
    {
        SpotLight1.gameObject.SetActive(false); 
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
