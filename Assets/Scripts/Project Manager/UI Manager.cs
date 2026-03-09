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

}
