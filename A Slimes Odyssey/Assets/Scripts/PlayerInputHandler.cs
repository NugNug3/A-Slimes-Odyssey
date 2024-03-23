using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Slime slime;
    void Update()
    {
        Vector3 input = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            slime.Jump();
        }

        if(Input.GetKey(KeyCode.A))
        {
            input.x = -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            input.x = 1;
        }

        slime.MoveSlime(input);
    }
}
