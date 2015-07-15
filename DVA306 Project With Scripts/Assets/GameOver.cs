using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void OnDestroy()
	{
		if (Game.gameover==false)
		{
			if (tag == "HomeBasePlayer")
				Game.lastbattle = "You lost your main base, how?";
			if (tag == "HomeBaseEnemy")
				Game.lastbattle = "HOW DID YOU WIN?!";
			if (tag == "Hero")
				Game.lastbattle = "You lost your hero. Try again?";
			Game.gameover = true;
			Application.LoadLevel(0);
		}
	}
}
