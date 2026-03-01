using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] public GameObject MenuPausa;
    [SerializeField] public GameObject MenuGameOver;
    [SerializeField] public GameObject MenuVincita;


    //All'inizio del gioco disattivo la UI dei menù
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        MenuPausa.SetActive(false);
        MenuGameOver.SetActive(false);
        MenuVincita.SetActive(false);

    }
}
