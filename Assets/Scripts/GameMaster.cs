﻿using UnityEngine;

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

    private float MaxTimeWithoutEating = 15f;
    private float FoodTimeExtension = 1.5f;

    public float RemainingTime { get; set; }

    public int Points { get; set; }

    void Start()
    {
        WorldSpeed = MaxSpeed;

        RemainingTime = MaxTimeWithoutEating;
    }

    void Update()
    {
        Debug.Log(RemainingTime);
        RemainingTime -= Time.deltaTime;
        
        if (RemainingTime <= 0)
        {
            Time.timeScale = 0.0f;
            Debug.Log("GAME OVER!");
        }
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

    public void GainPower()
    {
        RemainingTime += FoodTimeExtension;
    }
}
