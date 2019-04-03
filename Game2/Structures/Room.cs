﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
   
    class Room : GameObject, IMediator
    {
                                                                  //800 x 480 pixels er vores nuværende x og y - dette kan sikkert gøres mere scalable
        private int unit = 32;                                    //Den fælles sidelænge på det wall-billede vi bruger!
        private int unitsAvailableX;                              //Længden af skærmen - bliver delt i 32 i Room();
        private int unitsAvailableY;                              //Højden af skærmen - bliver delt i 32 i Room();
        private int unitPosX;                                     //Holder styr på hvor den næste wall sættes på x-aksen
        private int unitPosY;                                     //Holder styr på hvor den næste wall sættes på y-aksen
        private int prevUnitPosX;                                 //Holder styr på hvor den sidste wall blev sat på x-aksen  - Denne bliver ikke brugt pt.
        private int prevUnitPosY;                                 //Holder styr på hvor den sidste wall blev sat på y-aksen  - Denne bliver ikke brugt pt.
        private int width;                                        //Resolution x-akse
        private int height;                                       //Resolution y-akse
        private Random random = new Random();
       

        
        


        public Room(int width, int height)
        {
           
            this.width = width;
            this.height = height;
            this.unitsAvailableX = width / this.unit;
            this.unitsAvailableY = height / this.unit;
            
        }

        public void addToAllObjects()
        {

            layFloor();
            populateRoom();
        }

        public override void Load()
        {
            
            
        }

        public void layFloor()
        {
            unitPosX = 0; 
            unitPosY = 0;

            for (int i = 0; i < width; i+=unit)
            {
                for (int j = 0; j < height; j+=unit)
                {
                    mediator.AllObjects.Add(new Tiles(i, j, random.Next(3)+1));
                }
            }
 
        }

        public void populateRoom()
        {
            
           

            Random random = new Random();

            int wallSpace = random.Next(1,23);
            int doorDifference = random.Next(1, 23);
            Debug.WriteLine("Wallspace" + wallSpace);

            for (int i = 0; i < unitsAvailableX; i++)
            {
                

                
                    #region MyRegion

                    /*
                    * Første wall bliver lavet på unitPosX(0), unitPosY(0).
                    * prevUnitPosX bliver til unitPosX
                    * unitPosX bliver tilagt en unit(32)
                    * Næste Wall bliver lavet på unitPosX(32), unitPosY(0)
                    * ....
                    * Dette sker indtil i < unitAvailableX
                    *
                    * Når mans sætter et object til at "spawne" uden for et gyldigt x eller y, sætter den x / y til 0.
                    * Den anden wall der bliver sat i  dette loop bliver sat på det samme X-koordinat, men med et Y-koordinat
                    * der er skærmens højre - unit (32 - Dette gør at billedet går lige til kanten).
                    */

                    #endregion

                    mediator.AllObjects.Add(new Wall(unitPosX, 0));
                    mediator.AllObjects.Add(new Wall(unitPosX, height - unit));
                    
                
                if (i == wallSpace) 
                {
                    mediator.AllObjects.Add(new Door(unitPosX, 0));
                    
                }

                if (i == doorDifference)
                {
                    mediator.AllObjects.Add(new Door(unitPosX, height - unit));
                    GameObject lastDoor = mediator.AllObjects[mediator.AllObjects.Count - 1];
            
                    
                }

                prevUnitPosX = unitPosX;
                unitPosX = unitPosX + unit;
            }
          
            for (int i = 0; i < unitsAvailableY; i++)
            {

                mediator.AllObjects.Add(new Wall(0,unitPosY));
                mediator.AllObjects.Add(new Wall(width-unit, unitPosY));

                prevUnitPosY = unitPosY;
                unitPosY = unitPosY+unit;
               
            }
        }
        
        
    }
}
