using MaterializeTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TriangulateTriangle()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(0, 1));

            Polygon poly = new Polygon(vertices);
            var triangles = poly.Triangulate();

            Assert.AreEqual(1, triangles.Count);
            Assert.AreEqual(new Triangle(0, 1, 2), triangles[0]);
        }

        [TestMethod]
        public void TriangulateSquare()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(1, 1));
            vertices.Add(new Vertex(0, 1));

            Polygon poly = new Polygon(vertices);
            var triangles = poly.Triangulate();

            Assert.AreEqual(2, triangles.Count);
            Assert.AreEqual(new Triangle(0, 1, 3), triangles[0]);
            Assert.AreEqual(new Triangle(1, 2, 3), triangles[1]);
        }

        [TestMethod]
        public void TriangulateConcaveSquare()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(0.3, 0.3));
            vertices.Add(new Vertex(0, 1));

            Polygon poly = new Polygon(vertices);
            var triangles = poly.Triangulate();

            Assert.AreEqual(2, triangles.Count);
            Assert.AreEqual(new Triangle(1, 2, 0), triangles[0]);
            Assert.AreEqual(new Triangle(0, 2, 3), triangles[1]);
        }

        [TestMethod]
        public void TriangulateFourPointTriangle()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(0.5, 0.5));
            vertices.Add(new Vertex(0, 1));

            Polygon poly = new Polygon(vertices);
            var triangles = poly.Triangulate();

            Assert.AreEqual(2, triangles.Count);
            Assert.AreEqual(new Triangle(1, 2, 0), triangles[0]);
            Assert.AreEqual(new Triangle(0, 2, 3), triangles[1]);
        }

        [TestMethod]
        public void TriangulateFivePointTriangle()
        {
            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(new Vertex(0, 0));
            vertices.Add(new Vertex(1, 0));
            vertices.Add(new Vertex(0.75, 0.25));
            vertices.Add(new Vertex(0.25, 0.75));
            vertices.Add(new Vertex(0, 1));

            Polygon poly = new Polygon(vertices);
            var triangles = poly.Triangulate();

            Assert.AreEqual(3, triangles.Count);
            Assert.AreEqual(new Triangle(1, 2, 0), triangles[0]);
            Assert.AreEqual(new Triangle(2, 3, 0), triangles[1]);
            Assert.AreEqual(new Triangle(0, 3, 4), triangles[2]);
        }
    }
}
