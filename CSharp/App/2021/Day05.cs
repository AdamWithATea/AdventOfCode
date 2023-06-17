using AdventOfCode;

namespace AOC2021;
public class Day05 : Day{
    public override long Part1(string filepath){
        List<string> ventLocations = Inputs.ListLines(filepath);
        int[,] map = CreateMap(ventLocations);

        foreach (string ventLocation in ventLocations)
            {UpdateMap(map, ventLocation, false);}
        return CountOverlaps(map);        
    }
    public override long Part2(string filepath){
        List<string> ventLocations = Inputs.ListLines(filepath);
        int[,] map = CreateMap(ventLocations);

        foreach (string ventLocation in ventLocations)
            {UpdateMap(map, ventLocation, true);}
        return CountOverlaps(map);        
    }
    static int[,] CreateMap(List<string> ventLocations){
        List<int> xValues = new(), yValues = new();
        foreach (string location in ventLocations){
            List<List<int>> coords = ConvertToCoords(location);
            xValues.Add(coords[0][0]);
            xValues.Add(coords[1][0]);
            yValues.Add(coords[0][1]);
            yValues.Add(coords[1][1]);
        }
        xValues.Sort();
        yValues.Sort();

        //Create map as an array with the dimensions of the highest value in the
        // numerically-sorted lists of x and y coordinates
        int[,] map = new int[yValues[xValues.Count - 1] + 1, xValues[^1] + 1];

        //Fill map with 0s ready for future increments and comparisons
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++)
                {map[x, y] = 0;}
        }
        return map;
    }
    static int[,] UpdateMap(int[,] map, string ventLocation, bool includeDiagonals){
        List<List<int>> coordinates = ConvertToCoords(ventLocation);
        int[] start = new int[2], end = new int[2];
        start[0] = coordinates[0][0]; start[1] = coordinates[0][1];
        end[0] = coordinates[1][0]; end[1] = coordinates[1][1];
        string lineType;
        
        if (start[0] == end[0] && start[1] == end[1]) {lineType = "dot";}
        else if ((start[0] == end[0] && start[1] != end[1]) | (start[0] != end[0] && start[1] == end[1]))
            {lineType = "straight";}
        else {lineType = "diagonal";}

        int[] current = start;
        if (lineType == "straight" | includeDiagonals == true){
            map[current[1], current[0]]++;
            while (current[0] != end[0] | current[1] != end[1]){
                if (current[0] != end[0]){
                    if (end[0] > current[0]) {current[0]++;}
                    else if (end[0] < current[0]) {current[0]--;}
                }
                if (current[1] != end[1]){
                    if (end[1] > current[1]) {current[1]++;}
                    else if (end[1] < current[1]) {current[1]--;}
                }
                map[current[1], current[0]]++;
            }
        }
        return map;
    }
    static List<List<int>> ConvertToCoords(string ventLocation){
        List<int> start = new(), end = new();
        List<List<int>> coordinates = new();

        string[] splitLine = ventLocation.Split(' ');
        foreach (string value in splitLine[0].Split(','))
            {start.Add(Convert.ToInt32(value));}
        foreach (string value in splitLine[2].Split(','))
            {end.Add(Convert.ToInt32(value));}

        coordinates.Add(start);
        coordinates.Add(end);
        return coordinates;
    }
    private static int CountOverlaps(int[,] map){
        int overlaps = 0;
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++){
                if (map[x, y] > 1) {overlaps++;}
            }
        }
        return overlaps;
    }
}