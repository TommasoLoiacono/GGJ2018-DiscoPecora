using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaratteristicaEreditaria : MonoBehaviour {
    public int tipoCaratteristica; // 0=colore pelle, 1=colore lana, 2=carattere, 3=c'è stato un bug e non dovrebbe esserci un 3. Sì lo so, potevo usare l'ereditarietà e creare diversi tipi, ma le idee sembrano poco chiare, perciò è meglio giocare safe in questa maniera uagliò
    public string valoreCaratteristica; // Se la lana è blu ad esempio, viene scritto qua "blu". Mantenete una scrittura della caratteristica in minuscolo. Il codice è fatto in modo di formattare il pc se trova un carattere maiuscolo in questo campo
    public int carattereDominante; //0=recessivo, 1=dominante. Figo vero? Potevo usare un bool ma non ho avuto un granchè voglia

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
