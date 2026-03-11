using TMPro;
using UnityEngine;
public class TorretteUI : MonoBehaviour
{
    //mini-scriptino per aggiornare il costo dei PowerUp in UI

    [SerializeField] public TMP_Text costoUpgrade;
    public Torrette torretta;

    //l'evento delle torrette Upgrade aggiorna il costo in UI
    private void OnEnable()
    {
        TorretteUpgrade.OnTorretteUpgrade += CostoUpdate;
    }

    private void OnDisable()
    {
        TorretteUpgrade.OnTorretteUpgrade -= CostoUpdate;
    }

    //settiamo l'UI del costo upgrade all'inizio corrispondente a quella della torretta selezionata
    public void Start()
    {
        costoUpgrade.text = torretta.CostoTorretta.ToString();
    }

    //funzioncina per updatearla quando aumenta
    public void CostoUpdate()
    {
        costoUpgrade.text = torretta.CostoTorretta.ToString();
    }
}
