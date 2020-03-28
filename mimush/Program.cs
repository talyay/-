using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mimush
{
    using System;

    class GFG
    {
        
        static int V = 9;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            //  הכנסת ערך מינימלי 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // פונקציה שמדפיסה
        // את מערך של המרחק  
        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex	 Distance "
                        + "from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }
        // פונקציה שמייצגת את האלגוריתם של דיקסטרא
        // אלגוריתם של מקור יחיד ודרך קצרה ביותר עבור גרף שמיוצג בעזר מטריצת סמיכויות 
        void dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // המערך שנוצר. dist[i]  
                                     // יחזיק את הדרך הקצרה ביותר  
                                     // בין  src ל i 

            // sptSet[i] יהיה true אם vertex 
            // i נמצא בדרך הקצרה ביותר 
            // בעץ או בדרך הקצרה ביותר מ
            // src ל i היא סופית 
            bool[] sptSet = new bool[V];

            //כול המרחקים מוגדרים כאינסופיים
            //  sptSet[i] מוגדר FALSE 
            
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // מרחק של מקור מעצמו תמיד אפס
            dist[src] = 0;

            // מוצא את הדרך הקצרה ביותר לכולם 
            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;
                 for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
                }
            }

            // מדפיס את מערך המרחק הבנוי 
            printSolution(dist, V);
        }

        public static void Main()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            GFG t = new GFG();
            t.dijkstra(graph, 0);
        }
    }
}



    
