namespace AdventOfCode;
abstract class Day{
    public virtual void Main(string filepath){
        ///Main can be overridden if ReadAllLines isn't appropriate, e.g comma-delimited inputs
        string[] file = File.ReadAllLines(filepath);
        List<string> input = new List<string>(file);
        Part1(input);
        Part2(input);
    }
    public string CheckAnswer(Int64 result, Int64 expected){
        //Can be used after a puzzle is solved and the correct answer is known in order to
        // easily confirm any future changes haven't broken anything
        string outcome;
        if (result == expected)
        { outcome = "PASS"; }
        else { outcome = $"FAIL (Expected {expected})"; }
        return outcome;
    }
    public string CheckAnswer(int result, int expected){
        //Same as the Int64 version above, but for 32-bit ints so CheckAnswer can be called
        // with either type and still work, with no conversion required in the calling method
        string outcome = CheckAnswer(Convert.ToInt64(result), Convert.ToInt64(expected));
        return outcome;
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call it:
    public abstract void Part1(List<string> input); 
    public abstract void Part2(List<string> input);
}