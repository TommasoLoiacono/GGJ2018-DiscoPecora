using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepDisplayer : MonoBehaviour {

    public Image SheepPhoto;
    Image BackGround;
    public Text SheepText;

    Sprite _imageOn;
    Sprite _imageOff;

    bool _isUsed;
    public bool IsUsed
    {
        get { return _isUsed; }
        set { _isUsed = value; }
    }

    #region API
    public void Init(Sprite _ImageOn, Sprite _ImageOff)
    {
        BackGround = GetComponent<Image>();
        _imageOn = _ImageOn;
        _imageOff = _ImageOff;
    }

    /// <summary>
    /// Setup the text and the image of the card
    /// </summary>
    /// <param name="_struct"></param>
    public void SetupCard(Pecora _sheep)
    {
        SetImage(_sheep);
        SetText(_sheep);
    }

    /// <summary>
    /// Set the image of the card
    /// </summary>
    /// <param name="_struct">Structure with all the datas</param>
    public void SetImage(Pecora _sheep)
    {
        //SheepPhoto.sprite = _struct._image;
    }

    /// <summary>
    /// Set the text displayed in the card
    /// </summary>
    /// <param name="_struct">Structure with all the datas</param>
    public void SetText(Pecora _sheep)
    {
        string sexString;
        switch (_sheep.sesso)
        {
            case 0:
                sexString = "Male";
                break;
            case 1:
                sexString = "Female";
                break;
            case 2:
                sexString = "Lesbian";
                break;
            default:
                sexString = "noSex";
                break;
        }
        //SheepText.text = _struct._name + "\n Sex: " + _struct._sex + " Age: " + _struct._age + "\n Wool: " + _struct._lana + "\n character: " + _struct._character;
        SheepText.text = "Sex: " + sexString + "Lana: " + _sheep.colorePelle.valoreCaratteristica +"Pelle: " + _sheep.colorePelle.valoreCaratteristica + "Carattere: " + _sheep.carattere.valoreCaratteristica;
    }

    /// <summary>
    /// Clear the Tab
    /// </summary>
    public void ClearCard()
    {
        //SheepPhoto.sprite = null;
        SheepText.text = "";
    }
    #endregion
}
