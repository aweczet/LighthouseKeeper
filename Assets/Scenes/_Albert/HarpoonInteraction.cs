using System;
using UnityEngine;

public class HarpoonInteraction : MonoBehaviour
{
    public Transform target;
    public Rigidbody harpoonPrefab;
    private Transform _origin;
    private void Start()
    {
        _origin = transform.GetChild(0);
    }

    public void Shoot()
    {
        Debug.Log("Harpoon!");
        Vector3 calculatedVelocity = CalculateVelocity(.5f);
        Rigidbody harpoon = Instantiate(harpoonPrefab, _origin.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        harpoon.velocity = calculatedVelocity;
    }
    
    private Vector3 CalculateVelocity(float time)
    {
        Vector3 distance = target.position - transform.position;
        Vector3 distanceXZ = distance;
        // distanceXZ.Normalize();
        distanceXZ.y = 0f;

        float y = distance.y;
        float xz = distanceXZ.magnitude;

        float Vxz = xz / time;
        float Vy = y / time + .5f * Mathf.Abs(Physics.gravity.y) * time;

        // Vector3 result = distanceXZ * Vxz;
        // result.y = Vy;
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }
}
