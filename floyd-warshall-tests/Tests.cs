using floyd_warshall;
using NUnit.Framework;

namespace floyd_warshall_tests
{
    public class Tests
    {
        int[,] graph;
        const int verticesCount = 5;
        FloydWarshall floydWarshall;

        [SetUp]
        public void Setup()
        {            
            graph = new int[verticesCount, verticesCount] {
                { 0,                 5,                 FloydWarshall.INF,  7,                  8 },
                { FloydWarshall.INF, 0,                 1,                  FloydWarshall.INF,  6 },
                { FloydWarshall.INF, FloydWarshall.INF, 0,                  4,                  5 },
                { FloydWarshall.INF, FloydWarshall.INF, FloydWarshall.INF,  0,                  4 },
                { FloydWarshall.INF, FloydWarshall.INF, FloydWarshall.INF,  FloydWarshall.INF,  0 },
            };

            floydWarshall = new FloydWarshall(graph, verticesCount);
        }

        [Test]
        public void TestShortestPathOfAllPairOfVertices()
        {
            int[,] correctResultForCase = new int[,] {
                { 0, 5, 6, 7, 8 },
                { FloydWarshall.INF, 0, 1, 5, 6 },
                { FloydWarshall.INF, FloydWarshall.INF, 0, 4, 5 },
                { FloydWarshall.INF, FloydWarshall.INF, FloydWarshall.INF, 0, 4 },
                { FloydWarshall.INF, FloydWarshall.INF, FloydWarshall.INF, FloydWarshall.INF, 0 },
            };
            int[,] shortestPath = floydWarshall.CalculateDistance();
            Assert.AreEqual(shortestPath, correctResultForCase);
        }
    }
}
