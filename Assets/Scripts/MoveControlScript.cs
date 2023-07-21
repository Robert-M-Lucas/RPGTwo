using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControlScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float playerSize = 0.5f;
    [SerializeField] private LayerMask solidLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector2();
        if (Input.GetKey(KeybindConfig.Get().MoveUp))
        {
            move += Vector2.up * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeybindConfig.Get().MoveDown))
        {
            move += Vector2.down * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeybindConfig.Get().MoveLeft))
        {
            move += Vector2.left * (Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeybindConfig.Get().MoveRight))
        {
            move += Vector2.right * (Time.deltaTime * moveSpeed);
        }
        
        var hit = Physics2D.CircleCast((Vector2) transform.position + (move * 0.1f), playerSize * 0.9f, move, move.magnitude * 0.9f, solidLayer);
        if (hit)
        {
            var hit_actual = Physics2D.CircleCast(transform.position, playerSize, move, move.magnitude, solidLayer);
            transform.position = hit_actual.centroid;
        }
        else
        {
            transform.position += (Vector3) move;
        }

        
    }
}
