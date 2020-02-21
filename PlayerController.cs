using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;




//Read only from here https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html


 

public class PlayerController : NetworkBehaviour {
    public GameObject HBbar;
    public string Name,spellName;
    [ReadOnly] [SerializeField] float maxHealth, maxMana, health, mana, Hps, Mps;
    public List<Modifier> modifiers;
    Spell LegendarySpell;
    //[ReadOnly] [SerializeField] [SyncVar]
    public bool spellGrav, spellLocation, spellnonTarget;
    public float spellSpeed;

    public int exampleValue;

    public int ID;
    int skillPoints, gold;
    [ReadOnly] [SerializeField] bool alive, second, EMActive, canCast = true;
    public bool paused;
    Animator anim;
    [ReadOnly] [SerializeField] float modManaBurn,modLifesteal,modCD,modGold,modExp,modDmgOutput, modDmgInTake, modFireDmg, modWaterDmg, modWindDmg, modEarthDmg, modLightningDmg, modTimeDmg, modSpaceDmg, modMinionDmg, modHeal, modDmg,modSpeed, modHPS,modManaCost,modLuck = 0;
    float dmgOutput,dmgInTake,fireDmg,waterDmg,windDmg,earthDmg,lightningDmg,timeDmg,spaceDmg,minionDmg;
    PlayerController lastPlayerHit;
    public PlayerSpellDirectory spellDirectory;
    public Inventory inv; //Inventory Script, not yet created
    public Canvas pauseCanvas,other,hpcan; 
    bool local,chosen;

    
    public void getInventory()
    {
        inv = GetComponent<Inventory>();
    }

    public override void OnStartClient()
    {
        var IDmaker = GameObject.Find("Network Manager");
        ID = IDmaker.GetComponent<IDCreation>().GetIDnum();
        IDmaker.GetComponent<IDCreation>().RegisterPlayer(this);
        IDmaker.GetComponent<Spell_IDs>().Awake();
        base.OnStartClient();
        spellDirectory.OnStartClient();
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<FollowPlayer>().Player = this.gameObject;
        local = true;
        local = isLocalPlayer;
        print("Wait what " + isLocalPlayer);
        var IDmaker = GameObject.Find("Network Manager");
        
        other.gameObject.SetActive(true);
        hpcan.gameObject.SetActive(true);

        if(!chosen)
        IDmaker.GetComponent<PresetPick>().PlaceHud(this);

        chosen = true;
    }

    public void FixInv()
    {
        paused = false;
        pauseCanvas.gameObject.SetActive(paused);
    }

    public bool GetCanCast()
    {
        return canCast;
    }
    public void ChangeCast()
    {
        canCast = !canCast;
    }

    private void Start()
    {
        print("This player is " + isLocalPlayer);
        if (!isLocalPlayer)
        {//NetworkServer.SpawnWithClientAuthority(HBbar, connectionToClient);
            print("This player is " + isLocalPlayer);
            var vBbar = Instantiate(HBbar);
            var player = this.gameObject;
            vBbar.GetComponent<FollowObjectWithDif>().followedObject = player;
            //vBbar.GetComponentInChildren<ScaleBasedOnHp>().Player = player;
            //vBbar.GetComponentInChildren<ScaleBasedOnMana>().Player = player; 
            //print("HBbar HP name: " + HBbar.transform.GetChild(0).transform.GetChild(0).GetComponent<ScaleBasedOnMana>().Player.name);

        }
    }


