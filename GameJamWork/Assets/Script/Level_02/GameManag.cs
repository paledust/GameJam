using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManag : MonoBehaviour {

	public BossManager[] Bosses;
	
	// Update is called once per frame
	void Update () {
		if(Bosses[0].ifDestroyed && Bosses[1].ifDestroyed && Bosses[2].ifDestroyed)
		{
			SceneManager.LoadScene("Level_Sound");
		}
	}
}
