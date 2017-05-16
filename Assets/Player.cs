﻿using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float DivertSpeed = 2;

    [SerializeField]
    private float BoundaryRadius = 3;

	void Update ()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * DivertSpeed, 0f, 0f);

        if(transform.position.x > BoundaryRadius)
        {
            transform.position = new Vector3(BoundaryRadius, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -BoundaryRadius)
        {
            transform.position = new Vector3(-BoundaryRadius, transform.position.y, transform.position.z);
        }
	}
}
