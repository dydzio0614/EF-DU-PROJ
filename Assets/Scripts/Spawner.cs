using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
    private GameObject[] Obstacles;
    [SerializeField]
    private GameObject[] Food;

    [SerializeField]
    private float SpawnCycle = 0.5f;

    private float TimeElapsed;

    private bool SpawnFood = true;
	
	void Update ()
    {
        TimeElapsed += Time.deltaTime;
        if(TimeElapsed > SpawnCycle)
        {
            if (SpawnFood)
            {
                GameObject temp = Instantiate(Food[Random.Range(0, Food.Length)]);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }
            else
            {
                GameObject temp = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
            }
            SpawnFood = !SpawnFood;

            TimeElapsed -= SpawnCycle;
        }
    }
}
