using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    
    public float shiftrange;    //Defines the distance for the teleport
    private float temprange;    //Variable for storing the temporary value of the teleport distance
    private bool exists;
    public GameObject proj;         //Define object to be cloned for the projection
    private GameObject projclone;    //Defines clone of projection

  

   
    

    GameObject Blumpy;
    GameObject Blumpy2;

    Vector2 position;           //Variable for the player position
    Vector2 blinkright;
    Vector2 blinkleft;
    Vector2 blinkup;
    Vector2 blinkdown;

    Ray2D projection;
    RaycastHit2D hit;   //Raycast used for projecting the teleport distance
    

    void Start () {

        temprange = shiftrange;        // Sets temprange to default teleport distance (shiftrange)
        Blumpy = GameObject.Find("Blumpy");     //Sets object Blumpy as "Blumpy" 
        Blumpy2 = GameObject.Find("Blumpy2");   //Sets object Blumpy2 as "Blumpy2" 
        
        blinkright = new Vector2(temprange, 0);
        blinkleft = new Vector2(-temprange, 0);
        blinkup = new Vector2(0f, temprange);
        blinkdown = new Vector2(0f, -temprange);
        
        


    }


    void Update()
    {
        

        position = transform.position;  //sets "position" as transform.position (character's position)

        if (Input.GetKey(KeyCode.RightArrow))
        {
            BlinkDir(Vector2.right, blinkright, blinkright);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            BlinkDir(Vector2.left, blinkleft, blinkleft);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            BlinkDir(Vector2.up, blinkup, blinkup);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            BlinkDir(Vector2.down, blinkdown, blinkdown);
        }


        else
        {

            
            exists = false;
            Destroy(projclone);
            Time.timeScale = 1f;
            
        }

    }

    void BlinkDir (Vector2 direction, Vector2 blinkdir, Vector2 debugl)
    {

        projection = new Ray2D(position, direction);
        hit = Physics2D.Raycast(position, direction, temprange, 1 << LayerMask.NameToLayer("Walls"));

        Debug.DrawRay(position, debugl, Color.black);
        Time.timeScale = 0.3f;  //Slows down time when arrow key is held down


        if (hit.collider != null) //When the raycast hits a collider
        {
            Debug.Log("hitright");          //Console shows that the ray hit a collider
            Debug.Log(hit.point);    //Console shows where the ray the collider
            temprange = hit.distance;    //Sets temprange as the distance between the ray source(character) and the collision point
        }
         
       

        if (exists == false) //Condtion if "exists" bool is false
        {            
            projclone = Instantiate(proj, projection.GetPoint(temprange), Quaternion.identity) as GameObject;   //Creates an object "projection" at temprange              
            projclone.transform.parent = Blumpy.transform;      //sets the created object clone as child of character, so that it follows it           
            exists = true;  //Sets "bool" to true, so that it does not create any more of that object
        }

        else
        {
            temprange = shiftrange;
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift))    //Press shift to teleport
        {
            transform.Translate(blinkdir);    //Teleports the character by the teleport distance (temprange)
        }


    }
   
}
