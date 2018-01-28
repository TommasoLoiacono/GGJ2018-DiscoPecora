using System.Collections.Generic;

[System.Serializable]
public class RecordFenotipo
{
    public List<RecordData> coloreLana;
    public List<RecordData> colorePelle;
    public List<RecordData> carattere;
}

[System.Serializable]
public class RecordData
{
    public string chiave;
    public GeneticBase valore;

}
