using System;
/*
 * 
As a part of the route planner, the RouteExists method is used as a quick filter if the destination is reachable, before using more computationally intensive procedures for finding the optimal route.

The roads on the map are rasterized and produce a matrix of boolean values - true if the road is present or false if it is not. The roads in the matrix are connected only if the road is immediately left, right, below or above it.

Finish the RouteExists method so that it returns true if the destination is reachable or false if it is not. The fromRow and fromColumn parameters are the starting row and column in the mapMatrix. The toRow and toColumn are the destination row and column in the mapMatrix. The mapMatrix parameter is the above mentioned matrix produced from the map.

For example, for the given rasterized map, the code below should return true since the destination is reachable:



bool[,] mapMatrix = {
	{true, false, false},
	{true, true, false},
	{false, true, true}
};

RouteExists(0, 0, 2, 2, mapMatrix);
 * 
 */
public class RoutePlanner
{
    public static int[,] DIR = new int[4, 2] { { 1, 0 },{ -1, 0 }, { 0, 1 }, { 0, -1 } };
    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                      bool[,] mapMatrix)
    {
        int rowCnt = mapMatrix.GetLength(0);
        int colCnt = mapMatrix.GetLength(1);
        //0: unvisited, 1: visited, 2:reachable
        int[,] reachable = new int[rowCnt, colCnt];
        int fromRowIdx = normalizeBoundary(fromRow, rowCnt);
        int fromColIdx = normalizeBoundary(fromColumn, colCnt);
        int toRowIdx = normalizeBoundary(toRow, rowCnt);
        int toColIdx = normalizeBoundary(toColumn, colCnt);

        if (mapMatrix[fromRowIdx, fromColIdx])
            reachable[fromRowIdx, fromColIdx] = 3;
        else
            reachable[fromRowIdx, fromColIdx] = 1;

        for(int i=0;i<DIR.GetLength(0);i++)
          dfs(fromRowIdx,fromColIdx,fromRowIdx+DIR[i,0], fromColIdx+ DIR[i,1], toRowIdx, toColIdx, mapMatrix, reachable);

        return (reachable[toRowIdx, toColIdx] ==3);
    }
    
    public static void dfs(int preRowIdx, int preColIdx, int curRowIdx, int curColIdx, int toRowIdx, int toColIdx, bool[,] mapMatrix, int[,] reachable)
    {

        if (curColIdx < 0 || curRowIdx<0 || 
            curColIdx==mapMatrix.GetLength(1) || 
            curRowIdx==mapMatrix.GetLength(0))
            return;
        if (!mapMatrix[curRowIdx, curColIdx])
            return;
        if (((reachable[curRowIdx, curColIdx] >> 1) & 1) == 1)//visited
            return;
        if (((reachable[toRowIdx, toColIdx]>>1) & 1) ==1)//visited
            return;
        
        if (reachable[preRowIdx, preColIdx]==3)//visited and rechable
          reachable[curRowIdx, curColIdx] =3;

        for (int i = 0; i < DIR.GetLength(0); i++)
            dfs(curRowIdx, curColIdx, curRowIdx + DIR[i, 0], curColIdx+ DIR[i, 1], toRowIdx, toColIdx, mapMatrix, reachable);       
    }

    public static int normalizeBoundary(int index,int total)
    {
        if (index < 0) return 0;
        if (index >= total) return total;
        return index;
    }
    public static void Main(string[] args)
    {
        bool[,] mapMatrix = {
            {true, false, false},
            {true, true, false},
            {false, true, true}
        };

        Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
    }
}