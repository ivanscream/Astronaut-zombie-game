using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float playerDamage = 20f;
    private bool attack;
    private Collider zombie;
    private Animator anim;
    private AudioSource audioHit;
    public float bulletDamage = 30f;
    public float hitForce = 100f;
    public Camera cam;

    void Start() {
        anim = transform.parent.GetComponent<Animator>();
        audioHit = GetComponent<AudioSource>();
    }
    void Update() {
        if(Input.GetMouseButtonDown(0) && attack && zombie != null && !PlayerHealth.death) {
            zombie.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
            anim.SetTrigger("Attack");
            audioHit.Play();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && attack && zombie != null && !PlayerHealth.death) {
            zombie.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
            anim.SetTrigger("Attack");
            audioHit.Play();
        }

        Shoot();
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Zombie")) {
            attack = true;
            zombie = other;
        } 
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Zombie")) {
            attack = false;
            zombie = null;
        }
    }

    private void Shoot() {
         if(Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100)){
                if(hit.collider.CompareTag("Zombie")){
                    hit.collider.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
                    anim.SetTrigger("Attack");
                    hit.rigidbody.AddForce(-hit.normal * hitForce, ForceMode.Impulse);

                }
            }
         }
    }
    
    
}
