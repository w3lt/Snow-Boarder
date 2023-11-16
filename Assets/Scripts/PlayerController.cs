using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostedSpeed = 30f;
    [SerializeField] float normalSpeed = 10f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rb2d;
    private bool canMove = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            ResponseToBoost();
        }   
    }

    public void DisableControls()
    {
        this.canMove = false;
    }

    private void ResponseToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostedSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
