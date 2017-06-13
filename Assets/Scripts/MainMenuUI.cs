using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField]
    private Text highScoreText;

    void Start()
    {
        highScoreText.GetComponent<Text>().text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
