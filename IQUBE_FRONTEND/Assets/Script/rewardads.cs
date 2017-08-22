using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class rewardads : MonoBehaviour
{
	int ran;
	public Text mtext;
	void Update() {
		ran = Random.Range (1, 11);
		GetComponent<Button> ().interactable = Advertisement.IsReady ();			
	}
	public cash m;
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			if (ran >=1&&ran<=5) {
				m.money += 1;
			}
			else if (ran >=6&&ran<=8) {
				m.money += 2;
			}
			else if (ran >=9&&ran<=10) {
				m.money += 3;
			}
			mtext.text = m.money.ToString ();
			PlayerPrefs.SetInt ("cash", m.money);
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;

		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError ("The ad failed to be shown.");
			break;
		}
	}
}