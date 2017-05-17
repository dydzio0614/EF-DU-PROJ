using UnityEngine;

public class Ground : MonoBehaviour {

    void Update()
    {
        float offset = Time.time * GameMaster.Instance.WorldSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
    }
}
