using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //I menu di gioco
    [SerializeField] public GameObject menuPausa;
    [SerializeField] public GameObject menuGameOver;
    [SerializeField] public GameObject menuVincita;

    //il testo in game per contare i nemici rimasti da uccidere
    [SerializeField] public TMP_Text nemiciRimasti;
    //e il testo del contatore nemici per il menu di GameOver/di vincita
    [SerializeField] public TMP_Text nemiciUccisiGO;
    [SerializeField] public TMP_Text nemiciUccisiWin;

    //La UI in game
    [SerializeField] public Image vitaTorre;
    [SerializeField] public TMP_Text dimDollaroniTMP;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        //All'inizio del gioco disattivo la UI dei menù
        menuPausa.SetActive(false);
        menuGameOver.SetActive(false);
        menuVincita.SetActive(false);
    }

    //i vari metodi per far comparire i menu in scena:
    public void PausaUI()
    {
        //il menu di pausa si attiva solo se non ci sono gli altri menu attivi
        if (!menuVincita.activeSelf && !menuGameOver.activeSelf)
        {
            if (!menuPausa.activeSelf)
                menuPausa.SetActive(true);

            else if (menuPausa.activeSelf)
                menuPausa.SetActive(false);
        }
    }
    public void VincitaUI()
    {
        menuVincita.SetActive(true);
    }
    public void GameOverUI()
    {
        menuGameOver.SetActive(true);
    }

    //aggiornare la UI del portafoglio
    public void UpdatePortafoglio(int portafoglio)
    {
        dimDollaroniTMP.text = portafoglio.ToString();
    }

}
