using UnityEngine;

public class DimDollaroniManager : MonoBehaviour
{
    //script per la gestione dei DimDollaroni
    public int portafoglio;

    public static DimDollaroniManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void Start()
    {
        //setto all'inizio che siamo poveri
        portafoglio = 100;
        UIManager.Instance.dimDollaroniTMP.text = portafoglio.ToString();
    }

    public void Arricchimento(int dimDollaroni)
    {
        //se ci arricchiamo, aggiorno portafoglio e UI
        portafoglio += dimDollaroni;
        UIManager.Instance.dimDollaroniTMP.text = portafoglio.ToString();
    }

    public void Spesa(int dimDollaroni)
    {
        //idem se diventiamo poveri
        portafoglio -= dimDollaroni;
        UIManager.Instance.dimDollaroniTMP.text = portafoglio.ToString();
    }
}
