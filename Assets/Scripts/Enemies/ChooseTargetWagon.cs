using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTargetWagon : MonoBehaviour {

    public TrainWagon CurrentTarget;

    public EnemyMove EnemyMove;
    public List<EnemyTurret> EnemyTurrets;

    private void Start() {
        ResetTarget();
        //when wagon dies event listener reset the target
        Train.Instance.OnWagonDeath.AddListener(ResetTarget);
    }

    public void ResetTarget() {

        CurrentTarget = Train.Instance.TrainWagons[Random.Range(0, Train.Instance.TrainWagons.Count)];


        if (CurrentTarget.IsActive == true) {
            foreach (EnemyTurret enemyTurret in EnemyTurrets) {
                enemyTurret._getTarget(CurrentTarget);
            }
            EnemyMove._getTarget(CurrentTarget);
        } 
        
        //else { ResetTarget(); }



    }

}
