using UnityEngine;
using System.Collections;

public class HourGlass : MonoBehaviour
{
    private float rotationSpeed = 40f;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Astro")) {
            StartCoroutine(SlowMo());
        }
    }

    IEnumerator SlowMo() {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(3f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
    }
    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
