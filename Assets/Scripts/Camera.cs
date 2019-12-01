//* Morgan Finney
//* NOV 19
//* For Uniguns Project - Script makes the camera zoom in and out and follow all player.

using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public List<GameObject> players;
    public Vector3 offset;
    public float maxZoom = 1, minZoom = 10, newZoom;

    private void Update()
    {
        players.Clear();
        for (int i = 0; i <= 7; i++)
        {
            if (PlayerManager.spawnedPlayers[i] != null)
                players.Add(PlayerManager.spawnedPlayers[i]);
        }
    }

    private void LateUpdate()
    {
        if (players.Count == 0)
            return;
        transform.position = Vector3.Lerp(transform.position, FindCenter() + offset, Time.deltaTime * 3);
        newZoom = Mathf.Lerp(minZoom, maxZoom, FindDistance() / 15);
        UnityEngine.Camera.main.orthographicSize = Mathf.Lerp(UnityEngine.Camera.main.orthographicSize, newZoom, Time.deltaTime * 3);
    }

    Vector3 FindCenter()
    {
        if (players.Count == 0)
            return players[0].transform.position;

        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
                bounds.Encapsulate(players[i].transform.position);
        }
        return bounds.center;
    }

    float FindDistance()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
                bounds.Encapsulate(players[i].transform.position);
        }
        if (bounds.size.x > bounds.size.y)
            return bounds.size.x;
        else
            return bounds.size.y;
    }
}