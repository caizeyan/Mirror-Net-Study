using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private void Update()
    {
        Move();   
    }

    private void Move()
    {
        if (isLocalPlayer)
        {
            var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0)*0.1f;
            transform.position += move;
        }
    }
}
