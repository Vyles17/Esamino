using System.Threading;
using UnityEngine;
public abstract class Torrette : MonoBehaviour
{
    //script madre per le torrette
    [SerializeField] public int costoTorretta;
    [SerializeField] public int costoUpgrade;
    [SerializeField] GameObject prefabProiettile;
    [SerializeField] public int rateoProiettili;

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
            //crea un proiettile
            Instantiate(prefabProiettile, transform.position, transform.rotation, transform);

            //resetta il timer
            timer = 0;
        }
    }
}
