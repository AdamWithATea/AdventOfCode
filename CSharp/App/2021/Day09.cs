using AdventOfCode;

namespace AOC2021;
public class Day09 : Day{
    public override long Part1(string filepath){
        List<string> terrain = ConvertLinesToStringList(filepath);

        var map = MapTerrain(terrain);
        List<List<int>> lowPoints = LowPoints(map);
        int totalRisk = CalculateTotalRisk(lowPoints);
        return totalRisk;
    }
    public override long Part2(string filepath){
        //List<string> terrain = ConvertLinesToStringList(filepath);

        //var map = MapTerrain(terrain);
        //List<List<int>> lowPoints = LowPoints(map);
        return 0;
    }
    static int[,] MapTerrain(List<string> terrain){
        int[,] map = new int[terrain.Count,terrain[0].Length];
        int lineNumber = 0;
        foreach (string line in terrain){
            for (int index = 0; index < terrain[0].Length; index++){
                map[lineNumber,index] = Convert.ToInt32(line[index].ToString());
            }
            lineNumber++;
        }
        return map;
    }
    static List<List<int>> LowPoints(int[,] map){
        List<List<int>> lowPoints = new();

        for (int y = 0; y < map.GetLength(0); y++){
            for (int x = 0; x < map.GetLength(1); x++){
                List<int> adjacentHeights = new();
                if (y > 0) { adjacentHeights.Add(map[y-1,x]); }
                if (y < map.GetLength(0)-1) { adjacentHeights.Add(map[y+1,x]); }
                if (x > 0) { adjacentHeights.Add(map[y,x-1]); }
                if (x < map.GetLength(1)-1) { adjacentHeights.Add(map[y,x+1]); }

                bool isLowPoint = true;
                foreach (int height in adjacentHeights){
                    if (height <= map[y,x]) { isLowPoint = false; }
                }
                if (isLowPoint){
                    List<int> locationDetails = new() { y,x,map[y,x]};
                    lowPoints.Add(locationDetails);
                }
                
            }
        }
        return lowPoints;
    }
    static int CalculateTotalRisk(List<List<int>> lowPoints){
        int totalRisk = 0;
        foreach (List<int> location in lowPoints){
            int riskLevel = location[2] + 1;
            totalRisk += riskLevel;
        }
        return totalRisk;
    }
    // static void PrintMap(int[,] map){
    //     //Print current map for testing purposes
    //     for (int y = 0; y < map.GetLength(0); y++){
    //         for (int x = 0; x < map.GetLength(1); x++){
    //             Console.Write(map[y, x]);

    //             //Print array index of each value instead:
    //             //System.Console.Write(y + "," + x + " ");
    //             //If each index/co-ordinate is formatted y,x the array looks like this:
    //             // 0,0 0,1 0,2 0,3
    //             // 1,0 1,1 1,2 1,3
    //             // 2,0 2,1 2,2 2,3
    //             // 3,0 3,1 3,2 3,3
    //         }
    //         Console.WriteLine();
    //     }
    // }
}