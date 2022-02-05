using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR 

using UnityEditor;

[CustomEditor(typeof(SphereMaker))]
public class SphereMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            ((SphereMaker)target).Generate();
        }
    }
}

#endif

public class SphereMaker : MonoBehaviour
{
    [SerializeField] int resolutionHorizontal = 10;
    [SerializeField] int resolutionVertical = 10;

    public void Generate()
    {

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        mesh.Clear();

        mesh.name = "Sphere";


        Vector3[] vertices = new Vector3[resolutionHorizontal * resolutionVertical];
        Vector2[] uvs = new Vector2[resolutionHorizontal * resolutionVertical];
        int[] triangles = new int[(resolutionHorizontal - 1) * (resolutionHorizontal - 1) * 2 * 3];

        for (int i = 0; i < resolutionVertical; i++)
        {
            float verticalStep = 1 / (float)resolutionVertical;
            float normalizedVertical = ((i * verticalStep) + (verticalStep * .5f));
            float phi = Mathf.PI * (normalizedVertical);

            for (int j = 0; j < resolutionHorizontal; j++)
            {
                int vertexIndex = (i * resolutionHorizontal) + j;

                float normalizedHorizontal = ((float)j / (float)(resolutionHorizontal - 1));
                float theta = 2 * Mathf.PI * normalizedHorizontal;

                float x = Mathf.Sin(phi) * Mathf.Cos(theta);
                float y = Mathf.Cos(phi);
                float z = Mathf.Sin(phi) * Mathf.Sin(theta);


                int _M0 = 4;
                int _M1 = 1;
                int _M2 = 0;
                int _M3 = 1;
                int _M4 = 0;
                int _M5 = 1;
                int _M6 = 0;
                int _M7 = 1;

                float r = 1;


                //                r = 1;

                r += Mathf.Pow(Mathf.Sin(_M0 * phi), _M1);
                r += Mathf.Pow(Mathf.Cos(_M2 * phi), _M3);
                r += Mathf.Pow(Mathf.Sin(_M4 * theta), _M5);
                r += Mathf.Pow(Mathf.Cos(_M6 * theta), _M7);


                r = 1;

                vertices[vertexIndex] = new Vector3(x, y, z) * r;
                uvs[vertexIndex] = new Vector2(normalizedVertical, normalizedHorizontal);
            }
        }

        int triangleIndex = 0;
        for (int i = 0; i < resolutionVertical - 1; i++)
        {
            for (int j = 0; j < resolutionHorizontal - 1; j++)
            {
                int verticalOffset = (i * resolutionHorizontal);

                triangles[triangleIndex + 0] = verticalOffset + j;
                triangles[triangleIndex + 1] = verticalOffset + ((j + 1) % (resolutionHorizontal - 1));
                triangles[triangleIndex + 2] = verticalOffset + resolutionHorizontal + (j % (resolutionHorizontal - 1));

                triangles[triangleIndex + 3] = verticalOffset + ((j + 1) % (resolutionHorizontal - 1));
                triangles[triangleIndex + 4] = verticalOffset + resolutionHorizontal + ((j + 1) % (resolutionHorizontal - 1));
                triangles[triangleIndex + 5] = verticalOffset + resolutionHorizontal + ((j) % (resolutionHorizontal - 1));

                triangleIndex += 6;
            }
        }

        mesh.SetVertices(vertices);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

    }
}
