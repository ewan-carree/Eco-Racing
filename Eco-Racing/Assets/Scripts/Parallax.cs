using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float lengthSprite;
    private float startPositionSprite;
    public GameObject mainCamera;
    public float parallaxEffect; // [0,1]
    
    void Start() {
        this.startPositionSprite = transform.position.x;
        this.lengthSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate() {
        float distanceFromCamera = this.mainCamera.transform.position.x * (1 - this.parallaxEffect);
        float distanceFromStartPoint = this.mainCamera.transform.position.x * this.parallaxEffect;
        transform.position = new Vector3(this.startPositionSprite + distanceFromStartPoint, transform.position.y, transform.position.z);

        if(distanceFromCamera > this.startPositionSprite + this.lengthSprite) {
            this.startPositionSprite += this.lengthSprite;
        }
        else if(distanceFromCamera < this.startPositionSprite - this.lengthSprite) {
            this.startPositionSprite -= this.lengthSprite;
        }
    }
    
}
