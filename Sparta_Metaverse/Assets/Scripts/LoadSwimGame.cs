using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSwimGame : MonoBehaviour
{
    public static void LoadGame()
    {
        SceneManager.LoadScene("SwimGame");
    }
}
