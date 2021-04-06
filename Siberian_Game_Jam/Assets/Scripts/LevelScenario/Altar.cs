using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Altar : MonoBehaviour
{
    //public bool player_in_col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Altar_Eyes sn;

    void OnTriggerEnter2D(Collider2D other)
    {

        //Altar_Eyes eye_trigger, m_someOtherScriptOnAnotherGameObject;

        Debug.Log("HIT DETECTED");

        if (other.gameObject.tag == "Player")
        {

            //m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(Altar_Eyes));
            //m_someOtherScriptOnAnotherGameObject.ignite_eyes();

            //eye_trigger = GameObject.Find("Gods_Eyes").GetComponent(Altar_Eyes);
            //eye_trigger.ignite_eyes();


            sn = GameObject.FindGameObjectWithTag("Altar_Eyes").GetComponent<Altar_Eyes>();
            Debug.Log(sn);
            sn.ignite_eyes();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            sn = GameObject.FindGameObjectWithTag("Altar_Eyes").GetComponent<Altar_Eyes>();
            Debug.Log(sn);
            sn.fade_eyes();
        }


        //Altar_Eyes sn = gameObject.GetComponent<Altar_Eyes>();
        //sn.ignite_eyes();

    }


    //bool OnTarget = GetComponentInParent<Soul>().OnTarget;

    /*if (col.gameObject.tag == "Player" && OnTarget == false)
    {
        if (col.gameObject.GetComponent<Player>().NotLimitSoul())
        {
            GetComponentInParent<Soul>().SetTarget(col.gameObject);
        }
    }*/
    //}

}
