using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Rigidbody2D vehicleRigidBody; // our vehicle itself
    public Rigidbody2D backTire; // backTire of our vehicle
    public Rigidbody2D frontTire; // frontTire of our vehicle
    public float speed = 20; // speed of our vehicle with a default value of 20
    public float vehicleTorque = 10; // torque (couple moteur en francais) with a default value of 10 - for the rotation movement

    private float direction; // player is pressing LEFT or RIGHT on his keyboardkey

    void Update()
    {
        this.direction = Input.GetAxis("Horizontal"); // get the direction
    }

    private void FixedUpdate() {
        this.backTire.AddTorque(- this.direction * this.speed * Time.fixedDeltaTime); // add torque (v*t) to the backTire wheter he is pressing the left or right keyboardkey 
        this.frontTire.AddTorque(- this.direction * this.speed * Time.fixedDeltaTime); // add torque (v*t) to the frontTire wheter he is pressing the left or right keyboardkey 
        this.vehicleRigidBody.AddTorque(this.direction * this.vehicleTorque * Time.fixedDeltaTime); //add torque (v*t) to the vehicle wheter he is pressing the left or right keyboardkey -> rotate
    }
}
