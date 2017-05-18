using UnityEngine;

public class MovingObject : MonoBehaviour {

    void Update()
    {
        transform.Translate(0, 0, GameMaster.Instance.WorldSpeed * Time.timeScale, Space.World);
    }
}
