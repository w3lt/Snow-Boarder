using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAmount = 1f;
    private bool isCrashed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Head")
        {
            ParticleSystem crashEffect = collision.collider.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            crashEffect.Play();
            if (!isCrashed)
            {
                isCrashed = true;
                FindAnyObjectByType<PlayerController>().DisableControls();
                transform.GetComponent<AudioSource>().Play();
            }
            Invoke("ReloadScene", delayAmount);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
