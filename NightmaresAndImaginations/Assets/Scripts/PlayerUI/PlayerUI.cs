using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject dashButton;
    private GameObject groundPoundButton;
    private GameObject throwSwordButton;


    private PlayerStatsManager playerRef;
    private GameObject parent;
    private bool isSet = false;


    public Sprite dashOnCD;
    public Sprite dash;

    public Sprite groundPoundOnCD;
    public Sprite groundPound;

    public Sprite throwSwordOnCD;
    public Sprite throwSword;



    void Start()
    {
        dashButton = transform.GetChild(0).gameObject;
        groundPoundButton = transform.GetChild(1).gameObject;
        throwSwordButton = transform.GetChild(2).gameObject;

        playerRef = GameObject.FindObjectOfType<PlayerStatsManager>();
        parent = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
         
        if(!isSet)
        {
            isSet = true;
            dashButton.SetActive(parent.GetComponent<Dash>().enabled);
            groundPoundButton.SetActive(parent.GetComponent<PlungeAttack>().enabled);
            throwSwordButton.SetActive(parent.GetComponent<ThrowSword>().enabled);
        }


        bool canUse = playerRef.CanDash();
        if (canUse)
            dashButton.GetComponent<Image>().sprite = dash;
        else
            dashButton.GetComponent<Image>().sprite = dashOnCD;

        canUse = playerRef.CanPlungeAttack();
        if (canUse)
            groundPoundButton.GetComponent<Image>().sprite = groundPound;
        else
            groundPoundButton.GetComponent<Image>().sprite = groundPoundOnCD;

        canUse = playerRef.CanThrow();
        if (canUse)
            throwSwordButton.GetComponent<Image>().sprite = throwSword;
        else
            throwSwordButton.GetComponent<Image>().sprite = throwSwordOnCD;

    }
    private void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
