using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private static GameMaster _Instance;
    public static GameMaster Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<GameMaster>();
            }
            return _Instance;
        }
    }

    [SerializeField]
    private GameObject Player;

    public float WorldSpeed { get; private set; }
    private float CurrentSpeed;

    [SerializeField]
    private float MinSpeed = 0.15f;
    [SerializeField]
    private float MaxSpeed = 0.3f;

    private float MaxTimeWithoutEating = 15f;
    private float FoodTimeExtension = 1.5f;

    [SerializeField]
    private RectTransform StatusBar;

    private float _RemainingTime;
    public float RemainingTime
    {
        get
        {
            return _RemainingTime;
        }
        set
        {
            _RemainingTime = value;
            StatusBar.localScale = new Vector3(_RemainingTime / MaxTimeWithoutEating, StatusBar.localScale.y, StatusBar.localScale.z);
        }
    }

    [SerializeField]
    private Text PointsText;

    private int _Points;
    public int Points
    {
        get
        {
            return _Points;
        }
        set
        {
            _Points = value;
            PointsText.text = _Points.ToString();
        }
    }


    [SerializeField]
    private GameObject PlayerInfoUI;
    [SerializeField]
    private GameObject GameOverUI;

    void Start()
    {
        Time.timeScale = 1.0f;
        WorldSpeed = MaxSpeed;
        RemainingTime = MaxTimeWithoutEating;
    }

    void Update()
    {
        RemainingTime -= Time.deltaTime;
        
        if (RemainingTime <= 0)
        {
            Time.timeScale = 0.0f;
            GameOver();
        }
    }

    public void SlowDown()
    {
        CancelInvoke("SpeedUp");

        WorldSpeed = MinSpeed;
        Player.GetComponent<Animator>().SetBool("tripped", true);

        Invoke("SpeedUp", 1f);
    }

    private void SpeedUp()
    {
        WorldSpeed = MaxSpeed;
        Player.GetComponent<Animator>().SetBool("tripped", false);
    }

    
    public void GainPower(float amount)
    {
        if ((RemainingTime += amount) > MaxTimeWithoutEating)
            RemainingTime = MaxTimeWithoutEating;
    }

    public void GainPower()
    {
        GainPower(FoodTimeExtension);
    }

    private void GameOver()
    {
        PlayerInfoUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
}
