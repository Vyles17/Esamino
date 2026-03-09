using UnityEngine;

public class SpawnerNemici : MonoBehaviour
{
    //Serializzo la lista dei nemici che spawneranno e il rate in cui spawnano
    [SerializeField] GameObject[] nemici;
    [SerializeField] private float spawnRateo;
    private float timer;


    public void FixedUpdate()
    {
        //il timer comincia a scorrere
        timer += Time.fixedDeltaTime;

        //quando raggiunge il spawnRateo, si creano i nemici
        if (timer >= spawnRateo)
        {
            Instantiate(nemici[Random.Range(0, nemici.Length)], transform.position, transform.rotation);

            //e si resetta il timer
            timer = 0;
        }
    }

}
