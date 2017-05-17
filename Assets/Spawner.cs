using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
    private GameObject[] Obstacles;

    [SerializeField]
    private float SpawnCycle = 0.5f;

    private float TimeElapsed;
	
	void Update ()
    {
        TimeElapsed += Time.deltaTime;
        if(TimeElapsed > SpawnCycle)
        {
            GameObject temp = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);

            TimeElapsed -= SpawnCycle;
        }
    }
}
