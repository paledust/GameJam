using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
	static protected GameObject player;
	public Color32 ShipColor;
	public Vector2 SpeedRange;
	public float detectRange;
	public Vector2 CirclingRange;
	protected float circlingRadius;
	[SerializeField] protected float health;
	[SerializeField] protected AudioClip destroySound;
	[SerializeField] protected AudioClip spawnSound;
	protected float moveSpeed;
	protected Vector3 velocity;
	protected float distanceToPlayer;
	protected bool ifMove = true;
	protected bool ifKill = false;
	protected Quaternion originalRotation;
	// Use this for initialization
	protected void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	protected void Start () {
		if(!GetComponent<AudioSource>())
			gameObject.AddComponent<AudioSource>();

		GetComponent<AudioSource>().PlayOneShot(spawnSound);
		moveSpeed = Random.Range(SpeedRange.x,SpeedRange.y);
		MoveInitial();
	}

	//For movement Initialize
	virtual protected void MoveInitial()
	{
		originalRotation = transform.rotation;
	}

	protected void ColorInitial()
	{
		Color _color = ColorChoose.ColorLibrary[Random.Range(0,4)];

		GetComponent<SpriteRenderer>().color = _color;

		if(GetComponent<TrailRenderer>())
		{
			GetComponent<TrailRenderer>().startColor = _color;
			GetComponent<TrailRenderer>().endColor = _color;
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		distanceToPlayer = (player.transform.position - transform.position).magnitude;
		if(ifMove)
		{
			Move();
		}
		rotate();
		if(health <= 0.0f && !ifKill)
			Kill();
	}

	//Describe how the Enemy Move
	virtual protected void Move()
	{
		
	}

	//Describe how the Enemy Rotate
	protected void rotate()
	{
		float rotationDegree = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		if(velocity.magnitude >= 0.01f)
			transform.rotation = Quaternion.Euler (0.0f, 0.0f, rotationDegree);
	}

	virtual public void ApplyDamage(float Damage)
	{
		health -= Damage;
		HitSound();
	}

	protected void HitSound()
	{
		GetComponent<AudioSource>().PlayOneShot(destroySound);
	}

	protected void Kill()
	{
		ifKill = true;
		HitSound();
		GetComponent<SpriteRenderer>().enabled = false;
		Destroy(gameObject,5.0f);
		ifMove = false;
	}

	// ToolBox for the Subclass
	protected void CopyMovement()
	{
		Vector3 playerVelocity = player.GetComponent<Control_Force>().getVelocity();
		velocity = (originalRotation * playerVelocity.normalized).normalized * playerVelocity.magnitude * moveSpeed;
	}

	protected void Circling()
	{
		Vector3 toPlayer = player.transform.position - transform.position;
		velocity = (toPlayer + Quaternion.Euler(0,0,90) * toPlayer.normalized * circlingRadius).normalized * 50 * moveSpeed;
	}

	protected bool ifInRange()
	{
		if(distanceToPlayer <= detectRange)
			return true;
		else
			return false;
	}

	public void ResetTarget(GameObject target)
	{
		player = target;
	}

	public void StayAway()
	{
		Vector2 playerDir = transform.position - player.transform.position;
		GetComponent<Rigidbody2D>().AddForce(playerDir.normalized * moveSpeed, ForceMode2D.Impulse);
	}
}
