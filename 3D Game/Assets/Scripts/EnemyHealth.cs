using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private Animator anim;
    public GameObject healthBar;
    private AudioSource deathSound;
    
    void Start() {
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if(healthBar != null)
            healthBar.transform.localScale = new Vector3(health / 100f, 0.05f, 0.001f);

        if(health <= 0) {
            GetComponent<NavMeshAgent>().enabled = false;
            anim.SetBool("isDead", true);
            anim.SetBool("isAttacking", false);
            Destroy(gameObject, 3f);
            healthBar.SetActive(false);
            deathSound.Play();
        }
    }
}
