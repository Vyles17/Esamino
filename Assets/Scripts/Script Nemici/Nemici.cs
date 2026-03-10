using System;
using Unity.VisualScripting;
using UnityEngine;
public class Nemici : MonoBehaviour, IDanneggiabili
{
    //assegniamo la vita, la velocità, la quantità di danni inferti e i DimDolalroni che ti fanno gaudagnare
    private Rigidbody2D nemicoRB;

    [SerializeField] public int vitaMax;
    public int vitaCorrente;
    [SerializeField] public float velocità;
    [SerializeField] public int danniInferti;
    [SerializeField] public int dimDollaroni;

    public static event Action OnNemiciUccisi;

    //settiamo il rigidBody Nemico
    private void Awake()
    {
        nemicoRB = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        //All'inizio del gioco, la vita è al massimo
        vitaCorrente = vitaMax;
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
        vitaCorrente -= danni;

        if (vitaCorrente < 0)
        {
            //invochiamo l'azione 
            OnNemiciUccisi?.Invoke();

            //aggiorniamo il portafoglio
            DimDollaroniManager.Instance.Arricchimento(dimDollaroni);

            //addio
            Destroy(gameObject);
        }
    }
}
