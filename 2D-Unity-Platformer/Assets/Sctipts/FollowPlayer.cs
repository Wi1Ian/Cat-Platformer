using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private float initial;
    private void Start()
    {
        initial = player.position.y;
    }

    void Update ()
    {
        transform.position = new Vector3 (player.position.x + offset.x, initial + offset.y, offset.z);
    }
}
