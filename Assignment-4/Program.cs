using Assignment_4.Interface;
using Assignment_4.Model;
using Assignment_4.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Members
            var _playerServices = new PlayerServices();
            int playerCount = 0;
            PlayerModel[] players;
            var WinnerList = new List<WinnersModel>();
            #endregion
            Console.WriteLine("How many players:");
            playerCount = Convert.ToInt32(Console.ReadLine());
            if (playerCount > 4)
            {
                players = _playerServices.SetPlayer(4);
                Console.WriteLine("Opps !!! Too many players. We are setting for 4 players");
            }
            else{
                players = _playerServices.SetPlayer(playerCount);
            }            
            int CurrentPlayer = 1;
            bool gameEnd = false;
            _playerServices.KachaGutiAche(players[CurrentPlayer]);

            int playerEnd = 0;
            while(gameEnd == false)
            {               
                playerEnd = 0;
                foreach (var item in WinnerList)
                {
                    if (item.PlayerId == CurrentPlayer)
                    {
                        playerEnd = 1;break;
                    }
                }
                while (playerEnd == 0)
                {                   
                    Console.WriteLine("Now play Player-" + CurrentPlayer);
                    Console.WriteLine("Please press anykey to roll the dice\n");
                    Console.ReadKey();
                    Console.WriteLine("rolling.....\n");
                    IDice iDices = new Dices();
                    int diceNumber = iDices.GetDiceNumber();
                    //diceNumber = 6;

                    Console.WriteLine("Dice Number: " + diceNumber);
                    if (_playerServices.IsValidMovePossible(players[CurrentPlayer], diceNumber) == false)
                    {
                        Console.WriteLine("No Valid Move");
                        playerEnd = 1;
                        continue;
                    }

                    if (diceNumber == 6)
                    {
                        int n = 0;
                        string msg = "";
                        bool IsImmatureExist = _playerServices.KachaGutiAche(players[CurrentPlayer]);
                        bool IsPiceOnBordExist = _playerServices.IsPiceOnBord(players[CurrentPlayer]);
                        if (IsImmatureExist)
                        {
                            msg += "Press 1 for Putting piece to board";
                        }
                        if (IsPiceOnBordExist)
                        {
                            msg += msg == "" ? "" : ",";
                            msg += " Press 2 for continue another piece";
                        }
                        Console.WriteLine(msg);
                        bool checkInput = true;
                        while (checkInput)
                        {
                            n = Convert.ToInt32(Console.ReadLine());
                            if (n > 2 || n < 1) {
                                Console.WriteLine("Wrong input\n"+msg);
                            }
                            else if(IsImmatureExist == false && n == 1)
                            {
                                Console.WriteLine("No Pice to put on board\n" + msg);
                            }
                            else if(IsPiceOnBordExist == false && n == 2)
                            {
                                Console.WriteLine("No Pice to play\n" + msg);
                            }
                            else
                            {
                                checkInput = false;
                            }
                        }

                        if (n == 1)
                        {
                            _playerServices.SetPiceOnBord(players[CurrentPlayer]);

                        }
                        else if (n == 2)
                        {
                            Console.WriteLine("which piece do you want to continue?");
                            for (int i = 0; i < 4; i++)
                            {
                                if (players[CurrentPlayer].Pices[i] == 73)
                                {
                                    Console.WriteLine("Piece-" + i + " :Position = Not put to board yet.\n");
                                }
                                else
                                {
                                    Console.WriteLine("Piece-" + i + " :Position = " + players[CurrentPlayer].Pices[i] + "\n");
                                }

                            }

                            checkInput = true;
                            while (checkInput)
                            {
                                int pieceToContinue = Convert.ToInt32(Console.ReadLine());
                                if(_playerServices.IsPicePossibleToMove(players[CurrentPlayer].Pices[pieceToContinue], diceNumber) == false)
                                {
                                    Console.WriteLine("Unable to Move. Please select another pice");
                                }
                                else{
                                    players[CurrentPlayer].Pices[pieceToContinue] -= diceNumber;
                                    checkInput = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        playerEnd = 1;
                        bool isPlayerAbleToPlay = _playerServices.isPlayerAbleToPlay(players[CurrentPlayer]);
                        if (isPlayerAbleToPlay == false) continue;

                        Console.WriteLine("which piece do you want to continue?");
                        for (int i = 0; i < 4; i++)
                        {
                            if (players[CurrentPlayer].Pices[i] == 73)
                            {
                                Console.WriteLine("Piece-" + i + " :Position = Not put to board yet.\n");
                            }
                            else
                            {
                                Console.WriteLine("Piece-" + i + " :Position = " + players[CurrentPlayer].Pices[i] + "\n");
                            }

                        }
                        bool checkInput = true;
                        while (checkInput)
                        {
                            int pieceToContinue = Convert.ToInt32(Console.ReadLine());
                            if(pieceToContinue>3 && pieceToContinue < 0)
                            {
                                Console.WriteLine("Wrong choiche. Please choose again ");
                            }
                            else if (_playerServices.IsPicePossibleToMove(players[CurrentPlayer].Pices[pieceToContinue], diceNumber) == false)
                            {
                                Console.WriteLine("Unable to Move. Please select another pice");
                            }
                            else
                            {
                                Console.WriteLine("Pice " + pieceToContinue + " is moved " + diceNumber + " blocks");
                                players[CurrentPlayer].Pices[pieceToContinue] -= diceNumber;
                                checkInput = false;
                            }
                        }
                    }
                    bool isPlayerWin = _playerServices.IsPlayerWin(players[CurrentPlayer]);
                    if (isPlayerWin)
                    {
                        int len = WinnerList.Count;
                        var winner = new WinnersModel { 
                            Position = len + 1, 
                            PlayerId = CurrentPlayer };
                        WinnerList.Add(winner);
                    }
                    gameEnd = _playerServices.IsGameOver(players, playerCount);
                }
                int playerNxt = _playerServices.ChangePlayer(playerCount, CurrentPlayer);
                CurrentPlayer = playerNxt;
            }
            foreach(var p in WinnerList)
            {
                Console.WriteLine("Player " + p.PlayerId + " Win " + p.Position + " position");
            }
            Console.ReadKey();
        }

        
        
    }
}
