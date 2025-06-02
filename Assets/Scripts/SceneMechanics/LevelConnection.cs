using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConnection", menuName = "ScriptableObject/Scenes/LevelConnection")]
public class LevelConnection : ScriptableObject
{
    public static LevelConnection ActiveConnection { get; set; }
}
