using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TaskManager : MonoBehaviour {

	public enum Task {
		BOW, JUMP_ON_SPOT
	}

	private bool taskFailed = false;
	private LinkedList<Task> tasks = new LinkedList<Task>();
	private LinkedList<Task> tasksLeft = new LinkedList<Task>();

	public LinkedList<Task> getCurrentTasks() {
		LinkedList<Task> list = new LinkedList<Task>();
		foreach (Task t in tasks) {
			list.AddLast(t);
		}
		return list;
	}

    //===================================================================
    // Set the event listener for the TaskManager to the correct methods
    //===================================================================

    void OnEnable() {
		UserDogMovement.OnBow += CheckBowTask;
		UserDogMovement.OnJumpOnSpot += CheckJumpOnSpotTask;
		UserDogMovement.OnRunningJump += CheckRunningJump;
    }

    void OnDisable() {
		UserDogMovement.OnBow -= CheckBowTask;
		UserDogMovement.OnJumpOnSpot -= CheckJumpOnSpotTask;
		UserDogMovement.OnRunningJump -= CheckRunningJump;
    }


    public void AddTask(Task task) {
		Debug.Log("Added Task " + task.ToString());
		tasks.AddLast(task);
		tasksLeft.AddLast(task);
	}

	public void RestartTasks() {
		taskFailed = false;
		tasksLeft.Clear ();
		foreach (Task t in tasks) {
			tasksLeft.AddLast(t);
		}
	}
	
	public void ResetTasks() {
		tasks.Clear();
		tasksLeft.Clear();
	}
	
	/// <summary>
    /// Check if the current task is to BOW, otherwise fail the current mission.
    /// </summary>
    private void CheckBowTask() {
        if (tasksLeft.First != null && tasksLeft.First.Value == Task.BOW) {
            tasksLeft.RemoveFirst();
        } else {
            taskFailed = true;
        }
        Debug.Log("Mission Progress: Failed = " + IsTaskFailed());
    }

    /// <summary>
    /// Check if the current task is to JUMP ON SPOT, otherwise fail the current mission.
    /// </summary>
    private void CheckJumpOnSpotTask() {
        if(tasksLeft.First != null && tasksLeft.First.Value == Task.JUMP_ON_SPOT) {
            tasksLeft.RemoveFirst();
        } else {
            taskFailed = true;
        }
        Debug.Log("Mission Progress: Failed = " + IsTaskFailed());
    }

    private void CheckRunningJump() {
        taskFailed = true;
        Debug.Log("Mission Failed due to Premature Jumping");
    }

    /// <summary>
    /// The total objective is failed when the wrong task is performed or when the player chooses to perform more than the asked tasks.
    /// </summary>
    /// <returns></returns>
    public bool IsTaskFailed() {
        return taskFailed;
    }

	public bool IsMissionComplete() {
		Debug.Log("Mission complete: " + (!taskFailed && tasksLeft.Count == 0));
		return !taskFailed && tasksLeft.Count == 0;
	}

}
