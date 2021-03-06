﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Force : MonoBehaviour
{
	// Use this for initialization
	public float speed;
	public GameObject bullet;
	public float bulletSpeed;
	public float ShootPause;
	private float shootTimer;
	[SerializeField] bool ifMove;

	void Start ()
	{
		ifMove = true;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		shootTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Rotate ();
	}

	void FixedUpdate()
	{
		if(ifMove)
			Move();
	}

	void Move ()
	{
		Vector2 idealVel = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")).normalized;
		GetComponent<Rigidbody2D>().AddForce(idealVel * speed, ForceMode2D.Impulse);
	}

	void Rotate ()
	{
		float rotationDegree = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
		if(GetComponent<Rigidbody2D>().velocity.magnitude != 0)
			transform.rotation = Quaternion.Euler (0.0f, 0.0f, rotationDegree);
	}

	void Shoot ()
	{
		GameObject new_Bullet = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
		new_Bullet.GetComponent<Rigidbody2D> ().velocity = transform.rotation * Vector2.right * bulletSpeed;
	}

	public Vector3 getVelocity()
	{
		return 	GetComponent<Rigidbody2D>().velocity;
	}

	public void setMove(bool _ifMove)
	{
		ifMove = _ifMove;
	}

	public void ApplyForce(Vector3 _Force)
	{
		GetComponent<Rigidbody2D>().AddForce(_Force, ForceMode2D.Impulse);
	}
}
