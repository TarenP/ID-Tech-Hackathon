using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{
    public void switchScenes()
    {
        SceneManager.LoadScene(1);
    }
}
