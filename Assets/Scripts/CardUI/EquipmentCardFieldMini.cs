using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Skysemi.With.Core;
using Skysemi.With.CardUI;

namespace Skysemi.With.CardUI
{
    public class EquipmentCardFieldMini : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/CardUI/EquipmentCardFieldMini";
        private readonly float[] _xTbl = {-50, 50, -50, 50};
        private readonly float[] _yTbl = {65, 65, -50, -50};
        public int SelectedCardBoxIndex { get; set; }
        public GameObject SelectedGameObjectCardBox { get; set; }
        public Image SelectedIconImage { get; set; }

        private EquipmentCardBoxMini[] _equipmentCardBoxs;
        
        public static EquipmentCardFieldMini CreateEquipmentCardFieldMiniInParentTransform(Transform parentTransform, float x = 0, float y = -125)
        {
            GameObject obj = (GameObject)Resources.Load (PrefabPath);
            obj.SetActive(true);
            // プレハブを元にEquipmentCardFieldMiniを生成して、CanvasUIの子供にする
            GameObject instance = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
            Debug.Log(instance);
            instance.transform.parent = parentTransform;
            instance.transform.localScale = new Vector3(1,1,1);
            instance.transform.localPosition = new Vector3(x, y, 0);
            return instance.GetComponent<EquipmentCardFieldMini>();
        }

        /// <summary>
        /// 空のボックスを生成する
        /// インデックス番号は1,2,3,4まで使用できる
        /// </summary>
        /// <param name="index">インデックス番号</param>        
        /// <param name="types">動的に使いするスクリプトの配列</param>        
        public void CreateEquipmentCardBoxMini(int index, Type[] types = null)
        {
            string prefabFilePath = "Prefabs/CardUI/EquipmentCardBoxMini" + index;
            GameObject actionCardPrefab = (GameObject)Resources.Load(prefabFilePath);
            GameObject instance = (GameObject)Instantiate(actionCardPrefab,Vector2.zero,Quaternion.identity);
            instance.name = "EquipmentCardBoxMini" + index;
            instance.transform.parent = transform;
            instance.transform.localScale = new Vector3(1,1,1);
            float x = _xTbl[index];
            float y = _yTbl[index];
            instance.transform.localPosition = new Vector3(x, y, 0);
            if (types != null)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    instance.AddComponent(types[i]);
                }
            }
            Type equipmentCardBoxType = Type.GetType("Skysemi.With.CardUI.EquipmentCardBoxMini");
            instance.AddComponent(equipmentCardBoxType);
            _equipmentCardBoxs[index] = instance.GetComponent<EquipmentCardBoxMini>();
        }

        public void Equip(int index, ActionCards.ABase actionCard)
        {
            EquipmentCardBoxMini equipmentCardBox = _equipmentCardBoxs[index];
            equipmentCardBox.Equip(actionCard);
            GameObject childGameObject = _equipmentCardBoxs[index].transform.Find("ImageInvisibleSprite").gameObject;
            Sprite sprite = Resources.Load<Sprite>(equipmentCardBox.GetImageFilePath());
            Image childImage = childGameObject.GetComponent<Image>();
            childImage.sprite = sprite;
            childImage.SetAlpha( 1.0f );
        }

        public EquipmentCardBoxMini[] GetEquipmentCardBoxs()
        {
            return _equipmentCardBoxs;
        }
        public void Init()
        {
            Type[] types = {
//                Type.GetType("Skysemi.With.CardUI.PlayerEquipmentCardBoxClickEvent"),
            };
            
            _equipmentCardBoxs = new EquipmentCardBoxMini[4];
            CreateEquipmentCardBoxMini(0, types);
            CreateEquipmentCardBoxMini(1, types);
            CreateEquipmentCardBoxMini(2, types);
            CreateEquipmentCardBoxMini(3, types);
        }
    }
}

