/* enemyAi.js - Unity rpg combat system tutorial - www.Gameobject.net */
/* Author : Piffa of www.Gameobject.net */

#pragma strict
/* delcaring states to pass to player gameobject */
public var isAttacking : boolean = false ; 
public var enemyHealthPoints : int = 10 ; // Health pool for the enemy
public var enemyDamage : int = 1 ; // Damage dealt by enemy per hit

private var  playAnim : boolean = true ;

function Update () {
    if (playAnim){	//check if attack animation was played
        WaitSeconds(); //wait random seconds for animation
       }
//Destroy enemy if hp drops to zero and destroy it if so
	if(enemyHealthPoints < 0){
		Destroy(gameObject);
		Debug.Log("Enemy is Dead !!!");
		}
}

function WaitSeconds(){
	playAnim = false; 
    var randomWait = Random.Range(0, 6);              
    print ("Wait" + randomWait + " seconds"); //debug          
    yield WaitForSeconds(randomWait); //Wait a random amount of time  
    isAttacking = true ;  //set isAttacking state to true               
    animation.Play("attack"); //play attack animation
    yield WaitForSeconds(animation["attack"].length) ;//wait for animation duration
    isAttacking = false ;//set isAttacking state to false
    playAnim = true ; // detect when anim is complete
}

//Function to call when hit by player
function TakeDamage(dmg : int){
	enemyHealthPoints -= dmg ;
	Debug.Log("Enemy suffered " + dmg  +" damages");
}

