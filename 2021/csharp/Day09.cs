namespace AdventOfCode;
class Day09 : Day{
    public override void Part1(List<string> terrain){
        var map = MapTerrain(terrain);
        PrintMap(map);

        System.Console.WriteLine($"Day 9-1: WIP");
    }
    public override void Part2(List<string> terrain){
        System.Console.WriteLine($"Day 9-2: WIP");
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
    static void PrintMap(int[,] map){
        //Print current map for testing purposes
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++){
                System.Console.Write(map[x, y]);
            }
            System.Console.WriteLine();
        }
    }
}