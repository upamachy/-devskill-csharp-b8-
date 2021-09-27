using Assignment_4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Services
{
    public class PlayerServices
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PlayerServices()
        {
            
        }

        public PlayerModel[] SetPlayer(int numberOfPlayer)
        {
            PlayerModel[] players = new PlayerModel[numberOfPlayer];
            for(int i=0; i<numberOfPlayer; i++)
            {
                players[i] = new PlayerModel();
            }
            return players;
        }

        public bool  KachaGutiAche(PlayerModel player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Pices[i] == 73) return true;
            }
            return false;
        }

        public bool IsPiceOnBord(PlayerModel player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Pices[i] < 73) return true;
            }
            return false;
        }
        public int GetPlayerPicePostion(PlayerModel playerModel, int piceNumber)
        {
            return playerModel.Pices[piceNumber];
        }

        public void SetPiceOnBord(PlayerModel player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Pices[i] == 73)
                {
                    player.Pices[i]--; break;
                }
            }
        }

        public bool IsPicePossibleToMove(int picesPostion, int movingAmount) {
            if(picesPostion == 73)
            {
                return false;
            }
            else if (picesPostion - movingAmount >= 0)
            {
                return true;
            }
            return false;
        }
        public bool IsGameOver(PlayerModel[] players, int playerCount)
        {
            int count = 0;
            for (int i = 0; i < playerCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (players[i].Pices[j] > 0)
                    {
                        count++; break;
                    }
                }
            }
            return count > 1 ? false : true;
        }
        public bool IsPlayerWin(PlayerModel player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Pices[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool isPlayerAbleToPlay(PlayerModel player)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player.Pices[i] > 0 && player.Pices[i] < 73 )
                {
                    return true;
                }
            }
            return false;
        }

        public int ChangePlayer(int numberOfPlayer, int CurrentPlayer)
        {
            if (numberOfPlayer == CurrentPlayer+1) return 0;
            else return ++CurrentPlayer;
        }

        public bool IsValidMovePossible (PlayerModel player, int diceNumber)
        {
            for(int i=0; i<4; i++)
            {
                if (player.Pices[i] - diceNumber >= 0) return true;
            }
            return false;
        }

    }
}
