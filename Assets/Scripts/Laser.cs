using UnityEngine;

public class Laser : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, 200))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                cube.Destroy();
            }
        }
    }
}