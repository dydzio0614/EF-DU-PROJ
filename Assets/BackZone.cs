using UnityEngine;

public class BackZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fence")
        {
            other.transform.Translate(-64.8f, 0f, 0f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
