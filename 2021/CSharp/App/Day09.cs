namespace AdventOfCode;
public class Day09 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> terrain = new List<string>(file);

        var map = MapTerrain(terrain);
        PrintMap(map);

        int totalRisk = 0;

        // for (int x = 0; x < map.GetLength(0); x++){
        //     for (int y = 0; y < map.GetLength(1); y++){
        //         List<int> coordinates = new List<int>();
        //         coordinates.Add(x); coordinates.Add(y);
        //         Boolean isLowPoint = IsLowPoint(coordinates, map);
        //         if (isLowPoint == true) {totalRisk += map[x,y]+1;}                    
        //     }
        // }
        
        System.Console.WriteLine($"Day 9-1: {totalRisk}");
        return totalRisk;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> terrain = new List<string>(file);
        
        System.Console.WriteLine($"Day 9-2: WIP");
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
    static Boolean IsLowPoint(List<int> coordinates, int[,] map){
        List<List<int>> adjacentLocations = GetAdjacentLocations(coordinates);
        int lowestAdjacentValue = 10;

        System.Console.WriteLine(coordinates[0] + "," + coordinates[1]);
        foreach (List<int> location in adjacentLocations){
            int x = location[0], y = location[1];
            System.Console.Write($"{x},{y}={map[x,y]}; ");
        } System.Console.WriteLine();

        Boolean isLowPoint = false;
        return isLowPoint;
    }
    static List<List<int>> GetAdjacentLocations(List<int> coordinates){
        int x = coordinates[0], y = coordinates[1];
        List<List<int>> adjacentLocations = new List<List<int>>();

        //Above:

        //To check if index is out of bounds of the array (needs editing):
        // if (tileX < arr.GetLength(0) && tileY < arr.GetLength(1))
        // { do stuff }        

        return adjacentLocations;        
    }
    static void PrintMap(int[,] map){
        //Print current map for testing purposes
        for (int y = 0; y < map.GetLength(0); y++){
            for (int x = 0; x < map.GetLength(1); x++){
                //System.Console.Write(map[x, y]);
                System.Console.Write(y + "," + x + " ");
            }
            System.Console.WriteLine();
        }
    }
}