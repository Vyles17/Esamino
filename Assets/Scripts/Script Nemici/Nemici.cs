using Unity.VisualScripting;
using UnityEngine;
public class Nemici : MonoBehaviour, IDanneggiabili
{
    //assegniamo la vita, la velocità e la quantità di danni inferti
    private Rigidbody2D nemicoRB;

    [SerializeField] public int vita;
    [SerializeField] public float velocità;
    [SerializeField] public int danniInferti;

    //settiamo il rigidBody Nemico
    private void Awake()
    {
        nemicoRB = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Movimento();
    }

    public void Movimento()
    {
        //il nemico deve andare verso sinistra, assegno la direzione
        Vector2 direzioneNemico = new Vector2(-1, 0);

        //gli dico con che velocità andarci
        nemicoRB.position += direzioneNemico * velocità * Time.fixedDeltaTime;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //getto l'interfaccia dei Danneggiabili (poi su unity escludo chi ha il layer "Nemici") per colpire la torre
        IDanneggiabili target = other.GetComponent<IDanneggiabili>();

        if (target != null)
        {
            target.SeDanneggiato(danniInferti);

            //e muoiono dopo aver fatto la loro mossa kamikaze
            Destroy(gameObject);
        }

    }

    public void SeDanneggiato(int danni)
    {
        //come la torre, anche i nemici prendono danni, se muoiono vengono distrutti
        vita -= danni;

        if (vita < 0)
            Destroy(gameObject);
    }
}
