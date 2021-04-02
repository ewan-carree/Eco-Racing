using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bien séparer grounded et not grounded et gérer rotation et vitesse en l'air


public class Vehicle : MonoBehaviour
{
    public Rigidbody2D vehicleRigidBody; // our vehicle itself
    public Rigidbody2D backTire; // backTire of our vehicle
    public Rigidbody2D frontTire; // frontTire of our vehicle

    public float speed; // speed of our vehicle
    public float vehicleTorque; // couple moteur - for the rotation movement

    public float horsePower; // chevaux
    private float acceleration = 1; // time enable for the vehicle to accelerate

    private bool isGrounded; // the vehicle touches the ground

    private float direction; // player is pressing LEFT or RIGHT on his keyboardkey

    void Update()
    {
        this.direction =  Input.GetAxis("Horizontal"); // get the direction [-1,1]
        this.direction = this.direction < 0 ? -1 : this.direction = this.direction > 0 ? 1 : 0; // set the direction

        // this.isGrounded = frontTire.GetComponent<Collider2D>().isTouching;
        // Debug.Log(isGrounded);
    //}

    //private void FixedUpdate() {
        if (this.acceleration > 0f) // allow the vehicle to boost its speed for a short period in time
        {
            this.acceleration -= Time.fixedDeltaTime; // update acceleration time
            Move(this.horsePower);
        }
        else {
            Move(1);
        }
    }

    private void Move(float horsePower) {
        // handle the movement of the vehicle (translation  + rotation)
        this.backTire.AddTorque(- this.direction * this.speed * Time.fixedDeltaTime * horsePower); // add torque (v*t) to the backTire wheter he is pressing the left or right keyboardkey 
        this.frontTire.AddTorque(- this.direction * this.speed * Time.fixedDeltaTime * horsePower); // add torque (v*t) to the frontTire wheter he is pressing the left or right keyboardkey 
        this.vehicleRigidBody.AddTorque(this.direction * this.vehicleTorque * Time.fixedDeltaTime); //add torque (v*t) to the vehicle wheter he is pressing the left or right keyboardkey -> rotate
    }
}