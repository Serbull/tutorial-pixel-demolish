using UnityEngine;

public class Gear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Cube cube))
        {
            cube.Destroy();
        }
    }
}