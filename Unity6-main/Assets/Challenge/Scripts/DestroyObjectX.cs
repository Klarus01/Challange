using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        // destroy particle after delay
        Destroy(gameObject, 2);
    }
}
