using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    [SerializeField]
    private Text PointsText;

    void Start()
    {
        Time.timeScale = 0.0f;
        PointsText.text = GameMaster.Instance.Points.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
