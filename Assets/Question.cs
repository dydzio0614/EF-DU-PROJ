using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionUI;

    [SerializeField]
    private Text QuestionLabel;

    [SerializeField]
    private Button[] AnswerButtons;

    private enum Operation { ADD, SUB }
    private Operation NextOperation;
    private int Num1, Num2, Result;
    private int CorrectButtonIndex;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0.0f;
            QuestionUI.SetActive(true);
            PickQuestion();
        }
    }

    private void PickQuestion()
    {
        Num1 = Random.Range(0, 100);
        Num2 = Random.Range(0, 100);

        NextOperation = (Operation)Random.Range(0, 2);

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
        GameMaster.Instance.RemainingTime += 2f;
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
        int random = Random.Range(min, max);
        if (random >= except) random = (random + 1) % max;
        return random;
    }
}
