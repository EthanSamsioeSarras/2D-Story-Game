using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public LevelConnection connection;

    public string targetSceneName;

    public Transform spawnPoint;

    public Animator animator;

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
            FadeOut();
            LevelConnection.ActiveConnection = connection;
            SceneManager.LoadScene(targetSceneName);
        }

    }
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
