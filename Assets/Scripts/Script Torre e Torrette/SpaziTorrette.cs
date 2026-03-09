using UnityEngine;
using UnityEngine.EventSystems;

public class SpaziTorrette : MonoBehaviour, IPointerClickHandler
{
    //mi serve sapere se la base è già occupata
    private bool èOccupata = false;

    public void OnPointerClick(PointerEventData eventData)
    { 
        //se la base è già occupata, non la puoi selezionare
        if (èOccupata)
             return;

        Torrette torretta = TorrettaSpawner.torrettaSelezionata;

        //quindi dicevamo, se abbiamo la torretta in mano
        if (torretta != null)
        {
            //la mettiamo sulla base libera
            transform.rotation = new Quaternion (0, 0 , 180  , 0);
            Instantiate(torretta, transform.position, transform.rotation, transform);

            //la assegniamo
            èOccupata = true;

            //ora la devo rendere null così non la assegno in altre postazioni
            TorrettaSpawner.torrettaSelezionata = null;

            //resumiamo il gioco
            GameManager.Instance.SetGameStatus(GameStatus.InGioco);
        }
        
    }
}
