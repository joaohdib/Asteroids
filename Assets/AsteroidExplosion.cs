using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{

    [SerializeField] private float delay = 0.3f; 
    void Start()
    {
        Destroy(gameObject, delay);
    }

}
