namespace AdventOfCode
{
  abstract class Day
  {
    public virtual void Main(string filepath)
    ///Main can be overridden on days when ReadAllLines isn't
    /// the best way to build the input list
    {
      string[] file = File.ReadAllLines(filepath);
      List<string> input = new List<string>(file);

      Part1(input);
      Part2(input);
    }

    //Ensure that all days have a valid Part1() and Part2()
    // so Main() can call them both and pass the input list
    public abstract void Part1(List<string> input);
    public abstract void Part2(List<string> input);

    public string CheckAnswer(int result, int expected)
    ///To be used after a puzzle is solved and the correct answer is
    /// known to see at a glance if any future changes break anything
    {
      string outcome;

      if (result == expected)
        {outcome = "PASS";}
      else{outcome = $"FAIL (Expected {expected})";}

      return outcome;
    }
  }
}