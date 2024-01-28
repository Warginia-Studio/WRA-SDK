using Unity.Burst;
using UnityEngine;

namespace WRA.Procedural
{
    [BurstCompile(CompileSynchronously = true)]
    public static class MeshFactory
    {
        public static Mesh GenereteLine(float lenght, float height)
        {
            Mesh mesh = new Mesh();
        
            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];
        
            vertices[0] = new Vector3(0, -height / 2, 0);
            vertices[1] = new Vector3(lenght, -height / 2, 0);
            vertices[2] = new Vector3(0, height / 2, 0);
            vertices[3] = new Vector3(lenght, height / 2, 0);
        
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(lenght, 0);
            uv[2] = new Vector2(0, height);
            uv[3] = new Vector2(lenght, height);
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            triangles[3] = 2;
            triangles[4] = 3;
            triangles[5] = 1;
        
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralLine";
        
            return mesh;
        }

        public static Mesh GenerateTriangle(Vector3[] veritcies)
        {
            Mesh mesh = new Mesh();
        
            Vector2[] uv = new Vector2[3];
            int[] triangles = new int[3];
        
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            mesh.vertices = veritcies;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralTriangle";
        
            return mesh;
        }
    
        public static Mesh MeshCombine(Mesh mesh1, Mesh mesh2)
        {
            CombineInstance[] combine = new CombineInstance[2];
            combine[0].mesh = mesh1;
            combine[0].transform = Matrix4x4.identity;
            combine[1].mesh = mesh2;
            combine[1].transform = Matrix4x4.identity;
        
            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine);
            return mesh;
        }
    }
}
