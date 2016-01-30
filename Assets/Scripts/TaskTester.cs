using UnityEngine;
using System.Collections;

public class TaskTester : MonoBehaviour {

    public TaskManager taskManager;

    void Awake() {
        GameStateTracker.SetGameStateChangeRule(new TutorialGameStateRule());
    }
    
	// Use this for initialization
	void Start () {
        taskManager.ResetTasks();
        taskManager.AddTask(TaskManager.Task.BOW);
        taskManager.AddTask(TaskManager.Task.BOW);
        taskManager.AddTask(TaskManager.Task.BOW);
        taskManager.AddTask(TaskManager.Task.JUMP_ON_SPOT);
    }
	
}
