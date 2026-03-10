using UnityEngine;
using UnityEngine.SceneManagement;

//gli stati di gioco
public enum GameStatus
{
    InPausa,
    InGioco
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //pulsante per pausizzre e il suo bool di stato
    [SerializeField] KeyCode TastoPausa;
    private bool Pausizzato = false;

    //contatore dei nemici uccisi (servono per le win condition/per printarlo a schermo quando facciamo game Over)
    public int nemiciUccisi = 0;
    public int nemiciDaUccidere = 5;

    //richiamiamo l'evento OnNemiciUccisi per aggiornare il contatore
    private void OnEnable()
    {
        Nemici.OnNemiciUccisi += UpdateNemiciUccisi;
    }

    private void OnDisable()
    {
        Nemici.OnNemiciUccisi -= UpdateNemiciUccisi;
    }

    public void Awake()
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
        //quando parte il livello, si è subito in modalità gioco
        SetGameStatus(GameStatus.InGioco);
    }
    public void Update()
    {
        //se premoo esc, metto/tolgo la pausa
        if (Input.GetKeyDown(TastoPausa))
        {
            Pausa();
        }
    }

    public void SetGameStatus(GameStatus status)
    {
        //metodo per settare lo stato di gioco, switchandolo da uno all'altro
        switch (status)
        {
            case GameStatus.InGioco:
                Time.timeScale = 1;
               break;

            case GameStatus.InPausa:
                Time.timeScale = 0;
                break;
        }
    }

    private void UpdateNemiciUccisi()
    {
        //aggiorniamo il contatore delle uccisioni
        nemiciUccisi++;

        //e aggiorniamo il contatore UI
        int nemiciRimasti = nemiciDaUccidere - nemiciUccisi;
        UIManager.Instance.nemiciRimasti.text = "Nemici rimasti da uccidere: " + nemiciRimasti.ToString();

        //se abbiamo ucciso un tot di nemici, abbiamo vinto!
        if (nemiciRimasti == 0)
        {
            Vincita();
        }
    }

    public void Pausa()
    {
        //ecco il bool che torna utile per il nostro tasto esc
        Pausizzato = !Pausizzato;

        //avvio/tolgo il menu di pausa in base allo stato del gioco
        if (Pausizzato)
        {
            SetGameStatus(GameStatus.InPausa);
            UIManager.Instance.PausaUI();
        }

        else
        {
            SetGameStatus(GameStatus.InGioco);
            UIManager.Instance.PausaUI();
        }
    }

    public void GameOver()
    {
        //se muore la torre, è game over e si attiva la sua UI
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.GameOverUI();

        //con il contatore dei nemici uccisi per lo score raggiunto
        UIManager.Instance.nemiciUccisiGO.text = "(Non demordere, hai comunque ucciso " + nemiciUccisi.ToString() + " nemici!)";
    }

    public void Vincita()
    {
        //Se vinciamo, si attiva la UI (quando uccidiamo un tot di nemici)
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.VincitaUI();

        //con il contatore dei nemici uccisi per lo score raggiunto
        UIManager.Instance.nemiciUccisiWin.text = "(Brav*! Hai ucciso " + nemiciDaUccidere.ToString() + " nemici!)";

    }

    public void NuovaPartita()
    {
        //scene loader per caricare il livello di gioco
        SceneManager.LoadScene(1);
    }

    public void AlMenuPrincipale()
    {
        //scene loader per caricare la scena col menu principale
        SceneManager.LoadScene(0);
    }

    public void RicaricaLivello()
    {
        //scene loader per RIcaricare il livello di gioco
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChiudiApp()
    {
        //basta fine è ora di smettere di giocare tutti a nanna
        Application.Quit();
    }
}
