using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midState : BaseState
{

	public midState(PlayerStateMachine psm) : base("midState", psm) { }
	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void UpdateLogic()
	{
		base.UpdateLogic();
		if (playerController.IsDPressed())
		{
			playerController.acceleration = 5.0f;
			playerStateMachine.ChangeState(playerStateMachine.accelaratingState);
		}
		else if (playerController.IsAPressed())
		{
			playerController.acceleration = 5.0f;
			playerStateMachine.ChangeState(playerStateMachine.slowingState);
		}

	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		playerController.Move();
		
	}

}
