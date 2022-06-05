using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelaratingState : BaseState
{

	public accelaratingState(PlayerStateMachine psm) : base("Accelarating", psm) { }

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
		if (!playerController.IsDPressed() && !playerController.IsAPressed())
		{

			playerController.acceleration = 2.0f;
			playerStateMachine.ChangeState(playerStateMachine.midState);
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
