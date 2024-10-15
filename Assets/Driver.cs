using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float cooldown = 5.0f;

    private float currentCooldown = 0;
    private float currentSpeed;
    void Start()
    {
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0,moveAmount,0);

        if(currentCooldown > 0){
            currentCooldown -= Time.deltaTime;
            
        }

        if(currentCooldown <= 0 && currentSpeed != moveSpeed)
        {
            currentCooldown = 0;
            currentSpeed = moveSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        currentSpeed = slowSpeed;
        currentCooldown = cooldown;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            currentSpeed = boostSpeed;
            currentCooldown = cooldown;
        }
    }
}