    // Use this for initialization
    void Awake () {
        
        var EventSystem = GameObject.Find("EventSystem");
        EventSystem.GetComponent<GetCanvases1>().SetPlayer(this.gameObject);
        getInventory();
        paused = true;
        pauseCanvas.gameObject.SetActive(paused);
        Invoke("FixInv",.1f);
        spellDirectory = GetComponent<PlayerSpellDirectory>();
        //spellDirectory.OnStartClient();


        modifiers = new List<Modifier>();
        inv = GetComponent<Inventory>();
        maxHealth = 50;
        maxMana = 100;
        health = 50;
        mana = 80;
        gold = 0;
        Hps = 2;
        Mps = 2;
        skillPoints = 1;
        InvokeRepeating("TwicePerSecond", 0f, .5f);
        //Initalizing Dmg values
        dmgOutput = 1; dmgInTake = 1; waterDmg = 1; fireDmg = 1; windDmg = 1; earthDmg = 1; lightningDmg = 1; timeDmg = 1; spaceDmg = 1; minionDmg = 1;
        modDmgOutput = 1; modDmgInTake = 1; modWaterDmg = 1; modFireDmg = 1; modWindDmg = 1; modEarthDmg = 1; modLightningDmg = 1; modTimeDmg = 1; modSpaceDmg = 1; modMinionDmg = 1;modHPS = 0;
        modHeal = 0;
        modManaCost = 1;
        modDmg = 0;
        modSpeed = 1;
        modLuck = 1;
        modCD = 1;
        modLifesteal = 0;
        modManaBurn = 0;




        // AddModifier(new EarthArmorMod());


        // print(Time.fixedDeltaTime);
        //AddModifier(new EarthMasteryModifier());
        //AddModifier(new BurnModifier());
        //AddModifier(new SoakedModifier());
        // AddModifier(new BleedingModifier());

        //  AddModifier(new InnerWyvernModifier());
        // AddModifier(new EarthEssenseModifier());
        // AddModifier(new FireEssenseModifier());
        // AddModifier(new WaterEssenseModifier());
        // AddModifier(new AirEssenseModifier());
        // AddModifier(new MorbidStaffModifier());
        // AddModifier(new WarlockCrestModifier());
        print("This player is " + isLocalPlayer);
        CmdRequestNewHealth();
    }
    public bool GetPaused()
    {
        return paused;
    }
    public void SetHPS(float newHPS)
    {
        Hps = newHPS;
    }
    public void SetMPS(float newMPS)
    {
        Mps = newMPS;
    }
    void ResetModifiers()
    {
        modDmgOutput = 1; modDmgInTake = 1; modWaterDmg = 1; modFireDmg = 1; modWindDmg = 1; modEarthDmg = 1; modLightningDmg = 1; modTimeDmg = 1; modSpaceDmg = 1; modMinionDmg = 1;modHPS = 0;
        modHeal = 0;
        modDmg = 0;
        modSpeed = 1;
        modManaCost = 1;
        modLuck = 1;
        modCD = 1;
        modLifesteal = 0;
        modManaBurn = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if ((Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Tab)))
            {
            paused = !paused;
            print("Fire Storm Level: " + spellDirectory.GetSpellLevel(Spell.FIRE_STORM));
            print("Fire Ball Level: " + spellDirectory.GetSpellLevel(Spell.FIRE_BALL));
            print("Water Ball Level: " + spellDirectory.GetSpellLevel(Spell.WATER_BALL));
            print("Fire Bomb Level: " + spellDirectory.GetSpellLevel(Spell.FIRE_BOMB));
            print("Earth Wall Level: " + spellDirectory.GetSpellLevel(Spell.EARTH_WALL));
            }

            if(!paused&& Input.GetButtonDown("Fire1"))
                CmdCastSpellFix();

