using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;


    public Text LivesLabel;
    public Text ScoreLabel;
    public Button RestartButton;
    public Text GameOverLabel;
    public PlayerController player;


    [SerializeField]
    private AudioSource _gameOverSound;
    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;

        }
    }
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue < 0)
            {
                
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "lives: " + this._livesValue;
            }
        }
    }



	// Use this for initialization
	void Start () {
		this._GenerateTanks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {

        this.ScoreValue = 0;
        this.LivesValue = 5;


        //this.GameOverLabel.gameObject.SetActive(false);
        //this.HighScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}

    

    private void _endGame()
    {
        //this.GameOverLabel.gameObject.SetActive(true);
        this.player.gameObject.SetActive(false);
        //this.coin.gameObject.SetActive(false);
        //this.LivesLabel.gameObject.SetActive(false);
        //this.ScoreLabel.gameObject.SetActive(false);
        //this.HighScoreLabel.gameObject.SetActive(true);
        //this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this._gameOverSound.Play();
        this.RestartButton.gameObject.SetActive(true);
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
