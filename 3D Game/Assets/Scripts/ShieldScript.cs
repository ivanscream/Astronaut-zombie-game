using System.Collections;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public Material mat1, mat2;
    public GameObject player;
    private float rotationSpeed = 40f;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Astro")) {
            StartCoroutine(GodMod());
        }
    }

    IEnumerator GodMod() {
        
        EnemyAttack.damage = 0f;
        player.GetComponent<SkinnedMeshRenderer>().material = mat2;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(10f);

        EnemyAttack.damage = 5f;
        player.GetComponent<SkinnedMeshRenderer>().material = mat1;

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
    }

    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}

