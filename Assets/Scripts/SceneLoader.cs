//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Loads a random scene.

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void RandomPlayScene()
    {
        SceneManager.LoadScene(Mathf.RoundToInt(Random.Range(4,6)));
    }
}