using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public static string currentCarSelected = "myLamboConvert";
    internal static string currentSelectedCar;

    

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void changeLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
