using UnityEngine;

public class Proiettili : MonoBehaviour
{
    //statistiche per i proiettili
    [SerializeField] private int danniProiettili = 3;
    [SerializeField] private float areaProiettili = 1f;
    [SerializeField] private float velocitàProiettili = 5f;

    Rigidbody2D rb;

    private void Start()
    {
        //all'inizio ci gettiamo il rigid body del proiettile
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movimento();
    }

    //funzione di movimento per il proiettile
    public void Movimento()
    {
        //si muove verso il basso
        Vector2 direzione = Vector2.down;
        rb.linearVelocity = direzione * velocitàProiettili;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se colpiscono un nemico
        IDanneggiabili target = other.GetComponent<IDanneggiabili>();

        if (target != null)
        {
            //gli tolgono vita
            target.SeDanneggiato(danniProiettili);

            //addio anche ai proiettili e non eseguiamo il resto del codice
            Destroy(gameObject);

            return;
        }

        // sennò addio anche ai proiettili quando vanno a sbattere nel muro invisibile
        Destroy(gameObject);
    }

}
