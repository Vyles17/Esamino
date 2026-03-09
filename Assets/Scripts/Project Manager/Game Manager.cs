using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    InPausa,
    InGioco
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public KeyCode TastoPausa;
    private bool Pausizzato = false;

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
        SetGameStatus(GameStatus.InGioco);
    }
    public void Update()
    {
        if (Input.GetKeyDown(TastoPausa))
        {
            Pausa();
        }
    }

    public void SetGameStatus(GameStatus status)
    {
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

    public void Pausa()
    {
        Pausizzato = !Pausizzato;

        if (Pausizzato)
        {
            SetGameStatus(GameStatus.InPausa);
            UIManager.Instance.menuPausa.SetActive(true);
        }

        else
        {
            SetGameStatus(GameStatus.InGioco);
            UIManager.Instance.menuPausa.SetActive(false);
        }
    }

    public void GameOver()
    {
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.menuGameOver.SetActive(true);
    }
    public void Vincita()
    {
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.menuVincita.SetActive(true);
    }

    public void NuovaPartita()
    {
        SceneManager.LoadScene(1);
    }

    public void AlMenuPrincipale()
    {
        SceneManager.LoadScene(0);
    }

    public void RicaricaLivello()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChiudiApp()
    {
        Application.Quit();
    }
}
