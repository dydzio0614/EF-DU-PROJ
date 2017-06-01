using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionUI;

    [SerializeField]
    private Text QuestionLabel;

    [SerializeField]
    private Text QuestionTimer;

    [SerializeField]
    private Button[] AnswerButtons;

    private enum Operation { ADD, SUB, MUL, DIV }
    private Operation NextOperation;
    private int Num1, Num2, Result;
    private int CorrectButtonIndex;
    private float CorrectAnswerTimeExtension = 2f;
    private float TimeLimit;
    private bool startTimer = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0.0f;
            transform.GetChild(0).gameObject.SetActive(false);
            QuestionUI.SetActive(true);
            PickQuestion();
            startTimer = true;
        }
    }

    private void Update()
    {
        if (startTimer)
        {   
            TimeLimit -= Time.unscaledDeltaTime;
            QuestionTimer.text = (TimeLimit % 60 - TimeLimit % 0.1).ToString();
            if (TimeLimit <= 0)
                BadAnswer();
        }
    }

    private void PickQuestion()
    {
        NextOperation = (Operation)Random.Range(0, 4);

        if (NextOperation == Operation.ADD || NextOperation == Operation.SUB)
        {
            Num1 = Random.Range(0, 100);
            Num2 = Random.Range(0, 100);
            TimeLimit = 10f;
        }
        else if (NextOperation == Operation.MUL)
        {
            Num1 = Random.Range(3, 20);
            Num2 = Random.Range(6, 20);
            TimeLimit = 15f;
        }
        else if (NextOperation == Operation.DIV)
        {
            List<int> validDividers = new List<int>();
            while (validDividers.Count == 0) //if no valid dividers, try another num1
            {
                Num1 = Random.Range(45, 200);
                for (int i = 4; i < 15; i++) //Num2 = Random.Range(4,15) with validity check
                    if (Num1 % i == 0)
                        validDividers.Add(i);
            }
            Num2 = validDividers[Random.Range(0, validDividers.Count)];
            TimeLimit = 20f;
        }
        else
            Debug.Log("Invalid math operation specified!");

        switch (NextOperation)
        {
            case Operation.ADD:
                Result = Num1 + Num2;
                QuestionLabel.text = Num1 + " + " + Num2;
                break;
            case Operation.SUB:
                Result = Num1 - Num2;
                QuestionLabel.text = Num1 + " - " + Num2;
                break;
            case Operation.MUL:
                Result = Num1 * Num2;
                QuestionLabel.text = Num1 + " * " + Num2;
                break;
            case Operation.DIV:
                Result = Num1 / Num2;
                QuestionLabel.text = Num1 + " / " + Num2;
                break;
        }

        ShowAnswers();
    }

    private void ShowAnswers()
    {
        CorrectButtonIndex = Random.Range(0, 4);
        AnswerButtons[CorrectButtonIndex].GetComponentInChildren<Text>().text = Result.ToString();
        AnswerButtons[CorrectButtonIndex].onClick.AddListener(CorrectAnswer);

        for (int i = 0; i < 4; i++)
        {
            if (i == CorrectButtonIndex) continue;
            int embroil = Result + RandomExcept(-10, 11, 0);
            AnswerButtons[i].GetComponentInChildren<Text>().text = embroil.ToString();
            AnswerButtons[i].onClick.AddListener(BadAnswer);
        }
    }

    private void CorrectAnswer()
    {
        GameMaster.Instance.Points++;
        GameMaster.Instance.GainPower(CorrectAnswerTimeExtension);
        Return();
    }

    private void BadAnswer()
    {
        GameMaster.Instance.SlowDown();
        Return();
    }

    public void Return()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }

    private int RandomExcept(int min, int max, int except)
    {
        int random;
        while (true)
            if ((random = Random.Range(min, max)) != except)
                return random;
    }
}
