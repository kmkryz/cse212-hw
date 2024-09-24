/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;


public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        // Convert the dictionary to a list of KeyValuePair and sort it by points in descending order
        var topPlayers = players.ToList();
        topPlayers.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        // Display the top 10 players
        Console.WriteLine("Top 10 Players with the Highest Total Points:");
        Console.WriteLine("Rank\tPlayer ID\tTotal Points");
        for (int i = 0; i < Math.Min(10, topPlayers.Count); i++)
        {
            Console.WriteLine($"{i + 1}\t{topPlayers[i].Key}\t{topPlayers[i].Value}");
        }
    }
}