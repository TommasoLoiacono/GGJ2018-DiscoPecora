using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanelController : MonoBehaviour {

    SheepDisplayer[] _sheepDisplayers;
    public Sprite LeftDisplayerOpen;
    public Sprite RightDisplayerOpen;
    public Sprite LeftDisplayerClose;
    public Sprite RightDisplayerClose;
    public Text CounterText;

    public void Init () {
        _sheepDisplayers = GetComponentsInChildren<SheepDisplayer>();
        _sheepDisplayers[0].Init(LeftDisplayerOpen, LeftDisplayerClose);
        _sheepDisplayers[1].Init(RightDisplayerOpen, RightDisplayerClose);
    }

    public void ShowSheepDatas(Pecora _data)
    {
        if (!_sheepDisplayers[0].IsUsed)
        {
            _sheepDisplayers[0].SetupCard(_data);
        }
        else if (!_sheepDisplayers[1].IsUsed)
        {
            _sheepDisplayers[1].SetupCard(_data);
        }
        else
            _sheepDisplayers[0].SetupCard(_data);

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
