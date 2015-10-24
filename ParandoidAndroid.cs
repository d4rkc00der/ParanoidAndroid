using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

class Player
{
    
    static void Trace(String msg,Object o)
    {
        Console.Error.WriteLine("{0} : {1}",msg,o.ToString());
    }
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        Hashtable elevators = new Hashtable();
        List<int> blockedFloors = new List<int>();
        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
            int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
            elevators.Add(elevatorFloor,elevatorPos);
        }
       
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            int elevatorPos=0;
            #region DebugInfo
            //Trace("nbFloors",nbFloors);
            //Trace("width",width);
            //Trace("nbRounds",nbRounds);
            //Trace("exitFloor",exitFloor);
            //Trace("exitPos",exitPos);
            //Trace("nbTotalClones",nbTotalClones);
            //Trace("nbAdditionalElevators",nbAdditionalElevators);
            //Trace("nbElevators",nbElevators);
            //Trace("cloneFloor",cloneFloor);
            //Trace("clonePos",clonePos);
            //Trace("direction",direction);
            #endregion 
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            
            
        
              
            if((clonePos<elevatorPos)&&(direction=="LEFT"))
               {
                if(!blockedFloors.Contains(cloneFloor))
                {
                 Console.WriteLine("BLOCK");
                 blockedFloors.Add(cloneFloor);
                }
              }
            if(cloneFloor==exitFloor)
            {
                if(exitPos==0)
                {
                    if((clonePos==width-1)&&(direction=="RIGHT"))
                    {
                        Console.WriteLine("BLOCK");
                    }
                    else
                    {
                        Console.WriteLine("WAIT"); // action: WAIT or BLOCK
                    }
                }
                if(exitPos==width-1)
                {  
                  if((clonePos==1)&&(direction=="LEFT"))
                    {
                        Console.WriteLine("BLOCK");
                    }
                    else
                    {
                        Console.WriteLine("WAIT"); // action: WAIT or BLOCK
                    }
                }
                if((exitPos!=0)&&(exitPos!=width-1))
                {
                    if(((clonePos==width-1)&&(direction=="RIGHT"))||((clonePos==1)&&(direction=="LEFT")))
                    {
                        Console.WriteLine("BLOCK");
                    }
                    else
                    Console.WriteLine("WAIT"); // action: WAIT or BLOCK
                }
            }
            else
            {
             if(((clonePos==width-1)&&(direction=="RIGHT"))||((clonePos==1)&&(direction=="LEFT")))
             {
                 Console.WriteLine("BLOCK");
             }
             else
                 Console.WriteLine("WAIT"); // action: WAIT or BLOCK
            }
            
            foreach(DictionaryEntry de in elevators)
            {
                if ((int)de.Key==cloneFloor)
                  elevatorPos=(int)de.Value;
                  Trace("elevatorPos",elevatorPos);
            }
            
            
            // Need to add Elevators in HashTable
            // and check if clone position is bigger
            //  than elevator position on same floor
            // and direction is right  or if clone position
            // is smaller then elevator position on same floor
            // and direction is left - block that clone.
            // this case must work only if clone note at exit floor
        }
    }
}