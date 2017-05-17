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

    void Start()
    {
        WorldSpeed = -0.3f;
    }
}
