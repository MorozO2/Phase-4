using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    
    public float shiftrange;    //Defines the distance for the teleport
    private float temprangeright;    //Variable for storing the temporary value of the teleport distance
    private float temprangeleft;
    private float temprangeup;
    private float temprangedown;

    Vector2 position;           //Variable for the player position
    RaycastHit2D projectionright;    //Raycast used for projecting the teleport distance
    RaycastHit2D projectionleft;
    RaycastHit2D projectionup;
    RaycastHit2D projectiondown;
    void Start () {

        temprangeright = shiftrange;         // Sets temprange to default teleport distance (shiftrange)
        temprangeleft = shiftrange;
        temprangeup = shiftrange;
        temprangedown = shiftrange;
    }


    void Update()
    {

        position = transform.position;  //sets "position" as transform.position (character's position)


        //Creates 4 rays: to right, left, up and down
        
        projectionright = Physics2D.Raycast(position, Vector2.right, temprangeright);     
        Debug.DrawRay(position, new Vector2(temprangeright, 0), Color.black);

        projectionleft = Physics2D.Raycast(position, Vector2.left, temprangeleft);
        Debug.DrawRay(position, new Vector2(-temprangeleft, 0), Color.black);

        projectionup = Physics2D.Raycast(position, Vector2.up, temprangeup);
        Debug.DrawRay(position, new Vector2(0, temprangeup), Color.black);

        projectiondown = Physics2D.Raycast(position, Vector2.down, temprangedown);
        Debug.DrawRay(position, new Vector2(0, -temprangedown), Color.black);


       
        
        
        if (projectionright.collider != null) //When the raycast hits a collider
        {
            Debug.Log("hitright");          //Console shows that the ray hit a collider
            Debug.Log(projectionright.point);    //Console shows where the ray the collider
            temprangeright = projectionright.distance;    //Sets temprange as the distance between the ray source(character) and the collision point

        }
        
        else if (projectionleft.collider != null) //When the raycast hits a collider
        {
            Debug.Log("hitleft");          //Console shows that the ray hit a collider
            Debug.Log(projectionleft.point);    //Console shows where the ray the collider
            temprangeleft = projectionleft.distance;    //Sets temprange as the distance between the ray source(character) and the collision point

        }

        else if (projectionup.collider != null) //When the raycast hits a collider
        {
            Debug.Log("hitup");          //Console shows that the ray hit a collider
            Debug.Log(projectionup.point);    //Console shows where the ray the collider
            temprangeup = projectionup.distance;    //Sets temprange as the distance between the ray source(character) and the collision point

        }

        else if (projectiondown.collider != null) //When the raycast hits a collider
        {
            Debug.Log("hitdown");          //Console shows that the ray hit a collider
            Debug.Log(projectiondown.point);    //Console shows where the ray the collider
            temprangedown = projectiondown.distance;    //Sets temprange as the distance between the ray source(character) and the collision point

        }

        else    //If the ray does not hit a collider
        {
            temprangeright = shiftrange;    //Resets the temprange to the default teleport distance (shiftrange)
            temprangeleft = shiftrange;
            temprangeup = shiftrange;
            temprangedown = shiftrange;
        }


        //TELEPORTING TO THE RIGHT

        if (Input.GetKey(KeyCode.RightArrow))   //When right arrow key is held down
         {
            Time.timeScale = 0.3f;  //Slows down time when arrow key is held down

            if (Input.GetKeyDown(KeyCode.LeftShift))    //Press shift to teleport
            {
                transform.Translate(new Vector2(temprangeright, 0f));    //Teleports the character by the teleport distance (temprange)
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))     //When right arrow key is released
        {
            Time.timeScale = 1f;    //Time flows normally
        }



        //TELEPORTING TO THE LEFT
        
        if (Input.GetKey(KeyCode.LeftArrow))    //When left arrow key is held down
        {

            Time.timeScale = 0.3f;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.Translate(new Vector2(-temprangeleft, 0f));    //Teleports the character by the teleport distance (temprange)
            }
           
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))   //When left arrow key is released
        {
            Time.timeScale = 1f;
        }



        //TELEPORTING UPWARDS
        
        if (Input.GetKey(KeyCode.UpArrow))      //When up arrow key is held down
        {
            Time.timeScale = 0.3f;

            if (Input.GetKeyDown(KeyCode.LeftShift)) //Press shift to teleport
            {
                transform.Translate(new Vector2(0f, temprangeup));    //Teleports the character by the teleport distance (temprange)
            }
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))     //When up arrow key is released
        {
            Time.timeScale = 1f;
        }



        //TELEPORTING DOWNWARDS
        
        if (Input.GetKey(KeyCode.DownArrow))    //When down arrow key is held down
        {
            Time.timeScale = 0.3f;

            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                transform.Translate(new Vector2(0f, -temprangedown));    //Teleports the character by the teleport distance (temprange)
            }
            
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))   //When down arrow key is released
        {
            Time.timeScale = 1f;
        }

        
    } 
}
