using UnityEngine;

public class GetInCar : MonoBehaviour
{
    public GameObject car, player, dummyInCar, lights, carCam, enemyDetect;
    private bool inCar = false;
    WheelController driveScript;

    private void Start() {
        driveScript = car.GetComponent<WheelController>();
        driveScript.enabled = false;
        
    }

    // public void OnTriggerStay(Collider other) {
    //     print ($"collision with {other} has been detected");

    //     if(other.CompareTag("Astro"))
    //         print ("Astro is here");

    //     if(!inCar)
    //         print ("InCar is false");

    //     if(other.CompareTag("Astro") && !inCar && Input.GetKeyDown(KeyCode.E)) {

    //         print ("pressed E");

    //         driveScript.enabled = true;
    //         player.transform.parent = car.transform;
    //         dummyInCar.SetActive(true);
    //         lights.SetActive(true);
    //         player.SetActive(false);
    //         carCam.SetActive(true);
    //         inCar = true;
    //     }

    //     if (inCar)
    //         print ("You Are In");

    //     if(driveScript.enabled)
    //         print ("Car can go now");
        
    // }

    private void Update() {

        if(!inCar && Input.GetKeyDown(KeyCode.E)) {
             driveScript.enabled = true;
            player.transform.parent = car.transform;
            dummyInCar.SetActive(true);
            lights.SetActive(true);
            player.SetActive(false);
            carCam.SetActive(true);
            enemyDetect.SetActive(true);
            inCar = true;

        } else if (inCar && Input.GetKeyDown(KeyCode.E)) {

            player.SetActive(true);
            lights.SetActive(false);
            dummyInCar.SetActive(false);
            carCam.SetActive(false);
            enemyDetect.SetActive(false);
            player.transform.parent = null;
            driveScript.enabled = false;
            inCar = false;
        }
    }

}
