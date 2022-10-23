using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100;
    public static bool death;
    private Rigidbody rb;
    public float forceOnDeath = 10f, torqueForce = 20f;
    public RectTransform healthBar;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // void OnTriggerEnter(Collider other) {
    //     if(other.CompareTag("HealthCol")) {
    //         health += Collectibles.itemsCaller.GiveHealth(other.gameObject);
    //     }
    // }
    public void TakeDamage(float damage) {
        health -= damage;
        SetHealthBar();
        if(health <= 0 && !death) {
            death = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.back * forceOnDeath, ForceMode.Impulse);
            rb.AddTorque(Vector3.left * torqueForce, ForceMode.Impulse);
        }
    }

    public void SetHealthBar() {
        healthBar.offsetMax = new Vector2(-1f * 126f * (100f - health) / 100f, 0);
    }
}
