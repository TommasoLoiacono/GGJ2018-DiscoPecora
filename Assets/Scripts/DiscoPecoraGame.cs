using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoPecoraGame : MonoBehaviour {

    public GameObject StampoPecora;
    public List<GameObject> pecoreInGioco = new List<GameObject>(); // Eh già, la lista delle pecore che ci sono in gioco. Fenomenale, lo so.
    [SerializeField]
    public RecordFenotipo DizionarioFenotipo;
    public ArrayList listaNomiMaschili = new ArrayList(new string[] { "Mario", "Luigi", "Bowser", "Kangaroo", "Teddy", "Vladimir", "Matteo", "Silvio", "Donald", "Zack", "Terkelton", "Ludwig", "Link", "Bernie", "Luke", "Todd", "Adamo", "Matthew", "Pier Luca", "Goffredo", "Francesco", "Sven", "Brucolo", "Rudolf", "Adolf", "Aldwin", "Jonnie", "John", "Ayeye", "Alvin", "Piero", "Ashby", "Piero", "Angelo", "Salvatore", "Yi Yong", "Carlo", "Ittikiom", "Ben J", "Asdrubale", "Annibale", "Attila", "Rollo", "Balto", "Montalbano", "Stefano","ASDF" });
    public ArrayList listaNomiFemminili = new ArrayList(new string[] { "Viola", "Pippa", "Genoveffa", "Gina", "Verdania", "Erika", "Stefania", "Summer", "Jiu Li", "Yuhui Li", "Sibei", "Xun Wang", "Luisa", "Maria", "Maddalena", "Elisabetta", "Eva", "Audrey", "Jennifer", "Armie", "Rachel", "Monica", "Phoebe", "Piper", "Lara", "Prue", "Pamela", "Samantha", "Scarlett", "Lorde", "Andrea", "Giovanna", "Rosy", "Adriana", "Lucia", "Licia", "Zelda", "Peach", "Kendall" });
    public ArrayList aggettiviColorePelle = new ArrayList(new string[] { "Pink", "Black", "Yellow" });
    public ArrayList aggettiviColoreLana = new ArrayList(new string[] {"White", "Orange","Blue","Green","Red" });
    public ArrayList aggettiviCarattere = new ArrayList(new string[] { "Alternative", "Aggressive", "Punk", "Chic", "Yokel" }); 
    public float probabilitaGenerazioneDominante=0.5f;
    public Pecora pecoraSuprema = new Pecora();
    public Pecora pecoraSx;
    public Pecora pecoraDx;

    public int _points;
    public int Points {
        get { return _points; }
        set
        {
            _points = value;
            GameManager.I.UIMng.gameplayCtrl.UpdatePoints(_points);
        }
    }

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
        GameManager.I.UIMng.gameplayCtrl.SetGoalTabText(pecoraSuprema);
        giocoAttivo = true;
        StartCoroutine(GeneraPecore());
        StartCoroutine(InvecchiaPecore());
        //Generate();
        //StartCoroutine(Populate());

    }


    IEnumerator InvecchiaPecore()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempoPerInvecchiarePecore);
            if (giocoAttivo) { 
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

    }

    IEnumerator GeneraPecore()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondiPerGenerarePecora);
            if (giocoAttivo) { 

            if (pecoreInGioco.Count <= numeroMassimoPecore)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-9, 9), Random.Range(-2, 4), 0f);
                CreaPecora(RandomizzaPecora(), spawnPos);
            }
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
        nuovaPecora.GetComponent<Pecora>().InstanziaPecora(p.eta, p.sesso,  p.colorePelle,  p.coloreLana, p.carattere, p.nome);
        JohnSheepCustomize(nuovaPecora);
        ControllaSeHaiPecoraSuprema(nuovaPecora.GetComponent<Pecora>());
       

    }

    //Hi John, this is your funcion. You will get an instanced white sheep, as gameobject.
    // You should, at the end of this function, to give her the right color of skin, color of wool and the right animator
    //  sheep.GetComponent<Pecora>().coloreLana.valoreCaratteristica is the color of the wool
    //  sheep.GetComponent<Pecora>().colorePelle.valoreCaratteristica is the color of the skin
    //  Both values are string.
    // You can use either italian name or english name, in case we will figure out how to translate properly
    // The prefab of the sheep is called sheep in the prefab folder 
    public void JohnSheepCustomize(GameObject sheep)
    {
        RecordData record;
        record = DizionarioFenotipo.coloreLana.Find(item => item.chiave == sheep.GetComponent<Pecora>().coloreLana.valoreCaratteristica);
        if (record != null)
        {
            sheep.GetComponent<TestColorChange>().woolGenetic = record.valore as WoolGenetics;
        }

        record = DizionarioFenotipo.colorePelle.Find(item => item.chiave == sheep.GetComponent<Pecora>().colorePelle.valoreCaratteristica);
        if (record != null)
        {
            sheep.GetComponent<TestColorChange>().skinGenetic = record.valore as SkinGenetics;
        }

        record = DizionarioFenotipo.carattere.Find(item => item.chiave == sheep.GetComponent<Pecora>().carattere.valoreCaratteristica);
        if (record != null)
        {
            sheep.GetComponent<TestColorChange>().personalityGenetic = record.valore as PersonalityGenetics;
        }


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
                    _points += 50;
                    pecoraSuprema = RandomizzaPecora();
                    GameManager.I.UIMng.gameplayCtrl.SetGoalTabText(pecoraSuprema);
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
