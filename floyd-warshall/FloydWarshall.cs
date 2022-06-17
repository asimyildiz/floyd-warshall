using System;

namespace floyd_warshall
{
    /**
     * <summary>
     * Floyd Warshall's Algorithm
     * </summary>
     * <example>
     * About Floyd Warshall's Algorithm
     * 
     * The Floyd Warshall algorithm is used to calculate the binary shortest path of each node of a graph to all other nodes.
     * First of all, a proximity matrix is created according to the problem at hand. In this proximity matrix, the distances between nodes and neighboring nodes are kept.
     * In this matrix, the distance between a node and itself is 0, and the distance between nodes to which it is not directly connected is indicated by INF (infinity sign).
     * When calculating the distances between nodes that are not directly connected to each other using the Floyd Warshall algorithm, the shortest one is found among these values.
     * </example>
     */
    public class FloydWarshall
    {
        /// <summary>infinity value</summary>
        public static int INF = 9999;

        private readonly int[,] _distance;
        private readonly int _verticesCount;
        /**
         * <summary>
         * Floyd Warshall's algorithm implementation to find shortest paths in a weighted, directed graph
         * </summary>
         * <param name="graph">representation of the graph as a 2d multi-dimensional array</param>
         * <param name="verticesCount">number of vertices</param>
         */
        public FloydWarshall(int[,] graph, int verticesCount)
        {
            _verticesCount = verticesCount;

            _distance = new int[_verticesCount, _verticesCount];
            Array.Copy(graph, _distance, _verticesCount * _verticesCount);
        }

        /**
         * <summary>
         * Find the minimum distances (shortest paths) between all pair of vertices.
         * </summary>
         * <example>
         * All paths from one node to another node are calculated one by one.
         * On the newly created proximity matrix, the shortest path from one node to the other is replaced with the smallest calculated value, even if it is indirect.
         *
         * For example, let's look at the proximity matrix below
         *   D1 D2 D3 D4 D5
         * D1 0  5  -  7  8
         * D2 -  0  1  -  6
         * D3 -  -  0  4  5
         * D4 -  -  -  0  4
         * D5 -  -  -  -  0
         *
         * Let's take a look at the roads from D2 to D4;
         * D2-(6km)->D5-(4km)->D4 = 10km
         * D2-(5km)->D1-(7km)->D4 = 12km
         * D2-(1km)->D3-(4km)->D4 = 5km
         * D2-(6km)->D5-(5km)->D3-(4km)->D4 = 15km
         * D2-(5km)->D1-(8km)->D5-(4km)->D4 = 17km
         * .....
         * By doing all these checks in order to run this algorithm (D[2,3] + D[3,4] &lt; D[2,4]) check
         * updates the shortest path from D2 to D4 as 5 in the proximity matrix
         *
         * There are 3 loops in this algorithm.
         * The runtime of each loop is fixed O(n).
         * The running time of the whole algorithm is O(n^3) when called nested.
         *
         * Since a separate proximity matrix is ​​kept for the solution in this class, the memory cost when using this program is O(n^2 + n^2).
         * The solution provided by this class has O(n^2) memory cost as the fixed value can be ignored in O(2n^2)
         * </example>
         * <returns>returns calculated minimum distances between all pair of vertices</returns>
         */
        public int[,] CalculateDistance()
        {

            for (int k = 0; k < _verticesCount; ++k)
            {
                for (int i = 0; i < _verticesCount; ++i)
                {
                    for (int j = 0; j < _verticesCount; ++j)
                    {
                        if (_distance[i, k] + _distance[k, j] < _distance[i, j])
                        {
                            _distance[i, j] = _distance[i, k] + _distance[k, j];
                        }
                    }
                }
            }

            return _distance;
        }

        /**
         * <summary>
         * Prints out the current calculated distance matrix in a nice string representation
         * </summary> 
         */
        public void Print()
        {
            for (int i = 0; i < _verticesCount; ++i)
            {
                for (int j = 0; j < _verticesCount; ++j)
                {
                    if (_distance[i, j] == INF)
                    {
                        Console.Write("INF".PadLeft(7));
                    }
                    else
                    {
                        Console.Write(_distance[i, j].ToString().PadLeft(7));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new String('-', 7 * _verticesCount));
        }
    }
}
