using System.Threading;
using UnityEngine;
public abstract class Torrette : MonoBehaviour
{
    //script madre per le torrette

    //condividono tutte gli stessi parametri di base
    [SerializeField] public int costoTorretta;
    [SerializeField] public int costoUpgrade;
    [SerializeField] GameObject prefabProiettile;
    [SerializeField] public float rateoProiettili;
    [SerializeField] public int danniProiettili;
    public bool èUpgradeabile = true;

    private float timer;

    private void Start()
    {
        //all'inizio il timer è 0
        timer = 0;
    }
 

    private void FixedUpdate()
    {
       //parte il timer
       timer += Time.fixedDeltaTime;

        Attacco();
    }

    public void Attacco()
    {
        //se il timer raggiunge il rateo, spara
        if (timer >= rateoProiettili)
        {
            //creo un proiettile
            GameObject nuovoProiettile = Instantiate(prefabProiettile, transform.position, transform.rotation, transform);

            ModificaProiettile(nuovoProiettile);

            //resetto il timer
            timer = 0;
        }
    }

    //funz vuota per modificare poi il proiettile in base al tipo di torretta
    protected virtual void ModificaProiettile(GameObject proiettile)
    {
        
    }

    //funz vuota per modificare poi l'upgrade in base al tipo di torretta
    public virtual void UpgradeTorretta()
    {

    }

    //funz per settare la statistica "costo dell'upgrade" nello script dell'Upgrade
    public int CostoTorretta
    {
        get { return costoTorretta; }
        set { costoTorretta = value; }
    }
}
