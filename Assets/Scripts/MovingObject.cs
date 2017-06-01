using UnityEngine;

public class MovingObject : MonoBehaviour {

    void Update()
    {
        transform.Translate(Vector3.forward * GameMaster.Instance.WorldSpeed * Time.timeScale, Space.World);
    }
}
