using System;
using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public Game game;
	public GameObject buttonGoFront;
	public GameObject btnNavigationWindow;
	public GameObject btnBattleFlow;
	public GameObject  panelActionCommandSelect;
	public GameObject[] btnActionCommands = new GameObject[4];
	
	
	//シングルトンの処理
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
	}
	
	// Use this for initialization
	void Start ()
	{
//		SetActionComanndInteractable(EActionCommandActive.CMD1);
	}

	void Update () {
	}
//	public void PushGoFrontButton()
//	{
//		if (game.mode == EMode.BOSS_BATTLE_AFTER) return;
//		if (GameSystem.instance.destinationPlace == EStage.OTHER_STAGE1)
//		{
//			SoundManager.instance.PlaySingle(game.clipSoundWalking);
//		}
//
//		
//		
//		
//		Player player = Player.instance;
//		player.Progress++;
//
//		int landIndex = player.Progress % 3;
//		game.loadLayer.sprite = game.imageRoads[landIndex];
//		game.playerManager.textProgress.text = player.Progress.ToString();
//		Player.instance.NaturalHealingByWalk();
//		game.CheckingProgress();
//	}
//	public void EncountEnemeyBegin(WayEventParam param) {
//		if (game.mode != EMode.BATTLE) return;
//		//GoFrontButton stop
//		buttonGoFront.SetActive(false);
//		//ActionCommand Begin
//
//		//ナビゲーションウィンドウの作成
//		btnNavigationWindow.SetActive(true);
//		Text navText = btnNavigationWindow.GetComponentInChildren<Text>();
//		navText.text = param.enemy.msg;
//		navText.color = new Color(255, 0, 0);
//
//		//攻撃用の戦闘の進行ボタンを作成
//		btnBattleFlow.SetActive(true);
//		game.turn = ETurn.PLAYER;
//	}
//	public void EncountEnemeyEnd(BattleEndEventParam param) {
//		//GoFrontButton Begin
//		buttonGoFront.SetActive(true);
//		//ActionCommand End
//		btnNavigationWindow.SetActive(false);
//		btnBattleFlow.SetActive(false);
//	}
//
//	private void SetActionComanndInteractable(EActionCommandActive eActionCommandActive)
//	{
//		Player.instance.eActionCommandActive = eActionCommandActive;
//		PlayerManager playerManager = GameMainManager.instance.playerManager;
//		
//		
//		
//		
//	}
//	public void PushActionCommand1()
//	{
//		SetActionComanndInteractable(EActionCommandActive.CMD1);
//		panelActionCommandSelect.SetActive(!panelActionCommandSelect.activeSelf);
//	}
//	public void PushActionCommand2()
//	{
//		SetActionComanndInteractable(EActionCommandActive.CMD2);
//		panelActionCommandSelect.SetActive(!panelActionCommandSelect.activeSelf);
//	}
//	public void PushActionCommand3()
//	{
//		SetActionComanndInteractable(EActionCommandActive.CMD3);
//		panelActionCommandSelect.SetActive(!panelActionCommandSelect.activeSelf);
//	}
//	public void PushActionCommand4()
//	{
//		SetActionComanndInteractable(EActionCommandActive.CMD4);
//		panelActionCommandSelect.SetActive(!panelActionCommandSelect.activeSelf);
//	}
//	///【機能】 ボタン状態による色変更
//	///【第一引数】色を変更したいボタン
//	///【第二引数】変更したい色（new Color(float a,floar b,float c,float d))
//	///【第三引数】色を変更したい状態（0:normalColor 1:highlightedColor 2:pressedColor 3:disabledColor）
//	public static void BtnStateColorChange(Button btn,Color color,int changeState)
//	{
//		ColorBlock cbBtn = btn.colors;
//		switch (changeState)
//		{
//			case 0://normalColor
//				cbBtn.normalColor = color;
//				break;
//			case 1://highlightedColor
//				cbBtn.highlightedColor = color;
//				break;
//			case 2://pressedColor
//				cbBtn.pressedColor = color;
//				break;
//			case 3://disabledColor
//				cbBtn.disabledColor = color;
//				break;
//		}
//		btn.colors = cbBtn;
//	}
//
//	public void ShowActionCommandArea(Player player)
//	{
//		
//		
//		
//		if (player.Lv >= 10)
//		{
//			PlayerManager.instance.metalBat.SetActive(true);
//			PlayerManager.instance.strongPanch.SetActive(true);
//			PlayerManager.instance.strongShield.SetActive(true);
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			PlayerManager.instance.pan.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//			btnActionCommands[3].SetActive(true);
//		}
//		if (player.Lv >= 9)
//		{
//			PlayerManager.instance.strongPanch.SetActive(true);
//			PlayerManager.instance.strongShield.SetActive(true);
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			PlayerManager.instance.pan.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//			btnActionCommands[3].SetActive(true);
//		}
//		else if (player.Lv >= 7)
//		{
//			PlayerManager.instance.strongPanch.SetActive(true);
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			PlayerManager.instance.pan.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//			btnActionCommands[3].SetActive(true);
//		}
//		else if (player.Lv >= 6)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			PlayerManager.instance.pan.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//			btnActionCommands[3].SetActive(true);
//		}
//		else if (player.Lv >= 5)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			PlayerManager.instance.pan.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//		}
//		else if (player.Lv >= 4)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			PlayerManager.instance.magic.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//		}
//		else if (player.Lv >= 3)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//			btnActionCommands[2].SetActive(true);
//		}
//		else if (player.Lv >= 2)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//		}
//		else if (player.Lv >= 1)
//		{
//			PlayerManager.instance.shield.SetActive(true);
//			btnActionCommands[1].SetActive(true);
//		}
//		
//		GameSystem gs = GameSystem.instance;
//		if (gs.progress >= (int) EGameProgress.SHOW_STAGE_4)
//		{
//			PlayerManager.instance.roboBlade.SetActive(true);
//		}
//		
//		
//	}

}




