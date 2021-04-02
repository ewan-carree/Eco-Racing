using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{ //parallex effect affects the layer considered and adapt it with the camera movement

    private float lengthSprite; //length of the layer
    private float startPositionSprite; // initial position in the background where the player start the game
    public GameObject mainCamera;
    public float parallaxEffect; // affects the way the layer in background will move [0,1]
    
    void Start() {
        this.startPositionSprite = transform.position.x; // get the initial position
        this.lengthSprite = GetComponent<SpriteRenderer>().bounds.size.x; // get the size of layer from SpriteRenderer object
    }

    void FixedUpdate() {
        float distanceFromStartPoint = this.mainCamera.transform.position.x * this.parallaxEffect; // compute the distance between the edge of the layer and the start point
        transform.position = new Vector3(this.startPositionSprite + distanceFromStartPoint, transform.position.y, transform.position.z); // we only update x of the layer

        float distanceFromCamera = this.mainCamera.transform.position.x * (1 - this.parallaxEffect); // compute the distance between the edge of the layer and the camera
        if(distanceFromCamera > this.startPositionSprite + this.lengthSprite) {
            this.startPositionSprite += this.lengthSprite; //move layer on the right when we meet the edge 
        }
        else if(distanceFromCamera < this.startPositionSprite - this.lengthSprite) {
            this.startPositionSprite -= this.lengthSprite; //move layer on the left when we meet the edge
        }
    }
    
}
