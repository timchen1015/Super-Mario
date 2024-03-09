using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoin : MonoBehaviour
{
    GameObject flag;
    private AudioSource getCoinSound;
    private AudioSource getStarSound;
    public int coinnumber = 0;
    public int starnumber = 0;
    public Text cointext;
    public Text startext;

    private void Start()
    {
        flag = GameObject.FindGameObjectWithTag("flag");
        getCoinSound = GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>();
        getStarSound = GameObject.FindGameObjectWithTag("GoalStarSound").GetComponent<AudioSource>();
        flag.SetActive(false);
    }

    private void Update()
    {
        cointext.text = " : " + coinnumber;
        startext.text = " : " + starnumber;
        if (starnumber == 3)
        {
            flag.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            getCoinSound.Play();
            coinnumber++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Star")
        {
            starnumber++;
            getStarSound.Play();
            Destroy(other.gameObject);
        }
    }
}
