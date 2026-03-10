using UnityEngine;

public class SpawnerNemici : MonoBehaviour
{
    //Serializzo la lista dei nemici che spawneranno e il rate in cui spawnano come "base"
    [SerializeField] GameObject[] nemiciPrefab;
    [SerializeField] private float spawnRateo = 2f;

    //serializzo i valori per quando si aggiornano
    [SerializeField] private int aggiornamentoSpawn = 10;
    [SerializeField] private float diminuzioneSpawnRateo = 0.3f;
    [SerializeField] private int aumentoDanniInferti = 1;
    private float limiteSpawnRateo = 1f;

    private GameObject nuovoNemico;
    private float timer;
    private int contatoreSpawn;

    public void Start()
    {
        //all'inizio, il timer e il contatore dei nemici spawnati è a 0
        timer = 0;
        contatoreSpawn = 0;
    }
    public void FixedUpdate()
    {
        //il timer comincia a scorrere
        timer += Time.fixedDeltaTime;

        SpawnNemici();

        //se arrivo a un tot prestabilito di nemici spawnati 
        if (contatoreSpawn >= aggiornamentoSpawn)
        {
            //eseguo la funzione di aggiornamento spawn
            AggiornamentoSpawnNemici();
        }
    }

    public void SpawnNemici()
    {
        //quando raggiunge il spawnRateo..
        if (timer >= spawnRateo)
        {
            //si creano i nemici randomicamente
            nuovoNemico = Instantiate(nemiciPrefab[Random.Range(0, nemiciPrefab.Length)], transform.position, transform.rotation, transform);

            //si aggiorna il contatore
            contatoreSpawn++;

            //e si resetta il timer
            timer = 0;
        }
    }

    public void AggiornamentoSpawnNemici()
    {
        //se lo spawnRateo non ha già raggiunto il valore minimo
        if (spawnRateo > limiteSpawnRateo)
        {
            //c'è uno spawn rate più veloce
            spawnRateo = spawnRateo - diminuzioneSpawnRateo;

            //se con la diminuzione va oltre al limite 
            if (spawnRateo < limiteSpawnRateo)
            {
                //lo ripoprtiamo al limite
                spawnRateo = limiteSpawnRateo;
            }
        }

        //e i nemici spawnati fanni più danni
        Nemici nemico = nuovoNemico.GetComponent<Nemici>();
        nemico.danniInferti = nemico.danniInferti + aumentoDanniInferti;


        //resetto il contatore
        contatoreSpawn = 0;
    }

}
