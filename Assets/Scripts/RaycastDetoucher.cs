using UnityEngine;

public class RaycastDetoucher : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 1.5f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(r, out RaycastHit hit, 200))
        {
            if(hit.collider.TryGetComponent(out Cube cube))
            {
                cube.Destroy();
            }
            Explosion(hit.point);
        }
    }

    private void Explosion(Vector3 point)
    {
        var colliders = Physics.OverlapSphere(point, _explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Cube cube))
            {
                if(!cube.Detouched)
                {
                    cube.Detouch();
                    cube.GetComponent<Rigidbody>().AddExplosionForce(1000f, point, _explosionRadius);
                }
                else
                {
                    cube.Destroy();
                }
            }
        }
    }
}
