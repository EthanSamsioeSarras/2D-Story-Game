using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private LevelConnection connection;

    [SerializeField] private string targetSceneName;

    [SerializeField] private Transform spawnPoint;

    void Start()
    {

        if (connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<PlayerMovementV1>().transform.position = spawnPoint.position;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMovementV1>();
        if (player != null)
        {
            LevelConnection.ActiveConnection = connection;
            SceneManager.LoadScene(targetSceneName);
        }

    }
}
