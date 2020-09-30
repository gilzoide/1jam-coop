using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public FadeAlpha fadeAlpha;
    public Button continueButton;

    void Awake()
    {
        if (!fadeAlpha)
        {
            fadeAlpha = GetComponentInChildren<FadeAlpha>();
        }
    }

    public void Appear()
    {
        Time.timeScale = 0f;
        fadeAlpha.FadeIn();
        EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
    }

    public void RetryGameplay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
