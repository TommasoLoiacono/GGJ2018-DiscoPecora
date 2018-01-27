using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoPecoraGame : MonoBehaviour {
    public GameObject StampoPecora;
    public List<Pecora> pecoreInGioco = new List<Pecora>(); // Eh già, la lista delle pecore che ci sono in gioco. Fenomenale, lo so.
  //  public ArrayList aggettiviColorePelle = new ArrayList();
    public ArrayList aggettiviColorePelle = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviColoreLana = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public ArrayList aggettiviCarattere = new ArrayList(new string[] { "blu", "rosso", "giallo" });
    public float probabilitaGenerazioneDominante;
    public Pecora pecoraVincente = new Pecora();


    // Use this for initialization
    void Start() {
        print("qq");
       CreaPecora(RandomizzaPecora());

    }

    // Update is called once per frame
    void Update() {
       
    }

    public Pecora Accoppiamento() { return null; }

    public void CreaPecora(Pecora p)
    {
        GameObject nuovaPecora = Instantiate(StampoPecora, this.transform);
        nuovaPecora.GetComponent<Pecora>().InstanziaPecora(p.eta, p.sesso, p.colorePelle, p.colorePelle, p.carattere);
    }

    public Pecora RandomizzaPecora()
    {
        Pecora p = new Pecora();
        int eta = Random.Range(0, 3);
        int sesso = Random.Range(0, 2);
        CaratteristicaEreditaria colorePelle = new CaratteristicaEreditaria();
        colorePelle.tipoCaratteristica = 0;
        colorePelle.valoreCaratteristica = aggettiviColorePelle[Random.Range(0, aggettiviColorePelle.Count)].ToString();

        CaratteristicaEreditaria coloreLana = new CaratteristicaEreditaria();
        coloreLana.tipoCaratteristica = 1;
        coloreLana.valoreCaratteristica = aggettiviColoreLana[Random.Range(0, aggettiviColoreLana.Count )].ToString();

        CaratteristicaEreditaria carattere = new CaratteristicaEreditaria();
        carattere.tipoCaratteristica = 2;
        carattere.valoreCaratteristica = aggettiviCarattere[Random.Range(0, aggettiviCarattere.Count )].ToString();

        p.InstanziaPecora(eta, sesso, colorePelle, coloreLana, carattere );
        return p;
        }

    public void ControllaSeHaiVinto(Pecora p) { }

    

}
