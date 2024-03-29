﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Skysemi.With.ActionCards;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
    public class CardBoardScrollView : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/CardUI/CardBoardScrollView";
        // private Card[] _cardArray;
        private List<Card> _cardList = new List<Card>();


        public static CardBoardScrollView CreateCardBoardInCanvasUI(Canvas canvasUI)
        {
            GameObject obj = (GameObject) Resources.Load(PrefabPath);
            obj.SetActive(true);
            // プレハブを元にCardBoardを生成して、CanvasUIの子供にする
            GameObject instance = (GameObject) Instantiate(obj, Vector2.zero, Quaternion.identity);
            instance.transform.SetParent(canvasUI.transform);
            instance.transform.localScale = new Vector3(1, 1, 1);
            instance.transform.localPosition = new Vector3(-241, 95, 0);
            return instance.GetComponent<CardBoardScrollView>();
        }

        // Start is called before the first frame update
//         public void SetCard(int index, ActionCards.ABase actionCard, Type type = null)
//         {
//             SetCardOnBoard(index, actionCard, type);
// //            this.SetCardImage(index, actionCard);
//             _cardArray[index] = new Card();
//             _cardArray[index].Init(index, actionCard);
//         }

        public void AddCard(ActionCards.ABase actionCard, Type type = null)
        {
            SetCardOnBoard(actionCard, type);
            Card card = new Card();
            card.Init(actionCard);
            _cardList.Add(card);
            // _cardArray[index].Init(index, actionCard);
            
        }

        // public ABase GetActionCard(int index)
        // {
        //     // return _cardArray[index].GetActionCard();
        //     return _cardArray[index].GetActionCard();
        // }
        //
        // public Card GetCard(int index)
        // {
        //     return _cardArray[index];
        // }


        private void SetCardOnBoard(ActionCards.ABase actionCard, Type type = null)
        {
            string prefabFilePath = actionCard.GetPrefabFilePath();
            GameObject actionCardPrefab = (GameObject) Resources.Load(prefabFilePath);
            // GameObject instance = (GameObject) Instantiate(actionCardPrefab, Vector2.zero, Quaternion.identity);
            GameObject instance = (GameObject) Instantiate(actionCardPrefab, Vector2.zero, Quaternion.identity);
            GameObject content = GameObject.FindWithTag("CardBoardContent");
            
            // instance.name = "BoardArea" + index;
            // instance.transform.parent = transform;
            // instance.transform.SetParent(transform);
            instance.transform.SetParent(content.transform);
            instance.transform.localScale = new Vector3(1, 1, 1);
            // float[] xy = _areaPositionTbl[index];
            // instance.transform.localPosition = new Vector3(xy[0], xy[1], 0);
            if (type != null)
            {
                //動的にスクリプトを入れる
                instance.AddComponent(type);
            }
        }

        private void SetCardImage(int index, ActionCards.ABase card)
        {
            string filepath = card.GetImageFilePath();
            Texture2D tex2d = Resources.Load(filepath) as Texture2D;
            GameObject child = transform.Find("BoardArea" + index).gameObject;
            child.SetActive(true);
            Image childImage = child.GetComponent<Image>();
            childImage.sprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
            ;
            // material.mainTextureは何故かすべてのBoardArea[0-9]{1,2}が同じものに変わってしまう
//            GameObject child = transform.Find("BoardArea2").gameObject;
//            Image image = child.GetComponent<Image>();
//            childImage.material.mainTexture = tex2d;
        }

        public void Init()
        {
            // _cardArray = new Card[12];
            GameObject obj = new GameObject();
            Type type = Type.GetType("Skysemi.With.CardUI.PlayerClickCardOnBoardEvent");
            AddCard(obj.AddComponent<Punch>(), type);
            AddCard(obj.AddComponent<StrongPunch>(), type);
            AddCard(obj.AddComponent<Shield>(), type);
            AddCard(obj.AddComponent<MagicAddMaxHp>(), type);
            AddCard(obj.AddComponent<MetalBat>(), type);
            AddCard(obj.AddComponent<Pan>(), type);
            AddCard(obj.AddComponent<StrongShield>(), type);
            AddCard(obj.AddComponent<RoboBlade>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            AddCard(obj.AddComponent<NasuHeart>(), type);
            // SetCard(0, obj.AddComponent<Punch>(), type);
            // SetCard(1, obj.AddComponent<StrongPunch>(), type);
            // SetCard(2, obj.AddComponent<Shield>(), type);
            // SetCard(3, obj.AddComponent<MagicAddMaxHp>(), type);
            // SetCard(4, obj.AddComponent<MetalBat>(), type);
            // SetCard(5, obj.AddComponent<Pan>(), type);
            // SetCard(6, obj.AddComponent<StrongShield>(), type);
            // SetCard(7, obj.AddComponent<RoboBlade>(), type);
            // SetCard(8, obj.AddComponent<NasuHeart>(), type);
            // SetCard(9, obj.AddComponent<Pan>(), type);
            // SetCard(10, obj.AddComponent<Pan>(), type);
            // SetCard(11, obj.AddComponent<Pan>(), type);
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void Awake()
        {
        }

        void OnEnable()
        {
        }
    }
}