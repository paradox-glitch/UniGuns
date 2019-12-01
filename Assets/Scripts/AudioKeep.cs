//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Keeps Audio from this scene if there is none in the next.

using UnityEngine;

public class AudioKeep : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musics = GameObject.FindGameObjectsWithTag("Music");
        if (musics.Length > 1 && PlayerManager.keepAudio == false)
            Destroy(musics[0]);
        else if(musics.Length > 1 && PlayerManager.keepAudio == true)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}