using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform player;

    private Transform camera;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.FindObjectOfType<Camera>().transform;
        this.player = GameObject.FindObjectOfType<PlayerMovement>().transform;
        this.offset = this.camera.position - this.player.position;
    }

    // Update is called once per frame
    void Update()
    {
        var isCameraInPosition = this.camera.position == this.player.position + this.offset;
        if (!isCameraInPosition)
        {
            this.camera.position = this.player.position + this.offset;
        }
        
    }
}
