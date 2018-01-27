using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepDisplayer : MonoBehaviour {

    public bool IsUsed { get; set; }
    public Image SheepPhoto;
    Image BackGround;
    public Text SheepText;

    private void Start()
    {
        //Test per visualizzare il testo
        SetText(new SheepData { _age = SheepData.Age.Old, _sex = SheepData.Sex.M, _character = SheepData.Character.Brutto, _lana = SheepData.Wool.Black, _name = "Pippo" });
        BackGround = GetComponent<Image>();
    }

    /// <summary>
    /// Setup the text and the image of the card
    /// </summary>
    /// <param name="_struct"></param>
    public void SetupCard(SheepData _struct)
    {
        SetImage(_struct);
        SetText(_struct);
        if (_struct._sex == SheepData.Sex.M)
        {
            //Carica il background Blu
            //BackGround.sprite = - 
        }
        else
        {
            //Carica il back ground rosa

        }
    }

    /// <summary>
    /// Set the image of the card
    /// </summary>
    /// <param name="_struct">Structure with all the datas</param>
    public void SetImage(SheepData _struct)
    {
        SheepPhoto.sprite = _struct._image;
    }

    /// <summary>
    /// Set the text displayed in the card
    /// </summary>
    /// <param name="_struct">Structure with all the datas</param>
    public void SetText(SheepData _struct)
    {
        SheepText.text = _struct._name + "\n Sex: " + _struct._sex + " Age: " + _struct._age + "\n Wool: " + _struct._lana + "\n character: " + _struct._character;
        
    }
}
