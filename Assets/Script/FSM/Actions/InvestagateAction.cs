using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Investage")]
public class InvestagateAction : Action
{
    public override void Act(StateController controller)
    {
        if (!controller.bPrimaryStateActionFinished)
        {
            Investagate(controller);
        }
    }

    void Investagate(StateController contoller)
    {
        //call Investagation method, on Enitity script.
        //go within range of object to investage
            //set a bool / list as to not investagate the same object twice.
            //check what the thing is.
                //if player goto state X
                //if neutral and living goto state Y
                //if just a suspicioius object state  Z
    }
}
