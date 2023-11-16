using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayAmount = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("The game is finished!");
            ParticleSystem finishEffect = transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
            finishEffect.Play();
            transform.GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayAmount);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
