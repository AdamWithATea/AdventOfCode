namespace AdventOfCode;
public class Day05 : Day{
    public override Int64 Part1(string filepath){
        List<string> ventLocations = ConvertLinesToStringList(filepath);
        int[,] map = CreateMap(ventLocations);

        foreach (string ventLocation in ventLocations)
            {UpdateMap(map, ventLocation, false);}
        //PrintMap(map);
        int overlaps = CountOverlaps(map);
        return overlaps;
    }
    public override Int64 Part2(string filepath){
        List<string> ventLocations = ConvertLinesToStringList(filepath);
        int[,] map = CreateMap(ventLocations);

        foreach (string ventLocation in ventLocations)
            {UpdateMap(map, ventLocation, true);}
        //PrintMap(map);
        int overlaps = CountOverlaps(map);
        return overlaps;
    }
    static int[,] CreateMap(List<string> ventLocations){
        List<int> xValues = new List<int>(), yValues = new List<int>();
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
        int[,] map = new int[yValues[xValues.Count - 1] + 1, xValues[xValues.Count - 1] + 1];

        //Fill map with 0s ready for future increments and comparisons
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++)
                {map[x, y] = 0;}
        }
        return map;
    }
    static int[,] UpdateMap(int[,] map, string ventLocation, bool includeDiagonals){
        List<List<int>> coordinates = ConvertToCoords(ventLocation);
        int[] start = new int[2], current = new int[2], end = new int[2];
        start[0] = coordinates[0][0]; start[1] = coordinates[0][1];
        end[0] = coordinates[1][0]; end[1] = coordinates[1][1];
        string lineType = "";

        if (start[0] == end[0] && start[1] == end[1]) {lineType = "dot";}
        else if ((start[0] == end[0] && start[1] != end[1]) | (start[0] != end[0] && start[1] == end[1]))
            {lineType = "straight";}
        else {lineType = "diagonal";}

        current = start;
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
        List<int> start = new List<int>(), end = new List<int>();
        List<List<int>> coordinates = new List<List<int>>();

        string[] splitLine = ventLocation.Split(' ');
        foreach (string value in splitLine[0].Split(','))
            {start.Add(Convert.ToInt32(value));}
        foreach (string value in splitLine[2].Split(','))
            {end.Add(Convert.ToInt32(value));}

        coordinates.Add(start);
        coordinates.Add(end);
        return coordinates;
    }
    private int CountOverlaps(int[,] map){
        int overlaps = 0;
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++){
                if (map[x, y] > 1) {overlaps++;}
            }
        }
        return overlaps;
    }
    static void PrintMap(int[,] map){
        //Print current map in the style the website uses for testing purposes
        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++){
                if (map[x, y] == 0) {System.Console.Write('.');}
                else {System.Console.Write(map[x, y]);}
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
}