using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using UnityEngine;


public class WayEventParam {
	public string msg = "ファースト";
	public Player player;
	public Enemy enemy;

	public WayEventParam(Player player, Enemy enemy)
	{
		this.player = player;
		this.enemy = enemy;
	}
}
