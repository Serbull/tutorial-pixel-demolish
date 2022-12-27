using UnityEngine;

public class Saw : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            cube.Detouch();
        }
    }
}