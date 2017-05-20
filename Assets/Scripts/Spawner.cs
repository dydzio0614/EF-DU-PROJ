using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
    private GameObject[] Obstacles;
    [SerializeField]
    private GameObject[] Food;
    [SerializeField]
    private GameObject QuestionMark;

    [SerializeField]
    private float SpawnCycle = 0.5f;

    private float TimeElapsed;

    private enum ObjectToSpawn { FOOD, OBSTACLE, QUESTION };
    int NextObject = 0;
	
	void Update ()
    {
        TimeElapsed += Time.deltaTime;
        if(TimeElapsed > SpawnCycle)
        {
            switch ((ObjectToSpawn)NextObject)
            {
                case ObjectToSpawn.FOOD:
                    SpawnAndPlace(Food[Random.Range(0, Food.Length)]);
                    break;
                case ObjectToSpawn.OBSTACLE:
                    SpawnAndPlace(Obstacles[Random.Range(0, Obstacles.Length)]);
                    break;
                case ObjectToSpawn.QUESTION:
                    SpawnAndPlace(QuestionMark);
                    break;
            }
            NextObject = (NextObject + 1) % 3;

            TimeElapsed -= SpawnCycle;
        }
    }

    void SpawnAndPlace(GameObject prefab)
    {
        GameObject temp = Instantiate(prefab);
        temp.transform.position = new Vector3(Random.Range(-3, 4), temp.transform.position.y, temp.transform.position.z);
    }
}
