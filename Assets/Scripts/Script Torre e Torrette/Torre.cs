using UnityEngine;

public class Torre : MonoBehaviour, IDanneggiabili
{
    //assegniamo la vita alla nostra casa madre 
    [SerializeField] public int vitaMax = 50;
    private float vitaCorrente = 50;

    public void Start()
    {
        //All'inizio del gioco, la vita è al massimo
        vitaCorrente = vitaMax;
        UIManager.Instance.vitaTorre.fillAmount = vitaCorrente / vitaMax;
    }

    public void SeDanneggiato(int danno)
    {
        //prende il danno dei nemici
        vitaCorrente -= danno;

        UIManager.Instance.vitaTorre.fillAmount = vitaCorrente / vitaMax;

        //se la vita scende a 0, finsice il gioco
        if (vitaCorrente <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

}
