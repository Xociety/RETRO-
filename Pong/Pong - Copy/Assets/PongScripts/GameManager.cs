﻿using UnityEngine;
using System.Collections;

public class GameManager : getScore {

   public GUISkin theSkin;
   Transform theBall;
   private bool pauseGame = false;
   private bool showGUI  = false;
   private bool pauseDisabled = true;
   private GameObject pause;
   void Update()
   {
       if (pauseDisabled)
       {
           if (Input.GetKeyDown("p"))
           {
               pauseGame = !pauseGame;

               if (pauseGame == true)
               {
                   Time.timeScale = 0;
                   pauseGame = true;
                   showGUI = true;
               }
           }
       }

       if (pauseGame == false)
       {
           Time.timeScale = 1;
           pauseGame = false;
           showGUI = false;
       }

       if (playerwins == true)
       {
           showGUI = false;
           pauseDisabled = false;
           pauseGame = true;
           Time.timeScale = 0;
       }

       if (showGUI == true)
       {
           GameObject.Find("Reset").guiText.enabled = true;
           GameObject.Find("backMM").guiText.enabled = true;
           GameObject.Find("PausedGUI").guiTexture.enabled = true;
           
       }

       else
       {
           GameObject.Find("Reset").guiText.enabled = false;
           GameObject.Find("backMM").guiText.enabled = false;
           GameObject.Find("PausedGUI").guiTexture.enabled = false;
       }

       if (Input.GetKeyDown("m"))
       {
           Time.timeScale = 1;
           Application.LoadLevel("GameMenu");
       }
       if (Input.GetKeyDown("r"))
       {
           if (Time.timeScale == 0)
           {
               Time.timeScale = 1;
           }
            Application.LoadLevel("Level1_Pong");
       }
   
   }

   void Start()
   {
       theBall = GameObject.FindGameObjectWithTag("Ball").transform;
   }

     void OnGUI()
     {
         GUI.skin = theSkin;
         GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 160, 100, 30), "" + playerScore01);
         GUI.Label(new Rect(Screen.width / 2 - (-70), Screen.height / 2 - 160, 100, 30), "" + playerScore02);
         GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 200, 100, 30), "Round " + round);


         GUI.Label(new Rect(Screen.width / 2 - 288, Screen.height / 2 - 220, 100, 30), "Wins: " + roundWins1);
         GUI.Label(new Rect(Screen.width / 2 - (-180), Screen.height / 2 - 220, 100, 30), "Wins: " + roundWins2);

         /*
         if (GUI.Button(new Rect(Screen.width / 2-121/4, 35, 121, 53), "RESET"))
         {
             playerScore01 = 0;
             playerScore02 = 0;

             theBall.gameObject.SendMessage("ResetBall");
         }
          */
     }


}



