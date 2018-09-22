﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp;
    public int dmg;
    public float mvtSpd;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        chase();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Controller.Instance.invulnTimer < 0)
            {
                PlayerController.pc.HP -= dmg;
                Controller.Instance.invulnTimer = 2f;
            }
        }
    }

    public void chase()
    {
        Vector3 distToPlayer = new Vector2(PlayerController.pc.transform.position.x - transform.position.x, PlayerController.pc.transform.position.y - transform.position.y);
        if (distToPlayer.magnitude < 10f)
        {
            distToPlayer = distToPlayer.normalized;
            transform.position += distToPlayer * mvtSpd * Time.deltaTime;
        }
    }
}