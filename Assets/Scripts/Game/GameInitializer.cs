using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

	void Start ()
    {
        LevelManager.instance.StartNextLevel();
	}
}