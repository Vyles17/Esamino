using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    InPausa,
    InGioco
}

public class GameManager : MonoBehaviour
{
    [SerializeField] public KeyCode TastoPausa;
    private bool Pausizzato = false;

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

    private void SetGameStatus(GameStatus status)
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
            UIManager.Instance.MenuPausa.SetActive(true);
        }

        else
        {
            SetGameStatus(GameStatus.InGioco);
            UIManager.Instance.MenuPausa.SetActive(false);
        }
    }

    public void GameOver()
    {
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.MenuGameOver.SetActive(true);
    }
    public void Vincita()
    {
        SetGameStatus(GameStatus.InPausa);
        UIManager.Instance.MenuVincita.SetActive(true);
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
