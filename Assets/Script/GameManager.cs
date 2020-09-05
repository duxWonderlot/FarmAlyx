using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this handles Game Functionality like game_over, win conditions
//Also Take's care of player triggers in the game
public class GameManager : MonoBehaviour
{
  [SerializeField]
  private int score_,level_,info_score,Info_level,limit,trigger_limit;
  [SerializeField]
  private Slider player_immunity;
  [SerializeField]
  private Slider Infection;
  [SerializeField]
  private Text info_lvl, Soup_lvl;

  public static GameManager instance_;



   private void Awake() {
    if(instance_ == null)
    {
        instance_ = this;
    }else
    {
        DontDestroyOnLoad(this.gameObject);
    }

    level_ =0;
  }
    private void Start()
    {
        player.instance.spell = false;
        player_immunity.maxValue = 1000.0f;
        Infection.maxValue = 1000.0f;
        Time.timeScale = 1;
    }
  public void Add_Score(int i){
   
   if(i ==0){
     score_ +=20;
     trigger_limit = 600;
     limit = 4000;
     player_immunity.value +=score_;
     if(player_immunity.value ==  player_immunity.maxValue){
        
         level_+=5;
         Soup_lvl.text = "" + level_;
         player_immunity.value = 0;
     }

            if (level_ >= trigger_limit)
            {
                player.instance.spell = true;
            }
            if (level_ >= limit && player.instance.spell)
            {
                Time.timeScale = 0;
                Soup_lvl.text = "Zero_infection";
            }


   }
      else if (i == 2)
       {
            score_ += 1*(int)Time.deltaTime;
            limit = 4000;
            player_immunity.value += score_;
            if (player_immunity.value == player_immunity.maxValue)
            {

                level_ += 1;
                Soup_lvl.text = "" + level_;
                player_immunity.value = 0;
            }
            if (level_ >= limit && player.instance.spell)
            {
                Time.timeScale = 0;
                Soup_lvl.text = "Zero_infection";
            }


        }


    }

    public void Infection_Score()
    {
        Time.timeScale = 0;
        Debug.Log("Game over");
        Soup_lvl.text = "infected";

    }
    public void changeScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
    public void Quit_game()
    {
        Application.Quit();
    }
}
