using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject player;
    public float cameraOffset = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float difference = this.player.transform.position.x - this.gameCamera.transform.position.x;
        if (Math.Abs(difference) > cameraOffset) {
            float adjustment = Math.Abs(difference) - cameraOffset;
            adjustment = difference > 0 ? adjustment : -adjustment;
            this.gameCamera.transform.position = new Vector3(this.gameCamera.transform.position.x + adjustment, 
                                                                this.gameCamera.transform.position.y, 
                                                                this.gameCamera.transform.position.z);
        }

    }
}
