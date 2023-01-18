
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ScoreManager : MonoBehaviour, I_SCORE //, I_other_Interface
{

    // ADDED SCRIPTS (internal allows to be accessed)
    //TO DO
    [SerializeField] internal _Player_Script mainScript;

    // FIELDS (variables)
    [SerializeField] internal int score;
    [SerializeField] internal int highScore;


    // SET and CONSTRUCTORS 
void setComponent()
{
        mainScript = GameObject.FindWithTag(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
}

    public void set()
    {
        setComponent();
        // IMPORTED FROM MAIN OBJECT
        this.score = 0;
        this.highScore = this.score;
        // internal fields
    }

    void Start()
    {
        
    }
    public void scorechange()
    {
        score += CONSTANTS.SCORE_DEFAULT_INCREMENT;
    }
   public void scoreChange(int newScore)
    {
        score += newScore;
    }
 public   void scorechange_Random()
    {
        score += Random.Range(CONSTANTS.SCORE_RANGE_MIN , CONSTANTS.SCORE_RANGE_MAX);
    }
   public void scorechange_Special()
    {
        score *=  Random.Range(CONSTANTS.SCORE_RANGE_MIN , CONSTANTS.SCORE_RANGE_MAX);
    }
    // used at the end of the level or death
    public void new_High_Score()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

}