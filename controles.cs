﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controles : MonoBehaviour {

	public void BackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
}
