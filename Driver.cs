namespace PCG;



public class Driver
{


    public static void Main(string[] args)
    {
        Console.WriteLine("Generating PCG Map...");

        Random seedRandom = new();
        var seed = seedRandom.Next();
        //var seed = 1295421211;

        Console.WriteLine($"Seed at use: {seed}");

        Random seededRandom = new(seed);

        PCGMap map = new(seededRandom);



        map.PrintMap();
    }

}
