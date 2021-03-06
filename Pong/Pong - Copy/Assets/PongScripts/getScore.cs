﻿using UnityEngine;
using System.Collections;

public class getScore : MonoBehaviour {

	// Use this for initialization
    public static getScore instance { get; private set; }
    protected int playerScore01 = 0;
    protected int playerScore02 = 0;
    protected int roundWins1 = 0;
    protected int roundWins2 = 0;
    protected bool playerwins = false;
    protected bool showedGUI = false;
    protected int round = 1; 

	void Awake () 
    {
        instance = this;
	}
	
	// Update is called once per frame
    public void score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01++;

            if (playerScore01 == 7)
            {
                round++;
                roundWins1++;
                if (roundWins1 == 2 && roundWins2 == 0)
                {
                    showedGUI = true;
                    if (showedGUI)
                    {
                        playerwins = true;
                        GameObject.Find("GameOverBG").guiTexture.enabled = true;
                        GameObject.Find("GameOverText").guiText.enabled = true;
                        GameObject.Find("P1Wins").guiText.enabled = true;
                        GameObject.Find("Reset2").guiText.enabled = true;
                        GameObject.Find("backMM2").guiText.enabled = true;

                       
                    }
                }
                else
                {

                    if (round > 3)
                    {

                        gameOver();
                        showedGUI = true;
             
                        if (showedGUI)
                        {
                            playerwins = true;
                            GameObject.Find("GameOverBG").guiTexture.enabled = true;
                            GameObject.Find("GameOverText").guiText.enabled = true;
                            GameObject.Find("P1Wins").guiText.enabled = true;
                            GameObject.Find("Reset2").guiText.enabled = true;
                            GameObject.Find("backMM2").guiText.enabled = true;
                            
                        }
                    }
                    else
                    {
                        playerScore01 = 0;
                        playerScore02 = 0;
                    }
                }
            }
        }
        else if(wallName == "leftWall")
        {
            playerScore02++;

            if (playerScore02 == 7)
            {
                round++;
                roundWins2++;
                if (roundWins2 == 2 && roundWins1 == 0)
                {
                    gameOver();
                    showedGUI = true;
                    if (showedGUI)
                    {
                        playerwins = true;
                        GameObject.Find("GameOverBG").guiTexture.enabled = true;
                        GameObject.Find("GameOverText").guiText.enabled = true;
                        GameObject.Find("P2Wins").guiText.enabled = true;
                        GameObject.Find("Reset2").guiText.enabled = true;
                        GameObject.Find("backMM2").guiText.enabled = true;
                     
                    }
                }
                else
                {

                    if (round > 3)
                    {
                       
                        showedGUI = true;
                        
                        if (showedGUI)
                        {
                            playerwins = true;
                            GameObject.Find("GameOverBG").guiTexture.enabled = true;
                            GameObject.Find("GameOverText").guiText.enabled = true;
                            GameObject.Find("P2Wins").guiText.enabled = true;
                            GameObject.Find("Reset2").guiText.enabled = true;
                            GameObject.Find("backMM2").guiText.enabled = true;
                        }
                    }
                    else
                    {
                        playerScore01 = 0;
                        playerScore02 = 0;
                    }
                }
            }
        }
        Debug.Log("Player 1 has won " + roundWins1 + " rounds");
          Debug.Log("Player 2 has won " + roundWins2 + " rounds");
        Debug.Log("Player Score 1 is " + playerScore01);
        Debug.Log("Player Score 2 is " + playerScore02);
    }

   public int getPlayer1Score()
    {

        return playerScore01;
    }

    int getPlayer2Score()
    {
        return playerScore02;
    }

    int getPlayer1Wins()
    {
        return roundWins1;
    }

    int getPlayerWins()
    {
        return roundWins2;
    }

    void gameOver()
    {
        //pauses the game
        Time.timeScale = 0.0f;
    }
 
}
