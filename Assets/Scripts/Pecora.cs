using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecora : MonoBehaviour {
    public int eta; // 0,1,2. Ve la vedete poi voi
    public int sesso; // 0 maschio, 1 femmina. Se sommo due individui ottengo: 0 = frociazzi, 1 = coppia etero famiglia tradizionale no giender , 2= AH LESBICAH, OGGI HO FATTO I SOLDI LESBICAH
    public CaratteristicaEreditaria colorePelle; // Il colore della pelle della pecora. Se non ci eri arrivato leggendo l'identificativo probabilmente dovresti cambiare mestiere
    public CaratteristicaEreditaria coloreLana ; // Il colore della lana della pecora. Impressionante vero?
    public CaratteristicaEreditaria carattere ; // Ogni pecora ha il suo carattere. Tu che stai leggendo ad esempio, che carattere hai?

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print("pop");
        print("ciao"+colorePelle.valoreCaratteristica);

	}

    public void InstanziaPecora(int etaV, int sessoV,  CaratteristicaEreditaria colorePelleV, CaratteristicaEreditaria coloreLanaV, CaratteristicaEreditaria carattereV)
    {
        eta = etaV;
        sesso = sessoV;
        colorePelle = colorePelleV;
        coloreLana = coloreLanaV;
        carattere = carattereV;
        print("ee");
    }

    // Accoppiamento. Non guardate questa funzione a lungo o potreste eccitarvi
    
}
