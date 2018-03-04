using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    
    public float shiftrange;    //Defines the distance for the teleport
    private float temprange;    //Variable for storing the temporary value of the teleport distance

    public GameObject proj;
    GameObject projclone;

    Vector2 position;           //Variable for the player position
    RaycastHit2D projection;   //Raycast used for projecting the teleport distance
   
    void Start () {

        temprange = shiftrange;         // Sets temprange to default teleport distance (shiftrange)
       
    }


    void Update()
    {
        
        position = transform.position;  //sets "position" as transform.position (character's position)


        

        //TELEPORTING TO THE RIGHT

        if (Input.GetKey(KeyCode.RightArrow))   //When right arrow key is held down
         {
            projection = Physics2D.Raycast(position, Vector2.right, temprange);
            Debug.DrawRay(position, new Vector2(temprange, 0), Color.black);
            Time.timeScale = 0.3f;  //Slows down time when arrow key is held down

            projclone = Instantiate(proj, projection.point, Quaternion.identity) as GameObject;

            if (projection.collider != null) //When the raycast hits a collider
            {
                Debug.Log("hitright");          //Console shows that the ray hit a collider
                Debug.Log(projection.point);    //Console shows where the ray the collider
                temprange = projection.distance;    //Sets temprange as the distance between the ray source(character) and the collision point

               
            }
            else
            {
                temprange = shiftrange;                
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))    //Press shift to teleport
            {
                transform.Translate(new Vector2(temprange, 0f));    //Teleports the character by the teleport distance (temprange)
            }
           
        }

     

        //TELEPORTING TO THE LEFT
        
        else if (Input.GetKey(KeyCode.LeftArrow))    
        {
            projection = Physics2D.Raycast(position, Vector2.left, temprange);
            Debug.DrawRay(position, new Vector2(-temprange, 0), Color.black);
            Time.timeScale = 0.3f;  

            if (projection.collider != null) 
            {
                Debug.Log("hitright");          
                Debug.Log(projection.point);    
                temprange = projection.distance;    


            }
            else
            {
                temprange = shiftrange;
            }


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.Translate(new Vector2(-temprange, 0f));   
            }
           
        }
        


        //TELEPORTING UPWARDS
        
        else if (Input.GetKey(KeyCode.UpArrow))      
        {
            projection = Physics2D.Raycast(position, Vector2.up, temprange);
            Debug.DrawRay(position, new Vector2(0, temprange), Color.black);
            Time.timeScale = 0.3f;  

            if (projection.collider != null) 
            {
                Debug.Log("hitup");          
                Debug.Log(projection.point);    
                temprange = projection.distance;

            }

            else
            {
                temprange = shiftrange;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))    
            {
                transform.Translate(new Vector2(0f, temprange));    
            }

            
        }
        

        //TELEPORTING DOWNWARDS
        
        else if (Input.GetKey(KeyCode.DownArrow)) { 
            projection = Physics2D.Raycast(position, Vector2.down, temprange);
            Debug.DrawRay(position, new Vector2(0, -temprange), Color.black);
            Time.timeScale = 0.3f;  

            if (projection.collider != null) 
            {
                Debug.Log("hitdown");          
                Debug.Log(projection.point);    
                temprange = projection.distance;    


            }
            else
            {
                temprange = shiftrange;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))   
            {
                transform.Translate(new Vector2(0f, -temprange));    
            }

        }

        else 
        {
            Time.timeScale = 1f;
        }

        
    } 
}