            if(pauseCanvas!=null)
            pauseCanvas.gameObject.SetActive(paused);
            //ResetModifiers();
            //SumUpModifiers();
        }


       
    }

    [Command]
    public void CmdCastSpellFix()
    {
        RpcCastSpell();
    }
    private void FixedUpdate()
    {
        UniqueModifierCheck();
        regenTick();
        ResetModifiers();
        SumUpModifiers();
    }
    void UniqueModifierCheck()
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName == "Bleeding")
            {
                modifiers[i].UniqueModifier(GetMoving());
            }
            else if(modifiers[i].modName == "Earth Mastery")
            {
                print("EMS Detected");
               // EMActive = true;
               // modifiers[i].modName = "Earth-Mastery";
              //  InvokeRepeating("EarthMasteryLogic", 10f, 10f);
                //modifiers[i].UniqueModifier();
            }
            else if(modifiers[i].modName == "Inner Wyvern")
            {
                modifiers[i].UniqueModifier(GetAirborn());
            }
            
        }
    }
    void EarthMasteryLogic()
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName == "Earth Mastery")
            {
                print("Removing a stack");
                modifiers[i].RemoveStack();
                //EMStacks--;
            }
        }
    }
    void EarthComboLogic()
    {
        print("IN EARTH COMBO");
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName == "Earth Combo")
            {
                print("Removing a stack");
                modifiers[i].RemoveStack();
                //EMStacks--;
            }
        }
    }
    void TwicePerSecond()
    {
        //name = ("Example Value is: " + exampleValue);
        second = !second;
       // regenTick();
        if (second)
        {
            CmdRequestNewHealth();
            modifierTick();
        }
    }
    void modifierTick()
    {
        if(modDmg!=0)
        Damage(modDmg);

        heal(modHeal);
        applyModifier();
    }
    void SumUpModifiers()
    {
        //print("in sum up");
        List<Modifier> appliedMods = new List<Modifier>();
        if(modifiers.Count!=0){
       //     print("Modifier Size: " + modifiers.Count);
            for(int i = 0; i<= modifiers.Count - 1; i++)
            {
                print(this.Name + " : " + modifiers[i].ToString());
                
                    applyModifier(modifiers[i]);
                    print(modifiers[i] + ", being added. modDmg is " + modDmg);
                
                
            }
        }
           
    }

    [ClientRpc]
    public void RpcFixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), obj1.GetComponent<Spell>().GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), IDmaker.GetComponent<IDCreation>().GetPlayer(ID).GetComponent<Collider2D>());


    }
    public void FixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");
        CmdFixPls(obj1);

        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), IDmaker.GetComponent<IDCreation>().GetPlayer(ID).GetComponent<Collider2D>());
    }
    [Command]
    public void CmdFixPls(GameObject obj1)//,GameObject obj2)
    {
        var IDmaker = GameObject.Find("Network Manager");
        

        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(obj1.GetComponent<Collider2D>(), IDmaker.GetComponent<IDCreation>().GetPlayer(ID).GetComponent<Collider2D>());
    }

    [Command]
    void CmdGiveMeInt(int someValue)
    {
        Debug.Log("I got an int! " + someValue);
        exampleValue = someValue;
    }

    void SemdToServer(int num)
    {
        CmdGiveMeInt(num);
    }

    [ClientRpc]
    public virtual void RpcCastSpell()
    {

        print("Casting spell? " + inv.GetIfSpell());

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos2D = new Vector3(pz.x, pz.y);
        Vector2 diff = mousePos2D - this.transform.position;
        //print("DifX: " + diff.x + ", Dify: " + diff.y);
        
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        /*SM - you could nest these if/elseifs into an "if(inv.getIfSpell()) to simplify code"
         Also, you could nest the last if condition, and turrn the GetMouseButton into an if/else to
         cut down on the room for error
         */
        
        if (Input.GetButton("Fire1")&& inv.GetIfSpell())
        {
            Debug.Log("Trying to shoot: " + inv.GetCurrentSpellBook().spell.getName());

            var spell = inv.GetCurrentSpellBook().spell;
            var spellLevel = spellDirectory.GetSpellLevel(spell.getName());


            if(spellLevel < 1)
            {
                print("Spell Not learned");
            }
                
            else if (CheckCD(spell.getName())&&CheckMana(spell.manaCost[spellLevel-1]))
            {
                exampleValue = spell.spellID;
                print("Spell ID: " + exampleValue);
                SemdToServer(exampleValue);
                spellGrav = Spell_IDs.SpellGrav(exampleValue);
                spellLocation = Spell_IDs.SpellLocation(exampleValue);
                spellnonTarget = Spell_IDs.SpellTarget(exampleValue);
                spellName = Spell_IDs.GetSpellName(exampleValue);
                spellSpeed = Spell_IDs.GetSpellSpeed(exampleValue);
                spellLevel = spellDirectory.GetSpellLevel(Spell_IDs.GetSpell(exampleValue).GetComponent<Spell>().getName());
                //CmdRecuestNewValues();
                print(spell.getName() + " at level: " + spellLevel);
                spellDirectory.SetCooldownTimer(spell.getName(),spell.cooldown[spellLevel-1]);
                //spell.level = spellDirectory.GetSpellLevel(spell.getName());
                // inv.GetCurrentSpellBook().spell_orb.GetComponent<Spell>().level = spell.level;
                //CmdRecuestNewValues();
                CmdRecuestNewGrav();
                //CmdRecuestAtLoc();
                CmdRecuestAtTar();
                
                if (spellName == Spell.FIRE_SHOTGUN)
                {
                    print("Fire ShotGun");
                    diff.Normalize();
                    GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
                    CmdFireShotty(orb, rot_z);
                    Destroy(orb);
                    /*
                    for (int i = 0; i <= 5 - 1; i++)
                    {
                        GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                        orb.GetComponent<Spell>().caster = this;
                        orb.GetComponent<Spell>().casterID = ID;

                        // orb.GetComponent<Spell>().level = spell.level;
                        orb.GetComponent<Spell>().OnAwake();
                        if (spellLevel == 1)
                            orb.transform.rotation = Quaternion.Euler(0f, 0f, (rot_z - 90) + Random.Range(-15f, 15f));
                        else
                            orb.transform.rotation = Quaternion.Euler(0f, 0f, (rot_z - 90) + Random.Range(-7.5f, 7.5f));

                        // orb.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-15f, 15f));

                        var rb2d = orb.GetComponent<Rigidbody2D>();
                        rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                        rb2d.velocity = orb.transform.up * inv.GetCurrentSpellBook().spell.speed;
                        CmdNoCollide(orb, this.gameObject);
                        Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                        NetworkServer.Spawn(orb);

                    }*/

                }
                else if (spellnonTarget)
                {
                    GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
                    CmdNoTar(orb);
                    Destroy(orb);
                    /*
                    GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                    orb.GetComponent<Spell>().caster = this;
                    orb.GetComponent<Spell>().casterID = ID;

                    // orb.GetComponent<Spell>().level = spell.level;
                    orb.GetComponent<Spell>().OnAwake();
                    CmdNoCollide(orb, this.gameObject);
                    Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    NetworkServer.Spawn(orb);*/

                }
                else if (spellName == Spell.ICE_SHARD && spellLevel >= 2)
                {
                    diff.Normalize();
                    print("Inside new");
                    StartCoroutine(IceShardSpawns(Spell_IDs.GetSpell(exampleValue), spellLevel, rot_z, diff));
                    /*
                    GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                    orb.GetComponent<Spell>().caster = this;
                    // orb.GetComponent<Spell>().level = spell.level;
                    orb.GetComponent<Spell>().OnAwake();

                    print("Shooting Spell: " + inv.GetCurrentSpell().name + " level " + spellLevel);

                    orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

                    var rb2d = orb.GetComponent<Rigidbody2D>();
                    rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                    rb2d.velocity = diff * inv.GetCurrentSpellBook().spell.speed;
                    Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
                    //CmdNoCollide(Spell_IDs.GetSpell(exampleValue), this.gameObject);
                    //NetworkServer.Spawn(Spell_IDs.GetSpell(exampleValue));
                }
                else if (spellLocation)
                {

                    print("Mouse X: " + mousePos2D.x + ", Y: " + mousePos2D.y);
                    GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), mousePos2D, new Quaternion(0, 0, 0, 0));

                    CmdLocation(orb, mousePos2D);
                    Destroy(orb);
                    /*
                    orb.GetComponent<Spell>().caster = this;
                    orb.GetComponent<Spell>().casterID = ID;
                    orb.GetComponent<Spell>().OnAwake();
                    orb.GetComponent<Rigidbody2D>().gravityScale = 0;
                    // orb.transform.position = mousePos2D;
                    NetworkServer.Spawn(orb);*/
                }
                else if (!spellGrav)
                {
                    diff.Normalize();
                    //GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                    
                   
                    GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
                   
                    CmdNoGravity(orb, rot_z,diff);
                  
                    Destroy(orb);
                    //  RpcAwake(orb); 
                  /*
                    orb.GetComponent<Spell>().caster = this;
                    orb.GetComponent<Spell>().casterID = ID;
                   
                    // orb.GetComponent<Spell>().level = spell.level;
                    orb.GetComponent<Spell>().OnAwake();

                    print("Shooting Spell: " + inv.GetCurrentSpell().name + " level " + spellLevel);

                    orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

                    var rb2d = orb.GetComponent<Rigidbody2D>();
                    rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                    rb2d.velocity = diff * inv.GetCurrentSpellBook().spell.speed;
                    //CmdNoCollide(orb, this.gameObject);
                   // RpcFixPls(orb);

                    Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
                    
                }
                else if (spellGrav)
                {
                    diff.Normalize();
                    //GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));


                    GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));

                    CmdGravity(orb, rot_z, diff);

                    Destroy(orb);
                    /*
                    GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                    diff.Normalize();

                    print("Shooting Spell: " + inv.GetCurrentSpell().name);
                    orb.GetComponent<Spell>().casterID = ID;

                    orb.GetComponent<Spell>().caster = this;
                    // orb.GetComponent<Spell>().level = spell.level;
                    orb.GetComponent<Spell>().OnAwake();
                    orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                    var rb2d = orb.GetComponent<Rigidbody2D>();
                    rb2d.gravityScale = 3;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                    rb2d.velocity = (diff * inv.GetCurrentSpellBook().spell.speed);// / orb.GetComponent<Rigidbody2D>().mass);

                    /*
                    if (rb2d.velocity.x > 19)
                    {
                        var maxX = 17.5f;
                        rb2d.velocity = new Vector2(maxX, rb2d.velocity.y);
                    }
                    if (rb2d.velocity.y > 19)
                    {
                        var maxY = 19f;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, maxY);
                    }
                    if (rb2d.velocity.x < -19)
                    {
                        var maxX = -17.5f;
                        rb2d.velocity = new Vector2(maxX, rb2d.velocity.y);
                    }
                    if (rb2d.velocity.y < -19)
                    {
                        var maxY = -19f;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, maxY);
                    }
                    //    print("VelX: " + rb2d.velocity.x + ", VelY: " + rb2d.velocity.y);
                    CmdNoCollide(orb, this.gameObject);
                    Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    NetworkServer.Spawn(orb);
                    */
                    //NetworkServer.SpawnWithClientAuthority(orb,connect);
                }
            }
        }
        /*
        else if (Input.GetMouseButton(0) && inv.GetIfSpell()&& inv.GetCurrentSpellBook().spell.siphen)
        {
            print("Siphon");
            var spell = inv.GetCurrentSpellBook().spell;
            var spellLevel = spellDirectory.GetSpellLevel(spell.getName());
            print(spell.getName() + " at level: " + spellLevel);

            if (spellLevel == 0)
                print("Spell Not learned");
            else if (CheckCD(spell.getName()) && CheckMana(spell.manaCost[spellLevel - 1]))
            {
                spellDirectory.SetCooldownTimer(spell.getName(), spell.cooldown[spellLevel - 1]);
                diff.Normalize();
                GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));


                print("Shooting Spell: " + inv.GetCurrentSpell().name);

                orb.GetComponent<Spell>().caster = this;
                // orb.GetComponent<Spell>().level = spell.level;
                orb.GetComponent<Spell>().OnAwake();
                var rb2d = orb.GetComponent<Rigidbody2D>();
                rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                rb2d.velocity = diff * inv.GetCurrentSpellBook().spell.speed;
                Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }

        }*/

    }
    [Command]
    public void CmdFireShotty(GameObject orb,float rot_z)
    {
        Destroy(orb);
        /*
        GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
        NetworkServer.Spawn(orb2);
        RpcAwake(orb2);
        orb2.GetComponent<Spell>().caster = this;
        orb2.GetComponent<Spell>().casterID = ID;

        // orb.GetComponent<Spell>().level = spell.level;
        orb2.GetComponent<Spell>().OnAwake();
        //CmdNoCollide(orb, this.gameObject);
        RpcFixPls(orb2);
        FixPls(orb2);
        Physics2D.IgnoreCollision(orb2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //
        print("Fire ShotGun");*/
        
        for (int i = 0; i <= 5 - 1; i++)
        {
            GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
            NetworkServer.Spawn(orb2);
            RpcAwake(orb2);
            orb2.GetComponent<Spell>().caster = this;
            orb2.GetComponent<Spell>().casterID = ID;

            // orb.GetComponent<Spell>().level = spell.level;
            orb2.GetComponent<Spell>().OnAwake();
            if (orb2.GetComponent<Spell>().GetLevel() == 1)
                orb2.transform.rotation = Quaternion.Euler(0f, 0f, (rot_z) + Random.Range(-15f, 15f));
            else
                orb2.transform.rotation = Quaternion.Euler(0f, 0f, (rot_z) + Random.Range(-7.5f, 7.5f));

            // orb.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-15f, 15f));

            var rb2d = orb2.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
            rb2d.velocity = orb2.transform.right * orb2.GetComponent<Spell>().speed;
            CmdNoCollide(orb2, this.gameObject);
            RpcFixPls(orb2);
            FixPls(orb2);
            Physics2D.IgnoreCollision(orb2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            

        }

    }
    [Command]
    public void CmdNoTar(GameObject orb)
    {
        Destroy(orb);

        GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
        NetworkServer.Spawn(orb2);
        RpcAwake(orb2);
        orb2.GetComponent<Spell>().caster = this;
        orb2.GetComponent<Spell>().casterID = ID;

        // orb.GetComponent<Spell>().level = spell.level;
        orb2.GetComponent<Spell>().OnAwake();
        //CmdNoCollide(orb, this.gameObject);
        RpcFixPls(orb2);
        FixPls(orb2);
        Physics2D.IgnoreCollision(orb2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    [Command]
    public void CmdLocation(GameObject orb,Vector3 mousePos2D)
    {
        //CmdRecuestNewValues();
        Destroy(orb);
        //print("Mouse X: " + mousePos2D.x + ", Y: " + mousePos2D.y);
        GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), mousePos2D, new Quaternion(0, 0, 0, 0));
        NetworkServer.Spawn(orb2);
        RpcAwake(orb2);
        //RpcFixPls(orb2);
        orb2.GetComponent<Spell>().caster = this;
        orb2.GetComponent<Spell>().casterID = ID;
        orb2.GetComponent<Spell>().OnAwake();
        orb2.GetComponent<Rigidbody2D>().gravityScale = 0;
        // orb.transform.position = mousePos2D;
        


    }

    [Command]
    public void CmdRequestNewHealth()
    {
        RpcGiveNewHealth(health);
    }

    [ClientRpc]
    public void RpcGiveNewHealth(float value)
    {
        health = value;
    }

    [Command]
    public void CmdRecuestNewValues()
    {
        RpcGiveNewValues(exampleValue);
        
    }

    [ClientRpc]
    public void RpcGiveNewValues(int value)
    {
       // var IDmaker = GameObject.Find("Network Manager");

        //IDmaker.GetComponent<IDCreation>().spellIDTEST[ID] = exampleValue;
        exampleValue = value;
    }

    [Command]
    public void CmdRecuestNewGrav()
    {
        RpcGiveNewNewGrav(spellGrav);
    }

    [ClientRpc]
    public void RpcGiveNewNewGrav(bool value)
    {
        spellGrav = value;
    }

    [Command]
    public void CmdRecuestAtLoc()
    {
        RpcGiveNewAtLoc(spellLocation);
    }

    [ClientRpc]
    public void RpcGiveNewAtLoc(bool value)
    {
        spellLocation = value;
    }

    [Command]
    public void CmdRecuestAtTar()
    {
        RpcGiveNewAtTar(spellnonTarget);
    }

    [ClientRpc]
    public void RpcGiveNewAtTar(bool value)
    {
        spellnonTarget = value;
    }

    [Command]
    public void CmdGravity(GameObject orb,float rot_z,Vector2 diff)
    {/*
         GameObject orb = Instantiate(inv.GetCurrentSpellBook().spell_orb, this.transform.position, new Quaternion(0, 0, 0, 0));
                    diff.Normalize();

                    print("Shooting Spell: " + inv.GetCurrentSpell().name);
                    orb.GetComponent<Spell>().casterID = ID;

                    orb.GetComponent<Spell>().caster = this;
                    // orb.GetComponent<Spell>().level = spell.level;
                    orb.GetComponent<Spell>().OnAwake();
                    orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                    var rb2d = orb.GetComponent<Rigidbody2D>();
                    rb2d.gravityScale = 3;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
                    rb2d.velocity = (diff * inv.GetCurrentSpellBook().spell.speed);// / orb.GetComponent<Rigidbody2D>().mass);

                    /*
                    if (rb2d.velocity.x > 19)
                    {
                        var maxX = 17.5f;
                        rb2d.velocity = new Vector2(maxX, rb2d.velocity.y);
                    }
                    if (rb2d.velocity.y > 19)
                    {
                        var maxY = 19f;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, maxY);
                    }
                    if (rb2d.velocity.x < -19)
                    {
                        var maxX = -17.5f;
                        rb2d.velocity = new Vector2(maxX, rb2d.velocity.y);
                    }
                    if (rb2d.velocity.y < -19)
                    {
                        var maxY = -19f;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, maxY);
                    }
     //    print("VelX: " + rb2d.velocity.x + ", VelY: " + rb2d.velocity.y);
        CmdNoCollide(orb, this.gameObject);
        Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        NetworkServer.Spawn(orb);
        //NetworkServer.SpawnWithClientAuthority(orb,connect);
        {
            */
     //CmdRecuestNewValues();
        Destroy(orb);
        print("in orb2");
        GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
        NetworkServer.Spawn(orb2);
        RpcAwake(orb2);
        orb2.GetComponent<Spell>().speed = Spell_IDs.GetSpellSpeed(exampleValue);
        orb2.name = "NoGrav";
        orb2.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        orb2.GetComponent<Spell>().caster = this;

        orb2.GetComponent<Spell>().casterID = ID;
        orb2.GetComponent<Spell>().Update();
        // orb.GetComponent<Spell>().level = spell.level;
        orb2.GetComponent<Spell>().OnAwake();
        if (rot_z >= 90 || rot_z < -90)
        {
            Vector3 theScale = orb2.transform.localScale;
            theScale.y *= -1;
            orb2.transform.localScale = theScale;
        }
        var rb2d = orb2.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 3;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
        rb2d.velocity = diff * orb2.GetComponent<Spell>().speed;
        RpcFixPls(orb2);
        FixPls(orb2);
        Physics2D.IgnoreCollision(orb2.GetComponent<Collider2D>(), orb2.GetComponent<Spell>().caster.GetComponent<Collider2D>());
        //RpcFixPls(orb2);
        //}

        //NetworkServer.Spawn(orb);

    }
    /*
        if (orb != null&&!isLocalPlayer)
        {
            print("in orb1");
            NetworkServer.Spawn(orb);
            orb.GetComponent<Spell>().caster = this;
            orb.GetComponent<Spell>().casterID = ID;

            // orb.GetComponent<Spell>().level = spell.level;
            orb.GetComponent<Spell>().OnAwake();

          //  print("Shooting Spell: " + inv.GetCurrentSpell().name + " level " + spellLevel);

            orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

            var rb2d = orb.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
            rb2d.velocity = diff * inv.GetCurrentSpellBook().spell.speed;
            //CmdNoCollide(orb, this.gameObject);
            // RpcFixPls(orb);

            Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //RpcAwake(orb);
           // RpcFixPls(orb);
        }
        else
        {*/
    [Command]
    public void CmdNoGravity(GameObject orb,float rot_z,Vector2 diff)
    {
            //CmdRecuestNewValues();
            Destroy(orb);
            print("in orb2");
            GameObject orb2 = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));
            NetworkServer.Spawn(orb2);
            RpcAwake(orb2);
            orb2.GetComponent<Spell>().speed = Spell_IDs.GetSpellSpeed(exampleValue);
            orb2.name = "NoGrav";
            orb2.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            orb2.GetComponent<Spell>().caster = this;

            orb2.GetComponent<Spell>().casterID = ID;
            orb2.GetComponent<Spell>().Update();
            // orb.GetComponent<Spell>().level = spell.level;
            orb2.GetComponent<Spell>().OnAwake();
        if (rot_z >= 90 || rot_z < -90)
        {
            Vector3 theScale = orb2.transform.localScale;
            theScale.y *= -1;
            orb2.transform.localScale = theScale;
        }
        var rb2d = orb2.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
            rb2d.velocity = diff * orb2.GetComponent<Spell>().speed;
            RpcFixPls(orb2);
        FixPls(orb2);
        Physics2D.IgnoreCollision(orb2.GetComponent<Collider2D>(), orb2.GetComponent<Spell>().caster.GetComponent<Collider2D>());
            
            //RpcFixPls(orb2);
        //}

         //NetworkServer.Spawn(orb);
       
    }
    public bool ModContains(string modName)
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].modName.Equals(modName))
            {
                return true;
            }
        }
        return false;
    }

    [ClientRpc]
    public void RpcAwake(GameObject orb)
    {
        orb.GetComponent<Spell>().caster = this;
        orb.GetComponent<Spell>().casterID = ID;

        // orb.GetComponent<Spell>().level = spell.level;
        orb.GetComponent<Spell>().OnAwake();

    }

    public override void OnDeserialize(NetworkReader reader, bool initialState)
    {
        base.OnDeserialize(reader, initialState);
    }

    [Command]
    void CmdNoCollide(GameObject o1,GameObject o2)
    {
        //RpcFixPls(o1, o2);
    }

    IEnumerator IceShardSpawns(GameObject spawnPF, int spellLevel, float rot_z,Vector2 diff)
    {
        diff.Normalize();

        //GameObject orb = Instantiate(Spell_IDs.GetSpell(exampleValue), this.transform.position, new Quaternion(0, 0, 0, 0));

        //CmdNoGravity(orb, rot_z, diff);

        //Destroy(orb);

        for (int i = 0; i <= 2; i++)
        {

            GameObject orb = Instantiate(spawnPF, this.transform.position, new Quaternion(0, 0, 0, 0));
            CmdNoGravity(orb, rot_z, diff);
            Destroy(orb);
            /*
            orb.GetComponent<Spell>().caster = this;
            // orb.GetComponent<Spell>().level = spell.level;
            orb.GetComponent<Spell>().OnAwake();
            //print("Shooting Spell: " + inv.GetCurrentSpell().name + " level " + spellLevel);

            orb.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
       
            var rb2d = orb.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;//shoots straight, 1 for gravity, 10 for unique abilities i.e. Lightning bolt
            rb2d.velocity = diff * inv.GetCurrentSpellBook().spell.speed;
           // RpcFixPls(orb);//, this.gameObject);
            Physics2D.IgnoreCollision(orb.GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
        yield return new WaitForSeconds(.1f);

        }
    }
    public void AddGold(int addGold)
    {
        if(addGold>0)
            gold += addGold;
    }
    public void CmdSetMaxHealth(float newHealth)
    {
        this.maxHealth = newHealth;
        CmdRequestNewHealth();
    }
    public void SetMaxMana(float newMana)
    {
        this.maxMana = newMana;
    }
    public bool CheckMana(float manaCost)
    {
        var enoughMana = true;
        if (manaCost < mana)
            SetMana(mana - manaCost);
        else
            enoughMana = false;
        

        return enoughMana;
    }
    public bool CheckCD(string spellName)
    {
        return spellDirectory.CheckIfOffCooldown(spellName);
    }
    public void SetMana(float manaN)
    {
        mana = manaN;
    }
    public void CmdSetHP(float HPN)
    {
        health = HPN;
        CmdRequestNewHealth();
    }
    public void RemoveModifier(Modifier mod)
    {
        modifiers.Remove(mod);
    }
    public virtual void AddModifier(Modifier mod)
    {
        print(this.Name + " : Mod Name: " + mod.modName + "Mod is already in list? " + (modifiers.Contains(mod)));
        //mod.Added();
        if (!modifiers.Contains(mod))
        {
            modifiers.Add(mod.Added());
            print("Added: " + mod.modName);   
        }
        else
        {
            modifiers[modifiers.IndexOf(mod)].duration = modifiers[modifiers.IndexOf(mod)].baseDuration;
        }
    }/*
    public void AddModifiers(Modifier mod,Modifier mod2)
    {
        print("Mod Name: " + mod.modName);
        print("Mo2d Name: " + mod2.modName);

        if(!modifiers.Contains(mod))
        modifiers.Add(mod);
        else
        {
            modifiers[modifiers.IndexOf(mod)].duration = modifiers[modifiers.IndexOf(mod)].baseDuration;
        }

        if (!modifiers.Contains(mod2))
        modifiers.Add(mod2);
        else
        {
            modifiers[modifiers.IndexOf(mod2)].duration = modifiers[modifiers.IndexOf(mod2)].baseDuration;
        }
    }*/
    public float GetMaxMana()
    {
        return maxMana;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetMana()
    {
        return mana;
    }
    public float GetHealth()
    {
        return health;
    }
    void regenTick()
    {
        heal((Hps+modHPS) *Time.fixedDeltaTime);
        ManaRecover(Mps * Time.fixedDeltaTime);
       // SendHealth(health);
        //CmdRequestNewHealth();
    }
    void SendHealth(float num)
    {
        CmdSyncHealth(num);
    }
    [Command]
    void CmdSyncHealth(float hp)
    {      
        RpcGiveNewHealth(hp);
    }
    public void heal(float num)
    {
        health += num;
        if (health > maxHealth)
            health = maxHealth;
    }

    
    public void Damage(float num)
    {
        CmdDamamge(num);
       
        //if(!isServer)
        //RpcDamage(num);

        /*
        print(this.Name + " Damaged: " + num);

        health -= num;
        if (health < 0)
            health = 0;

        if (health <= 0)
        {
            print("Player " + ID + ", was murdered.");
          //  Destroy(this.gameObject);
        }
        CmdRequestNewHealth();
        */
    }
    [Command]
    public void CmdDamamge(float num)
    {
        print(this.Name + " Damaged: " + num);

        health -= num;
        if (health <= 0)
        {
            Hps = 0;
            //Time.timeScale = 0;
            //CmdEndGame(0);
            var IDmaker = GameObject.Find("Network Manager");
            IDmaker.GetComponent<TournamentScript>().LoseRound(this);

            print("Player " + ID + ", was murdered.");

            health = 0;

           
            //  Destroy(this.gameObject);
        }

        /*
        if (health <= 0)
        {
            var IDmaker = GameObject.Find("Network Manager");
            IDmaker.GetComponent<TournamentScript>().LoseRound(this);
            
                print("Player " + ID + ", was murdered.");
            //  Destroy(this.gameObject);
        }*/
        CmdRequestNewHealth();
    }
    [Command]
    public void CmdEndGame(int num)
    {
        RpcTimeScale(num);
    }
    
    [ClientRpc]
    public void RpcTimeScale(int i)
    {
        Time.timeScale = i;
    }

    [ClientRpc]
    public void RpcDamage(float num)
    {
        print(this.Name + " Damaged: " + num);

        health -= num;
        if (health < 0)
            health = 0;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        SendHealth(health);
    }
    public bool GetDead()
    {
        return health <= 0; 
    }

    public void ManaRecover(float num)
    {
        mana += num;
        if (mana > maxMana)
            mana = maxMana;
    }
    public void ManaBurn(float num)
    {
        float manaBefore = mana;
        mana -= num;
        if (mana < 0){
            mana = 0;
        }
        Damage(manaBefore - mana);
    }

    public void AddToInventory(Items item)
    {
        inv.AddToInventory(item);
    }


    public virtual void applyModifier()
    {
        //Slow/SpeedBoost
        GetComponent<Movement>().SetSpeed(Movement.baseSpeed*modSpeed);


    }
    public void applyModifier(Modifier mod)
    {
        print("in apply modifier");

        if (mod.magicImmune)
        {
            MagicImmunity();
            //mod.magicImmune = false;
            //nullifies debuff modifiers
        }

        if (mod.damageReduc)
            this.modDmgInTake -= mod.amount;

        if(mod.dmgOutput)
            this.modDmgOutput += mod.amount;

        if(mod.luck)
            this.modLuck += mod.amount;

        if(mod.gold)
            this.modGold += mod.amount;

        if(mod.exp)
            this.modExp += mod.amount;

        if(mod.cdReduc)
            this.modCD += mod.amount;

        if(mod.manaBurn)
            this.modManaBurn += mod.amount;

        if(mod.stun){
            Stun(mod.duration);
            mod.stun = false;
        }

        if(mod.flight){
            Fly(mod.duration);
            mod.flight = false;
        }
        if (mod.slow)
        {
           this.modSpeed -= mod.amount;
        }
        if (mod.manaCost)
        {
            this.modManaCost += mod.amount;
        }

        if(mod.damage){//dmg over time not done yet
            this.modDmg += mod.amount;
            SemdToServerDmgValue(this.modDmg);
        }
        if (mod.fireDmg)
        {
            this.modFireDmg += mod.amount;
        }
        if (mod.waterDmg)
        {
            this.modWaterDmg += mod.amount;
        }
        if (mod.windDmg)
        {
            this.modWindDmg += mod.amount;
        }
        if (mod.earthDmg)
        {
            this.modEarthDmg += mod.amount;
        }
        if (mod.lightningDmg)
        {
            this.modLightningDmg += mod.amount;
        }
        if (mod.timeDmg)
        {
            this.modTimeDmg += mod.amount;
        }
        if (mod.spaceDmg)
        {
            this.modSpaceDmg += mod.amount;
        }
        if (mod.minionDmg)
        {
            this.modMinionDmg += mod.amount;
        }
        if (mod.hps)
        {
            this.modHPS += mod.amount;
        }

        if (mod.heal){//heal over time done yet either
            this.modHeal += mod.amount;
        }
//  modHeal, modDmg;

        if (mod.speedBoost)
        {
            modSpeed += (mod.amount);
            // just add need to add a method to reduce after duration
        }
       
        if(mod.lifesteal)
        {
            modLifesteal += mod.amount;
        }

           

        if(mod.duration>0)
            mod.duration = mod.duration - Time.fixedDeltaTime;

        if (mod.duration <= 0&&mod.duration>-1)
        {
            modifiers.Remove(mod);
        }
    }
    [Command]
    void CmdGiveMeDmgValue(float someValue)
    {
        //Debug.Log("I got an int! " + someValue);
        modDmg = someValue;
    }
    void SemdToServerDmgValue(float num)
    {
        CmdGiveMeDmgValue(num);
    }
    void Slow(float duration)
    {
        
    }
    void Stun(float duration)
    {
        //stop movement and cant cast spells
    }
    void Fly(float duration)
    {
        //stop movement and cant cast spells
    }
    void SpeedBoost(float duration)
    {
      //  var newSpeed = GetComponent<Movement>().getSpeed() * mod.amount;
        
    }
    void MagicImmunity()
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            if (modifiers[i].debuff)
            {
                modifiers.Remove(modifiers[i]);
            }
        }
    }

    public void OnBeingHit(Spell spell)//Player being hit
    {
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
           print("Being Hit Modifier Name: " + modifiers[i].modName);
          // modifiers[i].creator.onEnemyHit(spell);
           modifiers[i].OnHitModifier(spell);
           modifiers[i].OnHitModifier();
            if (modifiers[i].modName == "Earth Mastery")
            {
                Invoke("EarthMasteryLogic",10f);
            }
        }
        this.Damage(spell.GetDamage());
    }

    public void onEnemyHit(Spell spell)//Player Hitting someone else
    {
        print("Made it to enemy hit");
        for (int i = 0; i <= modifiers.Count - 1; i++)
        {
            print("Hit Enemy Modifier Name: " + modifiers[i].modName);
            //modifiers[i].creator.onEnemyHit(spell);
            modifiers[i].OnHittingModifier(spell);
            modifiers[i].OnHittingModifier();
            if (modifiers[i].modName == "Earth Combo"&&spell.element==Spell.EARTH_ELEMENT)
            {
                print("Pre Earth Combo");
                Invoke("EarthComboLogic", 10f);
            }
        }
        if (spell.GetElement().Equals(Spell.EARTH_ELEMENT)) { }
            //spell.SetDamage(spell*)
    }
    public virtual bool GetMoving()
    {
        return (GetComponent<Movement>().GetHorizButtonPress() != 0);
    }
    public bool GetAirborn()
    {
        return !GetComponent<JumpLogic>().getOnGround();
    }
    public int GetSpellLevel(string spellName)
    {
        return spellDirectory.GetSpellLevel(spellName);
    }
}
