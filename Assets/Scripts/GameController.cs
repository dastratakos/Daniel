using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController instance = null;

	// The speed at which Danny runs forward
	public float speed = 3;
	public float tSpeed = 1;
	public float kLerp = 0.1f;

    public static Vector3 zero;
    public float distance = 0;
    //Vector3 lastPosition;

	// The speed at which Danny moves sideways
	public float sideSpeed = 1;

	// Will require manual adjustment; I don't see a better way to do this
	public float kInvScroll = 1;
	public float kTexScroll = 0.035f;

    public int score = 0;
    public int lives = 5;

    public bool isNotSlow = true;

    public Text scoreText;
    public Text livesText;
    public Text timeText;
    public Text loseText;
    public Text endScoreText;
    public Text endTimeText;
    public Text bestScoreText;          // script to save statistics
    public Text bestTimeText;

	private Dictionary<Effect, float> currEffects = new Dictionary<Effect, float> ();
	private List<Effect> rmList = new List<Effect> ();

    public GameObject collectablesCollider;
    public GameObject statsBar;
    public GameObject endMenu;

	void Awake () {
		if (instance != null)
			Destroy (this);
		else
			instance = this;

        //lastPosition = transform.position;

		tSpeed = speed;
        SetScoreText();
        SetLivesText();
        loseText.text = "";
        endScoreText.text = "";
        endTimeText.text = "";
        bestScoreText.text = "";
        bestTimeText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		speed = Mathf.Lerp (speed, tSpeed, kLerp);

        distance = Vector3.Distance(transform.position, Vector3.zero);
        //lastPosition = transform.position;

        // set the value of score (distance + vans...)
        SetScoreText();
        SetLivesText();
        SetTimeText();

        ProcessEffects ();

	}

	void ProcessEffects () {
		if (currEffects.Count <= 0)
			return;
		foreach (Effect e in currEffects.Keys) {
			e.Update ();
			if (currEffects [e] <= Time.time) {
				e.OnEnd ();
				UndoEffect (e);
				rmList.Add (e);
			}
		}

		foreach (Effect e in rmList) {
			currEffects.Remove (e);
		}
		rmList.Clear ();
	}

	public float GetSpeed () {
		return speed;
	}

	public void SetSpeed (float newSpd) {
		tSpeed = newSpd;
	}

    // TODO this should not be used; will remove later
    public void SetKInvScroll (float newValue) {
        kInvScroll = newValue;
    }
    
    // TODO remove
	public float InvScrollSpeed () {
		return speed * kInvScroll;
	}
    
    // TODO remove
	public float TexScrollSpeed () {
		return speed * kTexScroll;
	}

	public int GetScore () {
		return score;
	}

    public float GetDistance () {
        return distance;
    }
    
	public void AddScore (int inc) {
		score += inc;
	}
    
    public void SubtractLife (int inc) {
        if (lives > 0)
        {
            lives -= inc;
        }
    }

    public void SetScoreText() {
        scoreText.text = "Score: " + (score + distance).ToString();
    }

    public void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        // END OF GAME
        if (lives < 1)
        {
            lives = 0;              // ensures lives does not become negative
            EndGame();
        }
    }

    public void EndGame()
    {
        endMenu.SetActive(true);
        statsBar.SetActive(false);
        scoreText.text = "";
        livesText.text = "";
        timeText.text = "";
        loseText.text = "Darn, Daniel!";
        endScoreText.text = "Score: " + score.ToString();
        endTimeText.text = "Time: " + Time.time;
        bestScoreText.text = "Best Score: ";                    // script to save statistics
        bestTimeText.text = "Best Time: ";
        speed = 0;
        tSpeed = 0;
        sideSpeed = 0;
    }

    public void SetTimeText()
    {
        if (lives >= 1)
        {
            timeText.text = "Time: " + (int)Time.time + " sec";
        }
    }
	public float GetSideSpeed () {
		return sideSpeed;
	}

	public void SetSideSpeed (float newSideSpeed) {
		sideSpeed = newSideSpeed;
	}

	public void ApplyEffect (Effect e) {
        isNotSlow = false;
		tSpeed *= e.speed;
		currEffects.Add (e, Time.time + e.duration);
	}

    public bool notSlow()
    {
        return isNotSlow;
    }

	public void UndoEffect (Effect e) {
        isNotSlow = true;
		tSpeed /= e.speed;
	}

    public void EnableCollectablesCollider() {
        collectablesCollider.SetActive(true);
    }

    public void DisableCollectablesCollider() {
        collectablesCollider.SetActive(false);
    }

}
