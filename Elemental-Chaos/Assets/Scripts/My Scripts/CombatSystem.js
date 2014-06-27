/* CombatSystem.js - Unity rpg combat system tutorial - www.Gameobject.net */
/* Author : Piffa of www.Gameobject.net */
#pragma strict
/* Declaring and inizializing private variables to define collisions states */
public var isTouching : boolean = false; // player is touching an enemy collider box
public var wasTouching : boolean = false;// player was touching an enemy collider box
public var isEngaged : boolean = false;  // player and enemy are engaged in combat
public var isHitting : boolean = false;  // player is landing an hit and dealing dmg
public var isHitted : boolean = false ; //  enemy is landing an hit to player
public var playerControllerScript : PlayerController ; //handle to access parent player gameobject
private var playerIsAttacking : boolean ; //read from Playercontroller.js if player is attacking
private var enemyIsAttacking : boolean ; //read from enemyAi.js if enemy is attacking
private var collidingEnemy : GameObject ; // reference to enemy gameobject we are colliding with
 
public var playerHealthPoints : int = 20 ; // player health pool
private var playerDamage : int = 2 ; // amount of damage dealt by player with 1 hit
 
function Start () {
playerControllerScript =  transform.parent.gameObject.GetComponent(PlayerController);
//Get the PlayerController script in our parent gameobject and store in a variable
}
 
function Update () {
/* player is engaged in combat if for the first time is touching the enemy's collider */
    if(!wasTouching && isTouching){
    isEngaged = true;   
    };   
/* player is not engaged anymore if was touching the enemy and now it's not anymore */
    if(wasTouching && !isTouching){
    isEngaged = false;  
    };
/* Store in a variable if the player is attacking */
    playerIsAttacking = playerControllerScript.isAttacking;
/* Store in a variable if the enemy is attacking */
    if(collidingEnemy){
        enemyIsAttacking = collidingEnemy.GetComponent(enemyAi).isAttacking;
    };
Debug.Log(enemyIsAttacking);
/* if player is attacking while engaged and in touch with the enemy apply damage 
to the enemy by calling its takedamage function via sendmessage */
    if(playerIsAttacking && isEngaged && isTouching){
        if(isHitting==false){
            isHitting=true;
            collidingEnemy.SendMessage("TakeDamage",playerDamage);
        }else if(!transform.parent.gameObject.animation.IsPlaying("attack")){
            isHitting=false;
        }
    }
/* if player is attacking while engaged and in touch with the enemy apply damage 
to the enemy by calling its takedamage function via sendmessage */
    if(enemyIsAttacking && isEngaged && isTouching){
        if(isHitted==false){
            isHitted=true;
            TakeDamage(collidingEnemy.gameObject.GetComponent(enemyAi).enemyDamage);
        }
    }else if(!enemyIsAttacking){
            isHitted=false; //FIXARE PERCHE NON TORNA FALSE
        }
}
/* The above state machine logic it's needed to avoid to call the takedamage function every frame
that verify the if statement thus applying more than needed. This way the function is called just
once for every hit landed as it should. */
/* Check for collision with enemy and flag states appropriately */
function OnTriggerEnter(col : Collider) {
    if(col.gameObject.name =="demon"){
    wasTouching = isTouching;
    isTouching = true;
    collidingEnemy = col.gameObject;
    };
 }  
/* Check for collision with enemy and flag states appropriately */
function OnTriggerExit(col : Collider) {
    Debug.Log("Colliding with : " + col.gameObject.name);
    if(col.gameObject.name =="demon"){
    wasTouching = isTouching;
    isTouching = false;
    };
}
//Function to call when hit by enemy
function TakeDamage(dmg : int){
    playerHealthPoints -= dmg ;
    Debug.Log("Player suffered " + dmg  +" damages");
}