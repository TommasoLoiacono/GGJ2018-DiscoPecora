using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanelController : MonoBehaviour {

    UIManager UIMng;
    SheepDisplayer[] _sheepDisplayers;
    //public Sprite LeftDisplayerOpen;
    //public Sprite RightDisplayerOpen;
    //public Sprite LeftDisplayerClose;
    //public Sprite RightDisplayerClose;
    public SheepDisplayer GoalTab;
    public Text PointsCounter;

    public Sprite MaleGoalSprite;
    public Sprite FemaleGoalSprite;

    public void Init (UIManager _manager) {
        UIMng = _manager;
        _sheepDisplayers = GetComponentsInChildren<SheepDisplayer>();
        //_sheepDisplayers[0].Init(LeftDisplayerOpen, LeftDisplayerClose);
        //_sheepDisplayers[1].Init(RightDisplayerOpen, RightDisplayerClose);
    }

    public void UpdatePoints(int _points)
    {
        PointsCounter.text = "Points: " + _points;
    }

    public void SetGoalTabText(Pecora _pecora)
    {
        //Set Image of goal tab
        if (_pecora.sesso == 0)
            GoalTab.SetBackgroundForGoalDisplayer(MaleGoalSprite);
        if (_pecora.sesso == 1)
            GoalTab.SetBackgroundForGoalDisplayer(FemaleGoalSprite);

        GoalTab.SetText(_pecora, true);
    }

    public void ShowSheepDatas(Pecora _pecora, bool _isLeftClick)
    {
        //Chiama la spotlight
        if (_isLeftClick)
        {
            _sheepDisplayers[0].SetText(_pecora);
            if (!UIMng.SpotLight1.isActiveAndEnabled)
                UIMng.SpotLight1.gameObject.SetActive(true);
            UIMng.SpotLight1.MoveSpotLightToPosition(_pecora);
        }
        else
        {
            _sheepDisplayers[1].SetText(_pecora);
            if (!UIMng.SpotLight2.isActiveAndEnabled)
                UIMng.SpotLight2.gameObject.SetActive(true);
            UIMng.SpotLight2.MoveSpotLightToPosition(_pecora);

        }
    }
}

//public struct SheepData
//{
//    public Sprite _image;
//    public string _name;
//    public Sex _sex;
//    public Age _age;
//    public Wool _lana;
//    public Character _character;

//    public enum Sex
//    {
//        M,F
//    }
//    public enum Age
//    {
//        Young,
//        Old
//    }

//    public enum Wool
//    {
//        White,
//        Black,
//        Yellow
//    }

//    public enum Character
//    {
//        Bello,
//        Brutto,
//        Scemo
//    }
//}
