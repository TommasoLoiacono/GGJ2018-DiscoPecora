using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoPecoraGame : MonoBehaviour {

    public GameObject StampoPecora;
    public List<GameObject> pecoreInGioco = new List<GameObject>(); // Eh già, la lista delle pecore che ci sono in gioco. Fenomenale, lo so.
                                                            //  public ArrayList aggettiviColorePelle = new ArrayList();
    public ArrayList listaNomiMaschili = new ArrayList(new string[] { "pippo", "gino", "genoveffo" });
    public ArrayList listaNomiFemminili = new ArrayList(new string[] { "pippa", "gina", "genoveffa" });
    public ArrayList aggettiviColorePelle = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviColoreLana = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviCarattere = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public float probabilitaGenerazioneDominante=0.5f;
    public Pecora pecoraSuprema = new Pecora();
    public Pecora pecoraSx;
    public Pecora pecoraDx;
    public int punteggio;
    public bool giocoAttivo = true;
    public float secondiPerGenerarePecora = 5f;
    public int numeroMassimoPecore = 50;
    public float tempoPerInvecchiarePecore = 6f;
    public int etaMorte = 4;



    public float minNumberOfSheeps;
    public float maxNumberOfSheeps;
    public float yRandomDisplacement, xRandomDisplacement;
    public int screenSizeX, screenSizeY;
    private float layerWidth, layerHeight;
    private int numberOfSheeps;



    // Use this for initialization
    public void Init() {
        pecoraSuprema = RandomizzaPecora();
        StartCoroutine(GeneraPecore());
        StartCoroutine(InvecchiaPecore());
        Generate();
        giocoAttivo = true;
        //StartCoroutine(Populate());

    }


    IEnumerator InvecchiaPecore()
    {
        while (giocoAttivo)
        {
            yield return new WaitForSeconds(tempoPerInvecchiarePecore);
            print("invecchio");
            foreach(GameObject pecora in pecoreInGioco)
            {
                pecora.GetComponent<Pecora>().eta++;
                print(pecora.GetComponent<Pecora>().eta);
                if (pecora.GetComponent<Pecora>().eta >= etaMorte)
                {
                    if (pecora == pecoraDx)
                    {
                        //No necrofilia sx
                    }
                    else
                    {
                        if (pecora == pecoraSx)
                        {
                            //No necrofilia dx
                        }
                        else
                        {
                            pecora.GetComponent<Animator>().SetBool("Dead",true);
                        }
                    }
                }
            }
             pecoreInGioco.RemoveAll(item => item.GetComponent<Pecora>().eta >= etaMorte);
        }
        
    }

    IEnumerator GeneraPecore()
    {
        while (giocoAttivo) { 
        yield return new WaitForSeconds(secondiPerGenerarePecora);

            if (pecoreInGioco.Count <= numeroMassimoPecore)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-9, 9), Random.Range(-2, 4), 0f);
                CreaPecora(RandomizzaPecora(), spawnPos);
            }
        }
    }

    /// <summary>
    /// Generate the sheep in the scene
    /// </summary>
    public void Generate()
    {
        layerWidth = screenSizeX / 2;
        layerHeight = screenSizeY / 2;

        numberOfSheeps = (int)UnityEngine.Random.Range(minNumberOfSheeps, maxNumberOfSheeps);

        for (int i = 0; i < numberOfSheeps; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9, 9), Random.Range(-2, 4), 0f);
            CreaPecora(RandomizzaPecora(), spawnPos);
            Debug.Log("Pecora");
        }
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


    public void Accoppia()
    {
        if (pecoraSx != null && pecoraDx != null)
        {
            if (pecoraSx.sesso == pecoraDx.sesso || pecoraSx.gameObject.GetInstanceID() == pecoraDx.gameObject.GetInstanceID())
            {
                // GAYYYYYYYYYYYYYYYYYYYYYYYYYYYY
                // Oppure è una sega
            }
            else
            {
                CreaPecora(AccoppiamentoTeorico(pecoraSx, pecoraDx), Vector3.zero);
            } 
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

        if (Random.Range(0, 2) == 0) { return a; }
        else { return b; }
    }

    public void CreaPecora(Pecora p, Vector3 t)
    {
        GameObject nuovaPecora = Instantiate(StampoPecora, t, Quaternion.identity, transform);
        pecoreInGioco.Add(nuovaPecora);
        nuovaPecora.GetComponent<Pecora>().InstanziaPecora(p.eta, p.sesso,  p.colorePelle,  p.colorePelle, p.carattere, p.nome);

        ControllaSeHaiPecoraSuprema(nuovaPecora.GetComponent<Pecora>());


    }

    public Pecora RandomizzaPecora()
    {
        Pecora p = new Pecora();
        int eta = Random.Range(0, etaMorte);
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
        string nome;

        if (sesso == 0)
        {
            nome = listaNomiMaschili[Random.Range(0, listaNomiMaschili.Count)].ToString();
        }
        else
        {
            nome = listaNomiFemminili[Random.Range(0, listaNomiFemminili.Count)].ToString();

        }

        p.InstanziaPecora(eta, sesso,  colorePelle,  coloreLana,  carattere, nome);
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
                    // print("Hai vinciuto");
                    punteggio += 50;
                    pecoraSuprema = RandomizzaPecora();
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
