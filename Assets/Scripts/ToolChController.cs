using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToolChController : MonoBehaviour
{
    private PlayerMovement player;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDIstance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        rgbd2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseTool();
        }

    }

    private void UseTool()
    {
        Vector2 position = rgbd2d.position + player.lastMotionVector * offsetDIstance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            } 
        }
    }

}
