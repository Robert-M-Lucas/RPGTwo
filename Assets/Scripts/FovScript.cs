using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FovScript : MonoBehaviour
{
    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform player;
    [SerializeField] private float normFov = 135f;
    [SerializeField] private int rayCount = 500;
    [SerializeField] private float rotation = 0f;
    
    public float ViewDistance = 50f;

    [SerializeField] private Material showMaterial;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    float angleStep;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = showMaterial;
        meshFilter = GetComponent<MeshFilter>();
    }

    // Start is called before the first frame update
    void Update()
    {
        rotation += Time.deltaTime * 10;
        
        float fov = normFov;
        angleStep = fov / rayCount;
        float angle = -rotation + 90 + (fov / 2);

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3 origin = player.transform.position;

        Vector3[] verticies = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[rayCount + 2];
        int[] triangles = new int[rayCount * 3];

        verticies[0] = origin;


        int vertex_index = 1;
        int tri_index = 0;
        float view_dist = ViewDistance;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 direction = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180)), Mathf.Sin(angle * (Mathf.PI / 180)));
            Vector3 vertex;

            RaycastHit2D ray_hit = Physics2D.Raycast(origin, direction, view_dist, layerMask);

            if (ray_hit.collider is null)
            {
                vertex = origin +
                         (new Vector3(Mathf.Cos(angle * (Mathf.PI / 180)), Mathf.Sin(angle * (Mathf.PI / 180))) *
                          view_dist);
            }
            else
            {
                vertex = ray_hit.point;
            }

            verticies[vertex_index] = vertex;

            if (i > 0)
            {
                triangles[tri_index + 0] = 0;
                triangles[tri_index + 1] = vertex_index - 1;
                triangles[tri_index + 2] = vertex_index;

                tri_index += 3;
            }

            vertex_index++;
            angle -= angleStep;
        }

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
