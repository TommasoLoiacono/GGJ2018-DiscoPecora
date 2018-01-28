using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepDisplayer : MonoBehaviour {

    public Image SheepPhoto;
    public Text SheepText;
    public Text NameText;

    private string dominantColor= "<color=#7DB24A>";
    private string recessiveColor = "<color=#BC3A41>";

    //Sprite _imageOn;
    //Sprite _imageOff;

    #region API
    //public void Init(Sprite _ImageOn, Sprite _ImageOff)
    //{
    //    _imageOn = _ImageOn;
    //    _imageOff = _ImageOff;
    //}

    /// <summary>
    /// Set the text displayed in the card
    /// </summary>
    /// <param name="_struct">Structure with all the datas</param>
    public void SetText(Pecora _sheep, bool _isGoalSheep = false)
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
        if (!_isGoalSheep)
            NameText.text = _sheep.nome; 


        SheepText.text = "Sex: " + sexString + " - Lana: "+((_sheep.coloreLana.carattereDominante==1)?dominantColor:recessiveColor) + _sheep.colorePelle.valoreCaratteristica + "</color> - Pelle: "+(_sheep.colorePelle.carattereDominante==1?dominantColor:recessiveColor) + _sheep.colorePelle.valoreCaratteristica + "</color> - Carattere: "+(_sheep.carattere.carattereDominante==1?dominantColor:recessiveColor) + _sheep.carattere.valoreCaratteristica+"</color>";
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
