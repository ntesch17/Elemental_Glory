using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalManaScale : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            var maxMana = Player.GetComponent<PlayerController>().GetMaxMana();
            var mana = Player.GetComponent<PlayerController>().GetMana();
            var scale = mana / maxMana;

            this.GetComponent<Image>().fillAmount = scale;

        }
    }
}
