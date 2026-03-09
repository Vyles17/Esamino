
using UnityEngine;
using UnityEngine.EventSystems;

public class TorrettaSpawner : MonoBehaviour, IPointerClickHandler
{
    //il bottone per cambiargli colore (se non è selezionabile è grigio
    [SerializeField] SpriteRenderer bottoneTorretta;
    //la lista di torrette fra cui scegliere
    [SerializeField] Torrette torrettePrefab;

    public static Torrette torrettaSelezionata;

    public void FixedUpdate()
    {
        //se il costo della torretta è troppo alto, non si può selezionare
        if (torrettePrefab.costoTorretta >= DimDollaroniManager.Instance.portafoglio)
        {
            bottoneTorretta.color = Color.gray7;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //se il costo della torretta è minore del portafoglio disponibile..
        if (torrettePrefab.costoTorretta <= DimDollaroniManager.Instance.portafoglio)
        {
            //si scalano i soldi dal portafoglio
            int dimDollaroni = torrettePrefab.costoTorretta;
            DimDollaroniManager.Instance.Spesa(dimDollaroni);

            //si mette in pausa il flusso del gioco
            GameManager.Instance.SetGameStatus(GameStatus.InPausa);

            // e si picka il prefab (ora sta allo script SpaziTorrette!)
            torrettaSelezionata = torrettePrefab;
        }
    }

}
