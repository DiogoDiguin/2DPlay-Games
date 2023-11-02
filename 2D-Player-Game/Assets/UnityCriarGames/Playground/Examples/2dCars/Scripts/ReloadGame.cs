using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    [SerializeField]    private GameObject panelReloadGame;
    [SerializeField]    private GameObject pedalsCar;

    private void Start()
    {
        panelReloadGame.SetActive(false);
        pedalsCar.SetActive(true);
    }

    public void RestartGame()
    {
        // Obtém o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a cena atual para reiniciar o jogo
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    public void ShowPanel()
    {
        panelReloadGame.SetActive(true);
        pedalsCar.SetActive(false);
    }

    public void ReturnGame()
    {
        panelReloadGame.SetActive(false);
        pedalsCar.SetActive(true);
    }
}
