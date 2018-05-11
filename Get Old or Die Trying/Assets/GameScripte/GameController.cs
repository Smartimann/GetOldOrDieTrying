using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController {

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
