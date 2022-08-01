using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
public class RestartGame : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
