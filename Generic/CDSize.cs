using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDSize : MonoBehaviour
{
    public Items spell;
    public Image cd;
    public bool spellssssss;
   
    // Start is called before the first frame update
    void Start()
    {
        cd = this.GetComponent<Image>();
        spell = transform.GetComponentInParent<SlotsClickManager>().GetItem();  
    }

    // Update is called once per frame
    void Update()
    {
        spell = transform.GetComponentInParent<SlotsClickManager>().GetItem();

        if (GetComponentInParent<AlternateSpots>().player.inv.GetIfSpell())
            cd.fillAmount = 1 - (spell.GetSpell().cooldown[2] - GetComponentInParent<AlternateSpots>().player.spellDirectory.GetSpellCD(spell.GetSpell().spellName)) / spell.GetSpell().cooldown[2];
        else
            cd.fillAmount = 0;
    }
}
