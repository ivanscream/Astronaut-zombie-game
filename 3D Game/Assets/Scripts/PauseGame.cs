using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool paused;
    public GameObject pauseMenu;
    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape) && !paused) {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(true);
        } else if ((Input.GetKeyUp(KeyCode.Escape) && paused)) {
            Time.timeScale = 1;
            paused = false;
            pauseMenu.SetActive(false);
        }
    }


}
