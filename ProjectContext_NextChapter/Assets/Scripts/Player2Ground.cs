﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            PlayerMove.Player2isGround = true;
    }
}
