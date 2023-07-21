using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class KeybindConfig
{
    public KeyCode MoveUp = KeyCode.W;
    public KeyCode MoveDown = KeyCode.S;
    public KeyCode MoveLeft = KeyCode.A;
    public KeyCode MoveRight = KeyCode.D;

    [CanBeNull] private static KeybindConfig singleton = null;
    
    public static KeybindConfig Get()
    {
        return singleton ??= new KeybindConfig();
    }
}
