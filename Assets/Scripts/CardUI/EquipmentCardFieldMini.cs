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

        private EquipmentCardBoxMiniUi[] _equipmentCardBoxUis;
        /// <summary>
        /// 装備しているActionCard
        /// </summary>
        private ActionCards.ABase[] _actionCard = new ActionCards.ABase[4];
        public static EquipmentCardFieldMini CreateEquipmentCardFieldMiniInParentTransform(Transform parentTransform, float x = 0, float y = -125)
        {
            GameObject obj = (GameObject)Resources.Load (PrefabPath);
            obj.SetActive(true);
            // プレハブを元にEquipmentCardFieldMiniを生成して、CanvasUIの子供にする
            GameObject instance = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
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
            string prefabFilePath = "Prefabs/CardUI/EquipmentCardBoxMiniUi" + index;
            GameObject actionCardPrefab = (GameObject)Resources.Load(prefabFilePath);
            GameObject instance = (GameObject)Instantiate(actionCardPrefab,Vector2.zero,Quaternion.identity);
            instance.name = "EquipmentCardBoxMiniUi" + index;
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
            Type equipmentCardBoxType = Type.GetType("Skysemi.With.CardUI.EquipmentCardBoxMiniUi");
            instance.AddComponent(equipmentCardBoxType);
            _equipmentCardBoxUis[index] = instance.GetComponent<EquipmentCardBoxMiniUi>();
        }

        public void Equip(int index, ActionCards.ABase actionCard)
        {
            actionCard.Init();
            string prefabFilePath = actionCard.GetPrefabFilePath();
            GameObject actionCardPrefab = (GameObject)Resources.Load(prefabFilePath);
            GameObject instance = (GameObject)Instantiate(actionCardPrefab,Vector2.zero,Quaternion.identity);
            
            EquipmentCardBoxMiniUi equipmentCardBox = _equipmentCardBoxUis[index];
            // CardBoxにChildオブジェクトを全て削除
            foreach (Transform n in equipmentCardBox.gameObject.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
//            equipmentCardBox.Equip(actionCard);
//            int atk = equipmentCardBox.GetActionCard().Atk;
            int atk = actionCard.Atk;
            instance.transform.parent = equipmentCardBox.transform;
            instance.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            instance.transform.localPosition = new Vector3(0, 0, 0);

//            GameObject childGameObject = _equipmentCardBoxUis[index].transform.Find("ImageInvisibleSpriteMini").gameObject;
//            Sprite sprite = Resources.Load<Sprite>(equipmentCardBox.GetImageFilePath());
//            Image childImage = childGameObject.GetComponent<Image>();
//            childImage.sprite = sprite;
//            childImage.SetAlpha( 1.0f );
        }

        public void Init()
        {
            Type[] types = {
//                Type.GetType("Skysemi.With.CardUI.PlayerEquipmentCardBoxClickEvent"),
            };
            _equipmentCardBoxUis = new EquipmentCardBoxMiniUi[4];
            CreateEquipmentCardBoxMini(0, types);
            CreateEquipmentCardBoxMini(1, types);
            CreateEquipmentCardBoxMini(2, types);
            CreateEquipmentCardBoxMini(3, types);
        }

        public ActionCards.ABase GetActionCard(int index)
        {
            return _actionCard?[index];
        }
    }
}

