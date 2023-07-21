using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControlScript : MonoBehaviour
{
    [SerializeField] private FovScript fovController;
    [SerializeField] private float lookAcceleration = 2f;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        var offset = ((Vector2) Input.mousePosition) - (new Vector2(Screen.width, Screen.height) / 2f);
        var angle = Vector2.Angle(Vector2.up, offset) * Mathf.Sign(offset.x);
        fovController.Rotation = Mathf.LerpAngle(fovController.Rotation, angle, 1f - (Mathf.Pow(0.5f, Time.deltaTime * lookAcceleration)));
    }
}
