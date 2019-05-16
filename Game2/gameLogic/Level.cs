﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    class Level : IMediator
    {
        public Mediator mediator { get; set; }
        private int level = 0;
        private int multiplier = 0;
        private List<int[,]> levelList = new List<int[,]>();

        public int Multiplier
        {
            get => multiplier;
            set => multiplier = value;
        }

        public List<int[,]> LevelList => levelList;

        public Level()
        {
            initLevels();
        }

        public void initLevels()
        {
            /*
             * 0 = Ingenting
             * 1 = wall
             * 2 = lavatile
             * 3 = crossbow
             * 4 = movementspeed boost
             * 5 = attack speed boost
             * 6 = Hp boost
             * 7 = Creep
             * 8 = FrozenBow
             * 9 = SimpleGun
             * 10 = Wand
             * 11 = BossGhost
             */

            int[,] FiendLevel  = new int[,]
            {
                {1, 0, 0, 12, 0, 12, 0, 0, 0, 0, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1},
                {1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}
            };

            int[,] lavaLoot = new int[,]
            {
                {1,1,1,1,1,0,0,0,1,1,1,1,1},
                {2,0,2,0,1,0,0,0,1,0,2,5,2},
                {2,0,2,2,2,0,0,0,2,2,2,0,2},
                {3,7,0,0,0,8,9,10,0,0,0,0,4},
                {2,0,2,2,2,0,0,0,2,2,2,0,2},
                {2,0,2,0,1,0,0,0,1,0,2,6,2},
                {1,1,1,1,1,0,0,0,1,1,1,1,1}
            };

            int[,] lavaLootBoost = new int[,]
            {
                {2,2,2,0,0,0,9,0,0,0,2,2,2},
                {2,2,2,2,0,12,0,0,0,2,2,2,2},
                {2,2,2,2,2,0,5,0,2,2,2,2,2},
                {2,6,6,0,0,0,0,0,0,0,6,6,2},
                {2,2,2,2,2,0,4,0,2,2,2,2,2},
                {2,2,2,2,0,0,0,0,0,2,2,2,2},
                {2,2,2,0,0,0,0,0,0,0,2,2,2}
            };

            int[,] healthBoostFrostBow = new int[,]
            {
                {1,1,1,1,1,1,0,1,1,1,1,1,1},
                {1,2,2,2,2,2,0,2,2,2,2,2,1},
                {1,2,2,2,2,0,0,0,2,2,0,6,1},
                {1,2,8,0,0,0,0,0,0,0,0,6,1},
                {1,2,2,2,2,0,0,0,2,2,0,6,1},
                {1,2,2,2,2,2,0,2,2,2,2,2,1},
                {1,1,1,1,1,1,0,1,1,1,1,1,1}
            };

            int[,] creepSwarm = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,12,0,7,0,0,0,0,0,7,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,7,0,0,0,0,7,0,0,0,0,7,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,7,0,0,0,0,0,7,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0}
            };

            int[,] lavaWandBoosters = new int[,]
            {
                {4,0,0,0,0,0,0,0,0,0,0,0,5},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,2,2,2,2,2,2,2,2,2,0,0},
                {0,0,0,0,0,0,10,0,0,0,0,0,0},
                {0,0,1,1,1,1,1,1,1,1,1,0,0},
                {0,0,0,0,0,0,6,0,0,0,0,0,0},
                {7,0,0,0,0,0,0,0,0,0,0,0,7}
            };
           
            int[,] lavaLake = new int[,]
            {
                {2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,12,0,0,0,0,0,0,0,0,0,12,2},
                {2,0,2,2,2,2,2,2,2,2,2,0,2},
                {2,0,2,2,2,6,6,6,2,2,2,0,2},
                {2,0,2,2,2,2,2,2,2,2,2,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2}
            };

            int[,] bossLevel = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,11},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0}
            };

            int[,] ScaryGhostLevel = new int[,]
            {
                {0,2,0,0,0,2,0,0,0,2,0,0,11},
                {0,2,0,0,0,2,0,0,0,2,0,0,0},
                {0,2,0,0,0,2,0,0,0,2,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,2,0,0,0,2,0},
                {0,0,0,2,0,0,0,2,0,0,0,2,0},
                {0,0,0,2,0,0,0,2,0,0,0,2,0}
            };

            int[,] mazeLevel = new int[,]
            {
                {1,1,1,1,1,0,0,0,0,0,0,1,1},
                {0,0,0,1,0,0,1,1,1,1,0,1,7},
                {0,1,0,1,10,0,1,1,7,0,0,1,0},
                {0,1,0,1,1,1,1,1,1,1,0,1,0},
                {0,1,0,0,0,0,0,0,0,0,0,1,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,1,1,0,1,1,1,1,1,0}
            };

            int[,] creepyCrawly = new int[,]
            {
                {0,0,0,0,0,0,6,0,0,0,0,0,0},
                {0,0,1,1,1,1,1,1,1,1,1,0,0},
                {0,0,0,7,0,7,0,7,0,7,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,7,0,7,0,7,0,7,0,7,0,7,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,6,0,0,0,0,6,0,0,0,0,6,0}
            };
            levelList.Add(FiendLevel);
            levelList.Add(ScaryGhostLevel);
            levelList.Add(mazeLevel);
            levelList.Add(lavaLoot);
            levelList.Add(healthBoostFrostBow);
            levelList.Add(creepSwarm);
            levelList.Add(lavaWandBoosters);
            levelList.Add(lavaLootBoost);
            levelList.Add(lavaLake);
            levelList.Add(bossLevel);
            levelList.Add(creepyCrawly);
        }

        #region Level array template
        /*
         *
         * 0 = Ingenting
         * 1 = wall
         * 2 = lavatile
         * 3 = crossbow
         * 4 = movementspeed boost
         * 5 = attack speed boost
         * 6 = Hp boost
         * 7 = Creep
         * 8 = FrozenBow
         * 9 = SimpleGun
         * 10 = Wand
         * 11 = BossGhost
         *
         * int[,] level = new int[,]
            {

                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0}

            };
         */
        #endregion
    }
}
