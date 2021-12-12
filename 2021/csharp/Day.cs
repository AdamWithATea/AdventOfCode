namespace AdventOfCode
{
  abstract class Day
  {
    ///Main can be overridden on days when ReadAllLines isn't
    /// the best way to build the input list
    public virtual void Main(string filepath){
      string[] file = File.ReadAllLines(filepath);
      List<string> input = new List<string>(file);
      
      Part1(input);
      Part2(input);
    }

    //Ensure that all days have a valid Part1() and Part2()
    // so Main() can call them both and pass the input list
    public abstract void Part1(List<string> input);
    public abstract void Part2(List<string> input);

    
    ///To be used after a puzzle is solved and the correct answer is
    /// known to see at a glance if any future changes break anything
    public string CheckAnswer(Int64 result, Int64 expected){
      string outcome;

      if (result == expected)
        {outcome = "PASS";}
      else{outcome = $"FAIL (Expected {expected})";}

      return outcome;
    }

    ///Same as the Int64 version above, but for 32-bit ints so that either
    /// type can be passed to CheckAnswer and still be processed correctly
    public string CheckAnswer(int result, int expected){
      string outcome = CheckAnswer(Convert.ToInt64(result), Convert.ToInt64(expected));
      return outcome;
    }
  }
}