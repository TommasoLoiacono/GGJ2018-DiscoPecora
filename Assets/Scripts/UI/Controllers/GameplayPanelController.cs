using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanelController : MonoBehaviour {

    UIManager UIMng;
    SheepDisplayer[] _sheepDisplayers;
    public Sprite LeftDisplayerOpen;
    public Sprite RightDisplayerOpen;
    public Sprite LeftDisplayerClose;
    public Sprite RightDisplayerClose;
    public Text CounterText;

    public void Init (UIManager _manager) {
        UIMng = _manager;
        _sheepDisplayers = GetComponentsInChildren<SheepDisplayer>();
        _sheepDisplayers[0].Init(LeftDisplayerOpen, LeftDisplayerClose);
        _sheepDisplayers[1].Init(RightDisplayerOpen, RightDisplayerClose);
    }

    public void ShowSheepDatas(Pecora _pecora, bool _isLeftClick)
    {
        //Chiama la spotlight
        if (_isLeftClick)
        {
            _sheepDisplayers[0].SetupCard(_pecora);
            UIMng.SpotLight1.MoveSpotLightToPosition(_pecora.transform.position);
        }
        else
        {
            _sheepDisplayers[1].SetupCard(_pecora);
            UIMng.SpotLight2.MoveSpotLightToPosition(_pecora.transform.position);

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
