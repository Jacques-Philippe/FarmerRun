using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed;


    private void Update()
    {
        this.transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
    }


}
