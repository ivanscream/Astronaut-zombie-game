using UnityEngine;

public class CarMassCenter : MonoBehaviour
{
    public Vector3 com;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }
}
