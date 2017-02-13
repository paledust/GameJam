using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyPrefeb;
	public int MaxEnemyNumber;
	private int EnemyNumber;
	public Transform[] spawnLocation;
	private bool ifSpawn;
	public float coolDown;
	private float timer;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if(EnemyNumber < MaxEnemyNumber)
		{
			ifSpawn = true;
		}

		if(getSpawn())
		{
			SpawnEnemy();
		}
	}
	public void SpawnEnemy()
	{
		timer += Time.deltaTime;
		if(timer >= coolDown)
		{
			int i = Random.Range(0,spawnLocation.Length);
			Instantiate(enemyPrefeb,spawnLocation[i].position + Vector3.left * Random.Range(-40,40) + Vector3.up * Random.Range(-40,40),
						spawnLocation[i].rotation);
			timer = 0.0f;
			addEnemy();
		}
	}

	private void addEnemy()
	{
		EnemyNumber++;
	}

	public void SubEnemy()
	{
		EnemyNumber--;
	}

	public bool getSpawn()
	{
		return ifSpawn;
	}
}
