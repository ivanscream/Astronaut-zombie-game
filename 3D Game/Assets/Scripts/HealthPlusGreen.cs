using UnityEngine;
using System.Collections;

public class HealthPlusGreen : MonoBehaviour
{
    private float rotationSpeed = 40f;
    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Astro"))
            StartCoroutine(PlusHealth());
    }

    IEnumerator PlusHealth() {

        PlayerHealth.health += 30f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(3f);

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
    }
}
