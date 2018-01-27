﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoPecoraGame : MonoBehaviour {
    public GameObject StampoPecora;
    public List<Pecora> pecoreInGioco = new List<Pecora>(); // Eh già, la lista delle pecore che ci sono in gioco. Fenomenale, lo so.
  //  public ArrayList aggettiviColorePelle = new ArrayList();
    public ArrayList aggettiviColorePelle = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviColoreLana = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviCarattere = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public float probabilitaGenerazioneDominante=0.5f;
    public Pecora pecoraSuprema = new Pecora();


    public float minNumberOfSheeps;
    public float maxNumberOfSheeps;
    public float yRandomDisplacement, xRandomDisplacement;
    public int screenSizeX, screenSizeY;
    private float layerWidth, layerHeight;
    private int numberOfSheeps;



    // Use this for initialization
    void Start() {
        pecoraSuprema = RandomizzaPecora();
        StartCoroutine(Populate());

    }

    IEnumerator Populate()
    {
        layerWidth = screenSizeX / 2;
        layerHeight = screenSizeY / 2;

        numberOfSheeps = (int)UnityEngine.Random.Range(minNumberOfSheeps, maxNumberOfSheeps);

        for (int i = 0; i < numberOfSheeps; i++)
        {
            Vector3 spawnPos = new Vector3(randomDisplacement(layerWidth),
                randomDisplacement(layerHeight),
                0f);
            CreaPecora(RandomizzaPecora(), spawnPos);
            Debug.Log("Pecora");
        }
        yield return null;

    }

    float randomDisplacement(float width)
    {
        float f = UnityEngine.Random.Range(-1f, 1f) * width;
        int i = (int)f;
        float c = i;
        return c;

    }

    // Update is called once per frame
    void Update() {
       
    }

    public void Accoppia(Pecora padre, Pecora madre)
    {
        if (padre.sesso == madre.sesso)
        {
            // GAYYYYYYYYYYYYYYYYYYYYYYYYYYYY
        }
        else
        {
            CreaPecora(AccoppiamentoTeorico(padre, madre), Vector3.zero);
        }
    }

    public Pecora AccoppiamentoTeorico(Pecora padre, Pecora madre)
    {

            Pecora figlio = RandomizzaPecora();

            figlio.colorePelle.valoreCaratteristica = TrasmissioneGenetica(padre.colorePelle, madre.colorePelle).valoreCaratteristica;
            figlio.coloreLana.valoreCaratteristica = TrasmissioneGenetica(padre.coloreLana, madre.coloreLana).valoreCaratteristica;
            figlio.carattere.valoreCaratteristica = TrasmissioneGenetica(padre.carattere, madre.carattere).valoreCaratteristica;

            return figlio;
   
    }

    public CaratteristicaEreditaria TrasmissioneGenetica(CaratteristicaEreditaria a, CaratteristicaEreditaria b)
    {
        if (a.carattereDominante == 1 && b.carattereDominante == 0) { return a; }
        if (b.carattereDominante == 1 && a.carattereDominante == 0) { return b; }

        if (Random.RandomRange(0, 2) == 0) { return a; }
        else { return b; }
    }

    public void CreaPecora(Pecora p, Vector3 t)
    {
        GameObject nuovaPecora = Instantiate(StampoPecora, t, Quaternion.identity, transform);
        nuovaPecora.GetComponent<Pecora>().InstanziaPecora(p.eta, p.sesso,  p.colorePelle,  p.colorePelle, p.carattere);
        ControllaSeHaiPecoraSuprema(nuovaPecora.GetComponent<Pecora>());


    }

    public Pecora RandomizzaPecora()
    {
        Pecora p = new Pecora();
        int eta = Random.Range(0, 3);
        int sesso = Random.Range(0, 2);
        CaratteristicaEreditaria colorePelle = new CaratteristicaEreditaria();
        colorePelle.tipoCaratteristica = 0;

        colorePelle.valoreCaratteristica = aggettiviColorePelle[Random.Range(0, aggettiviColorePelle.Count)].ToString();
        colorePelle.carattereDominante = SorteggiaDominanteORecessivo();


        CaratteristicaEreditaria coloreLana = new CaratteristicaEreditaria();
        coloreLana.tipoCaratteristica = 1;
        coloreLana.valoreCaratteristica = aggettiviColoreLana[Random.Range(0, aggettiviColoreLana.Count )].ToString();
        coloreLana.carattereDominante = SorteggiaDominanteORecessivo();

        CaratteristicaEreditaria carattere = new CaratteristicaEreditaria();
        carattere.tipoCaratteristica = 2;
        carattere.valoreCaratteristica = aggettiviCarattere[Random.Range(0, aggettiviCarattere.Count )].ToString();
        carattere.carattereDominante = SorteggiaDominanteORecessivo();

        p.InstanziaPecora(eta, sesso,  colorePelle,  coloreLana,  carattere);
        return p;
        }

    public void ControllaSeHaiPecoraSuprema(Pecora p)
    {
        if (pecoraSuprema.carattere.valoreCaratteristica == p.carattere.valoreCaratteristica)
        {
            if (pecoraSuprema.colorePelle.valoreCaratteristica == p.colorePelle.valoreCaratteristica)
            {
                if (pecoraSuprema.coloreLana.valoreCaratteristica == p.coloreLana.valoreCaratteristica)
                {
                    print("Hai vinciuto");
                }
            }
        }
    }

    public int SorteggiaDominanteORecessivo()
    {
       float r= Random.Range(0.0f, 1.0f);
        if (r < probabilitaGenerazioneDominante) { return 1; }
        else { return 0; }
    }

    

}
