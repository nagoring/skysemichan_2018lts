using System;
using Skysemi.With.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
    public class EquipmentCardField : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/CardUI/EquipmentCardField";
        private readonly float[] _xTbl = {-300, -100, 100, 300};
        public int SelectedCardBoxIndex { get; set; }
        public GameObject SelectedGameObjectCardBox { get; set; }
        public Image SelectedIconImage { get; set; }

//        private float _x = -240;   
//        private float _y = -300; 
//        private float _width = 800; 
//        private float _height = 200; 
//        private float _scale = 1;
        private EquipmentCardBox[] _equipmentCardBoxs;

        void Start()
        {
        }
        public static EquipmentCardField CreateEquipmentCardFieldInCanvas(Canvas canvasUi, float x = -240, float y = -300)
        {
            GameObject obj = (GameObject)Resources.Load (PrefabPath);
            obj.SetActive(true);
            // プレハブを元にEquipmentCardFieldを生成して、CanvasUIの子供にする
            GameObject instance = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
            instance.transform.parent = canvasUi.transform;
            instance.transform.localScale = new Vector3(1,1,1);
            instance.transform.localPosition = new Vector3(x, y, 0);
            return instance.GetComponent<EquipmentCardField>();
        }

        /// <summary>
        /// 空のボックスを生成する
        /// インデックス番号は1,2,3,4まで使用できる
        /// </summary>
        /// <param name="index">インデックス番号</param>        
        /// <param name="types">動的に使いするスクリプトの配列</param>        
        public void CreateEquipmentCardBox(int index, Type[] types = null)
        {
            string prefabFilePath = "Prefabs/CardUI/EquipmentCardBox" + index;
            GameObject actionCardPrefab = (GameObject)Resources.Load(prefabFilePath);
            GameObject instance = (GameObject)Instantiate(actionCardPrefab,Vector2.zero,Quaternion.identity);
            instance.name = "EquipmentCardBox" + index;
            instance.transform.parent = transform;
            instance.transform.localScale = new Vector3(1,1,1);
            float x = _xTbl[index];
            instance.transform.localPosition = new Vector3(x, 0, 0);
            if (types != null)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    instance.AddComponent(types[i]);
                }
            }
            Type equipmentCardBoxType = Type.GetType("Skysemi.With.CardUI.EquipmentCardBox");
            instance.AddComponent(equipmentCardBoxType);
            _equipmentCardBoxs[index] = instance.GetComponent<EquipmentCardBox>();
        }
        public void Init()
        {

            Type[] types = {
                Type.GetType("Skysemi.With.CardUI.PlayerEquipmentCardBoxClickEvent"),
            };
            
            _equipmentCardBoxs = new EquipmentCardBox[4];
            CreateEquipmentCardBox(0, types);
            CreateEquipmentCardBox(1, types);
            CreateEquipmentCardBox(2, types);
            CreateEquipmentCardBox(3, types);
        }

        public void Equip(int index, ActionCards.ABase actionCard)
        {
            EquipmentCardBox equipmentCardBox = _equipmentCardBoxs[index];
            equipmentCardBox.Equip(actionCard);
//            GameObject childGameObject = _equipmentCardBoxs[index].transform.GetChild(0).gameObject;
            GameObject childGameObject = _equipmentCardBoxs[index].transform.Find("ImageInvisibleSprite").gameObject;
//            GameObject instance = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/Image/MagicAddMaxHp"),Vector2.zero,Quaternion.identity);
            ;
//            GameObject newGameObject = new GameObject();
//            childGameObject.transform.parent = transform;
//            GameObject newGameObject = (GameObject)gameObject.AddComponent(_equipmentCardBoxs[index]);
//            ;
//            Texture2D tex2d = Resources.Load(equipmentCardBox.GetImageFilePath()) as Texture2D;
            Sprite sprite = Resources.Load<Sprite>(equipmentCardBox.GetImageFilePath());
//            SelectedIconImage.sprite =  Sprite.Create(tex2d, new Rect(0,0,tex2d.width,tex2d.height), Vector2.zero);;
//            GameObject childGameObject = _equipmentCardBoxs[SelectedCardBoxIndex].transform.GetChild(0).gameObject;
//            GameObject childGameObject = SelectedGameObjectCardBox.transform.GetChild(0).gameObject;
//            Image childImage = childGameObject.GetComponentInChildren<Image>();
            Image childImage = childGameObject.GetComponent<Image>();
//            Image childImage = image.gameObject.GetComponentInChildren<Image>();
            
//            Image image = actionCard.gameObject.GetComponent<Image>();
//            childImage = Instantiate(image);
//            sprite. = new Rect(0,0,200,200);
//            childImage.sprite =  sprite;
            ;
//            childImage.sprite =  Sprite.Create(tex2d, new Rect(0,0,tex2d.width,tex2d.height), Vector2.zero);
//            childImage.sprite =  actionCard.gameObject.GetComponent<Image>().sprite;
            childImage.sprite = sprite;
//            childImage.sprite.pivot = new Vector2(200,200);
//            childImage.sprite.textureRectOffset()
//            Debug.Log(childImage.sprite.pivot);
//            childImage.rectTransform.sizeDelta = new Vector2(300,300);
//            childImage.rectTransform.localScale = new Vector3(1,1,1);
//            childImage.transform.localScale = new Vector3(1,1,1);
            
            childImage.SetAlpha( 1.0f );
//            childImage.preserveAspect = true;
//            childImage.SetNativeSize();
//            Debug.Log(tex2d.width+":"+tex2d.height);
//            GameObject child = transform.Find("BoardArea" + index).gameObject;
//            child.SetActive(true);
//            Image childImage = child.GetComponent<Image>();
//            childImage.sprite = Sprite.Create(tex2d, new Rect(0,0,tex2d.width,tex2d.height), Vector2.zero);;
            //			Image image = new Image();
//			Instantiate();

            ;
            
//            obj.GetComponent()
        }

        public EquipmentCardBox[] GetEquipmentCardBoxs()
        {
            return _equipmentCardBoxs;
        }
    }
}