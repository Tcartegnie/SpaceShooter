﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : Ship
{
	public ShipMovement Shipcontroller;

    // Update is called once per frame
    void Update()
    {
		float forwardInputValue = Input.GetAxis("Vertical");
		float horizontalInputValue = Input.GetAxis("Horizontal");

		Shipcontroller.CallLateralAndForardMove(forwardInputValue, horizontalInputValue);
		Shipcontroller.CallMouseAxisInput();

		if (!ShipState.IsGameover)
		{

			if (Input.GetMouseButtonUp(1))
			{
				if (Shipcontroller.ShipLanded)
				{
					Shipcontroller.LiftOff();
				}
				else
				{
					Shipcontroller.CallLanding();
				}
			}

			if (!Shipcontroller.ShipLanded)
			{

				Shipcontroller.CallAxisRotation();
				if (Input.GetKeyUp(KeyCode.LeftControl))
				{
					Shipcontroller.ChangeCamera();
				}

				if (Input.GetKey(KeyCode.LeftShift))
				{
					Shipcontroller.Booster();
				}
				else
				{
					Shipcontroller.UnBooste();
				}
				//GetDirectionPoint();

				Shipcontroller.MoveForwarde();
			}

			ShipState.ShieldCoolDownCompute();
		}

	}
}
