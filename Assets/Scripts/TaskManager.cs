using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TaskManager : MonoBehaviour {

    public enum Task {
        BOW, JUMP_ON_SPOT, NONE
    }

    private bool taskFailed = false;
    private LinkedList<Task> tasks = new LinkedList<Task>();


    //===================================================================
    // Set the event listener for the TaskManager to the correct methods
    //===================================================================

    void OnEnable() {
        Movement.OnBow += CheckBowTask;
        Movement.OnJumpOnSpot += CheckJumpOnSpotTask;
        Movement.OnRunningJump += CheckRunningJump;
    }

    void OnDisable() {
        Movement.OnBow -= CheckBowTask;
        Movement.OnJumpOnSpot -= CheckJumpOnSpotTask;
        Movement.OnRunningJump -= CheckRunningJump;
    }


    public void AddTask(Task task) {
        Debug.Log("Added Task " + task.ToString());
        tasks.AddLast(task);
    }

    public void ResetTasks() {
        tasks.Clear();
    }

    /// <summary>
    /// Check if the current task is to BOW, otherwise fail the current mission.
    /// </summary>
    private void CheckBowTask() {
        if (tasks.First != null && tasks.First.Value == Task.BOW) {
            tasks.RemoveFirst();
        } else {
            taskFailed = true;
        }
        Debug.Log("Mission Progress: Failed = " + IsTaskFailed());
    }

    /// <summary>
    /// Check if the current task is to JUMP ON SPOT, otherwise fail the current mission.
    /// </summary>
    private void CheckJumpOnSpotTask() {
        if(tasks.First != null && tasks.First.Value == Task.JUMP_ON_SPOT) {
            tasks.RemoveFirst();
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

}
