using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowingState : BaseState
{

	public slowingState(PlayerStateMachine psm) : base("slowingState", psm) { }
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
		else if (!playerController.IsAPressed() && !playerController.IsDPressed())
		{
			playerController.acceleration = 2.0f;
			playerStateMachine.ChangeState(playerStateMachine.midState);
		}

	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		playerController.Move();

	}

}
