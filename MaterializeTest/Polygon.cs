using System;
using System.Collections.Generic;

namespace MaterializeTest
{
    public class Polygon
    {
        private readonly IList<Vertex> vertices;

        public Polygon(IList<Vertex> vertices)
        {
            this.vertices = vertices;
        }

        public List<Triangle> Triangulate()
        {
            List<int> sortedVertices = new List<int>();
            for (int i = 0; i < vertices.Count; i++)
            {
                sortedVertices.Add(i);
            }

            return TriangulateInternal(sortedVertices);
        }

        private List<Triangle> TriangulateInternal(List<int> indexes)
        {
            List<Triangle> result = new List<Triangle>();
            int count = indexes.Count;

            if (count == 3)
            {
                result.Add(new Triangle(indexes[0], indexes[1], indexes[2]));
            }
            else
            {
                int i = 0;
                while (!CheckEar(i, indexes))
                {
                    i++;
                    if (i > count) return result;//return if no ear found
                }
                result.Add(new Triangle(indexes[i % count], indexes[(i + 1) % count], indexes[(count + i - 1) % count]));
                indexes.RemoveAt(i);

                result.AddRange(TriangulateInternal(indexes));
            }

            return result;
        }

        private bool CheckEar(int i, List<int> indexes)
        {
            int count = indexes.Count;
            var indexA = indexes[i % count];
            var indexB = indexes[(i + 1) % count];
            var indexC = indexes[(count + i - 1) % count];

            //check if triangle ordered in counterclockwise manner
            if ((vertices[indexB] - vertices[indexA]) * (vertices[indexC] - vertices[indexA]) <= 0) return false;

            //check if all other points are outside this triangle
            foreach (var index in indexes)
            {
                if (index != indexA && index != indexB && index != indexC)
                {
                    if (PointInsideTriangle(indexA, indexB, indexC, index))
                        return false;
                }
            }

            return true;
        }

        private bool PointInsideTriangle(int indexA, int indexB, int indexC, int indexP)
        {
            var productA = (vertices[indexB] - vertices[indexA]) * (vertices[indexP] - vertices[indexA]);
            var productB = (vertices[indexC] - vertices[indexB]) * (vertices[indexP] - vertices[indexB]);
            var productC = (vertices[indexA] - vertices[indexC]) * (vertices[indexP] - vertices[indexC]);

            if (productA * productB * productC == 0)
            {
                //point on triangle side
                if (productA * productB >= 0 && productB * productC >= 0 && productC * productA >= 0)
                    return true;
            }
            if ((productA < 0 && productB < 0 && productC < 0) || (productA > 0 && productB > 0 && productC > 0))
            {
                //point inside triangle
                return true;
            }
            return false;
        }
    }
}
