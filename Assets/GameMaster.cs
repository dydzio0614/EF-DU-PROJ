using UnityEngine;

public class GameMaster : MonoBehaviour {

    private static GameMaster instance;
    public static GameMaster Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameMaster>();
            }
            return instance;
        }
    }

    public float WorldSpeed { get; private set; }
    private float CurrentSpeed;

    [SerializeField]
    private float MinSpeed = -0.15f;
    [SerializeField]
    private float MaxSpeed = -0.3f;

    void Start()
    {
        WorldSpeed = MaxSpeed;
    }

    public void SlowDown()
    {
        CancelInvoke("SpeedUp");

        WorldSpeed = MinSpeed;

        Invoke("SpeedUp", 1f);
    }

    private void SpeedUp()
    {
        WorldSpeed = MaxSpeed;
    }
}
