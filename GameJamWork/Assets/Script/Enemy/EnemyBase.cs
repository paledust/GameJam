using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
	static protected GameObject player;
	public Color32 ShipColor;
	public Vector2 SpeedRange;
	public float detectRange;
	public Vector2 CirclingRange;
	[SerializeField] protected float circlingRadius;
	[SerializeField] protected float health;
	[SerializeField] protected AudioClip destroySound;
	[SerializeField] protected AudioClip spawnSound;
	[SerializeField] protected float moveSpeed;
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
		ColorInitial();
		MoveInitial();
	}

	//Initialize the Color 
	virtual protected void ColorInitial()
	{

	}

	//For movement Initialize
	virtual protected void MoveInitial()
	{
		originalRotation = transform.rotation;
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
		Destroy(gameObject,5.0f);
		ifMove = false;
	}

	// ToolBox for the Subclass
	protected void CopyMovement()
	{
		Vector3 playerVelocity = player.GetComponent<Control>().getVelocity();
		velocity = (originalRotation * playerVelocity.normalized).normalized * playerVelocity.magnitude * moveSpeed;
		transform.position += velocity;
	}

	protected void Circling()
	{
		Vector3 toPlayer = player.transform.position - transform.position;
		velocity = (toPlayer + Quaternion.Euler(0,0,90) * toPlayer.normalized * circlingRadius).normalized * moveSpeed;
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
}
