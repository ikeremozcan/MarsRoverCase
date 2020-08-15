using System;
using System.Collections.Generic;
using System.Linq;

namespace Case
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> plateauCoordinates = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                if (plateauCoordinates.Count < 2)
                {
                    throw new Exception("Plateau coordinates are not valid.");
                }

                //Break if get bad rover data
                while (true)
                {
                    var placementData = Console.ReadLine().Split(' ');
                    var movementData = Console.ReadLine();
                    if (placementData.Count() < 3 || string.IsNullOrEmpty(movementData))
                    {
                        break;
                    }
                    Console.WriteLine();
                    Rover rover = new Rover(Convert.ToInt32(placementData[0]), Convert.ToInt32(placementData[1]), placementData[2]);
                    rover.HandleMovement(plateauCoordinates[0], plateauCoordinates[1], movementData);
                    rover.InformStatus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
