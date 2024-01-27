using UnityEngine;

namespace WRA.Procedural.Arrow
{
    public class SimpleProceduralArrow : ProceduralLine
    {
        [SerializeField] private float arrrowHeadLenght = 0.1f;
        [SerializeField] private float arrrowHeadWidth = 0.1f;
    
        private float lastArrrowHeadLenght = 0;
        private float lastArrrowHeadWidth = 0;
    
        protected override bool ShouldUpdate()
        {
            if (base.ShouldUpdate())
                return true;
            if (lastArrrowHeadLenght == arrrowHeadLenght && lastArrrowHeadWidth == arrrowHeadWidth)
                return false;
            lastArrrowHeadLenght = arrrowHeadLenght;
            lastArrrowHeadWidth = arrrowHeadWidth;
            GenerateObject();
            return true;
        }
    
        protected override void GenerateObject()
        {
            meshFilter.mesh = GenereteArrow();
        }
    
        protected Mesh GenereteArrow()
        {
            var line = MeshFactory.GenereteLine(lenght, lineWidth);
            var triangle = MeshFactory.GenerateTriangle(new Vector3[]
            {
                new Vector3(lenght, -arrrowHeadWidth / 2, 0),
                new Vector3(lenght + arrrowHeadLenght, 0, 0),
                new Vector3(lenght, arrrowHeadWidth / 2, 0)
            });
            var mesh = new Mesh();
            mesh = MeshFactory.MeshCombine(line, triangle);
            mesh.name = "ProceduralArrow";
            return mesh;
        }
    }
}
