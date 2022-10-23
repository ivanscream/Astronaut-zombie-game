using UnityEngine;
using System.Collections;

public class ZombieAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ZombieSound());
    }

    IEnumerator ZombieSound() {
        while(true) {
            yield return new WaitForSeconds (10f);
            AudioClip nowAudio = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.clip = nowAudio;
            audioSource.Play();
        }
    }
}
