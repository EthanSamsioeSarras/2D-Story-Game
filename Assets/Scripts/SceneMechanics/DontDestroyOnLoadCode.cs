using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadCode : MonoBehaviour
{
    [HideInInspector] public string objectID;

    private void Awake()
    {

        objectID = name + transform.position.ToString();

        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnLoadCode>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyOnLoadCode>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestroyOnLoadCode>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
