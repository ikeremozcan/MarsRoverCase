using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    //Task.Run(()=>
                    //{
                    //    Rover rover = new Rover(Convert.ToInt32(placementData[0]), Convert.ToInt32(placementData[1]), placementData[2]);
                    //    rover.HandleMovement(plateauCoordinates[0], plateauCoordinates[1], movementData);
                    //    rover.InformStatus();
                    //});
                }

                //Rover rover = new Rover("N", 1, 2);
                //rover.HandleMovement(plateauCoordinates[1], "LMLMLMLMM", plateauCoordinates[0]);
                //rover.InformStatus();

                //Rover rover2 = new Rover("E", 3, 3);
                //rover2.HandleMovement(plateauCoordinates[1], "MMRMMRMRRM", plateauCoordinates[0]);
                //rover2.InformStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
