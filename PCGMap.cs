namespace PCG;

public class PCGMap
{
    private readonly Random _seededRandom;

    private readonly RoomNode _rootNode;
    private readonly int _roomCount;


    private const int MaxAdjacentRooms = 3;

    private int _numNodes = 0;


    private Dictionary<(int, int), RoomNode> _map = [];


    private static readonly (int x, int y)[] _directions =
    [
        (0,1),
        (1,0),
        (0,-1),
        (-1,0)
    ];



    public PCGMap(Random seededRandom)
    {
        _seededRandom = seededRandom;


        _rootNode = new("Root Node");
        _map.Add((0, 0), _rootNode);


        _roomCount = _seededRandom.Next(12, 16);
        Console.WriteLine($"Seed room count: {_roomCount}");


        GenerateMap();
    }





    private void GenerateMap()
    {

        Queue<RoomNode> roomsToPopulate = new();
        roomsToPopulate.Enqueue(_rootNode);

        while (roomsToPopulate.Count > 0)
        {
            if (_numNodes >= _roomCount) break;

            RoomNode currentRoomNode = roomsToPopulate.Dequeue();

            float currentAdjacentProbability = 1f - ((float)currentRoomNode.Layer / _maxLayers);


            int adjacentRoomCount = GenerateAdjacentRoomOdds(currentAdjacentProbability);


            for (int i = 0; i < adjacentRoomCount; i++)
            {
                var newNode = GenerateNode(currentRoomNode);
                _numNodes++;

                roomsToPopulate.Enqueue(newNode);
            }

        }


    }

    private int GenerateAdjacentRoomOdds(float probability)
    {
        int totalRooms = 0;

        for (int i = 0; i < MaxAdjacentRooms; i++)
        {
            var roll = _seededRandom.NextDouble();

            if (roll < probability)
            {
                totalRooms++;
            }
        }

        return totalRooms;
    }


    private RoomNode GenerateNode(RoomNode currentNode)
    {

        var availableSpots = new List<int>();

        foreach (var node in currentNode.AdjacentRooms)
        {
            if (node.Value == null) availableSpots.Add(node.Key);
        }

        var rolledDirection = availableSpots[_seededRandom.Next(0, availableSpots.Count)];

        RoomNode newNode = new($"Room {_numNodes + 1}");

        var (x, y) = _directions[rolledDirection];

        return newNode;
    }



    public void PrintMap() => PrintNode(_rootNode);



    private static void PrintNode(RoomNode node)
    {
        Console.WriteLine(node.RoomName);

        foreach (var room in node.AdjacentRooms) PrintNode(room);
    }

}
