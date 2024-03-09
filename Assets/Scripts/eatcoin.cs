using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatcoin : MonoBehaviour
{
     GameObject flag;
    public int coinnumber = 0;
   public Text cointext;
   public  AudioSource coin;
    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.FindGameObjectWithTag("flag");
          coin = GetComponent<AudioSource>();
        // cointext = GetComponent<Text>();
        flag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = "Coin : " + coinnumber;
        if (coinnumber >= 10)
        {
            flag.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Coin")
        {  coin.Play();
        coinnumber++;
            Destroy(other.gameObject);
        }
    }
    
}
