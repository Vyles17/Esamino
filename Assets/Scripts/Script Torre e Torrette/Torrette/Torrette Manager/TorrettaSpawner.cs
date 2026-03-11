
using UnityEngine;
using UnityEngine.EventSystems;

public class TorrettaSpawner : MonoBehaviour, IPointerClickHandler
{
    //il bottone per cambiargli colore (se non è selezionabile è grigio
    [SerializeField] SpriteRenderer bottoneTorretta;
    //la lista di torrette fra cui scegliere
    [SerializeField] Torrette torrettePrefab;

    private Color coloreOriginale;
    public static Torrette torrettaSelezionata;


    public void Start()
    {
        //mi salvo il colore originale del bottonw
        coloreOriginale = bottoneTorretta.color;
    }
    public void Update()
    {
        //se il costo della torretta è troppo alto, aggiorno il colore del bottone
        if (torrettePrefab.costoTorretta > DimDollaroniManager.Instance.portafoglio)
        {
            bottoneTorretta.color = Color.gray7;
        }

        //sennò è normale
        else
        {
            bottoneTorretta.color = coloreOriginale;
        }
    }

    //quando clicco sul bottone..
    public void OnPointerClick(PointerEventData eventData)
    {
        //se il costo è troppo alto, non è selezionabile
        if (torrettePrefab.costoTorretta > DimDollaroniManager.Instance.portafoglio)
            return;

        //se il costo della torretta è minore del portafoglio disponibile..
        if (torrettePrefab.costoTorretta <= DimDollaroniManager.Instance.portafoglio)
        {
            //si mette in pausa il flusso del gioco
            GameManager.Instance.SetGameStatus(GameStatus.InPausa);

            // e si picka il prefab (ora sta allo script SpaziTorrette!)
            torrettaSelezionata = torrettePrefab;
        }
    }
}
