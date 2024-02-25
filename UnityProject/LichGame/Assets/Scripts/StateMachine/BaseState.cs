using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState /*: MonoBehaviour*/
{
    public string nameState;
    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.nameState = name;
        this.stateMachine = stateMachine;
    }

    
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhisics() { }
    public virtual void Exit() { }

}
