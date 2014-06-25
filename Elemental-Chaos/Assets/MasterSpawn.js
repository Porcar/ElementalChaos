#pragma strict

var spawnPoints : Transform[];
var randomPoints = false;

var unitPrefabs : GameObject[];
var randomUnits = false;

var waitTimeWave = 20;

var waitTimeMin = 2;
var waitTimeMax = 2;

static var enemyCounter = 0;

var spawnXOffsetMin = 0;
var spawnXOffsetMax = 0;

var spawnYOffsetMin = 0;
var spawnYOffsetMax = 0;

var spawnZOffsetMin = 0;
var spawnZOffsetMax = 0;

var defaultSpawnNumber = 5;

var maxWaves = 1;
var waveNumber = 1;
var isSpawning = true;

var enemyNumber = 0;


function SpawnEnemies()
{
	while((isSpawning) && (waveNumber <= maxWaves)){
	
	//	var spawnNum = (defaultSpawnNumber + 5 * (wave - 1)); //doubles number of enemies per wave
		var spawnNum = defaultSpawnNumber;
		yield WaitForSeconds(waitTimeWave);
	
		for(var i=0; i < spawnNum; i++)
		{
			yield WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));
		
		//Spawn random unit
		
	//	if(randomUnits == true)
	//	{
	//		var object : GameObject = unitPrefabs[Random.Range(0, unitPrefabs.Length)];
	//	}
	//	else
	//	{
			var object : GameObject = unitPrefabs[enemyNumber];
	//	}
	//	if(randomPoints == true)
	//	{		
			var position : Transform = spawnPoints[Random.Range(0, spawnPoints.Length)];
	//	}
	
			Instantiate(object, position.position + Vector3(Random.Range(spawnXOffsetMin,spawnXOffsetMax)
			,Random.Range(spawnYOffsetMin,spawnYOffsetMax) ,Random.Range(spawnZOffsetMin,spawnZOffsetMax)), position.rotation);			
		}
	
		enemyNumber++;
		waveNumber++;
		defaultSpawnNumber--;
	}

}

function Start () 
{

	SpawnEnemies();

}
