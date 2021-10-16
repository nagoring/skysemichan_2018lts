using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Skysemi.With.Scenes.WorldObject
{
    public class EffectManager : MonoBehaviour {
        public static EffectManager instance = null;
        // public World world;
        public GameObject imageEffectScreen;
        public Text text;
        public GameObject attackEffect1;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start () {
        }
	
        // Update is called once per frame
        void Update () {
        }
        public IEnumerator attackPunchAnimation()
        {
            World world = World.instance;
            GameObject damageEffect = Instantiate(attackEffect1);
            damageEffect.SetActive(true);
            damageEffect.transform.SetParent(world.enemeyLayer.transform, false);

            float animationFrame = 0.05f;
            float[][] animTbl =  {
                new float[] { 70.0f, 70.0f },
                new float[] { 70.0f, -70.0f },
                new float[] { -70.0f, -20.0f },
            };
            //攻撃回数
            int attackNumber = 1;
            for (int j = 0; j <= attackNumber; j++)
            {
                for (int i = 0; i < animTbl.Length; i++)
                {
                    float x = animTbl[i][0];
                    float y = animTbl[i][1];
                    damageEffect.transform.localPosition = new Vector3(x, y);
                    yield return new WaitForSeconds((float)animationFrame);

                }
            }
            Destroy(damageEffect);
        }
        public IEnumerator attackAnimationNormalByEnemy() {
            imageEffectScreen.SetActive(true);
            Image image = imageEffectScreen.GetComponent<Image>();
            float[] alphaTbl = new float[2] {0.5f, 0 };
            float animationFrame = 0.15f;
            //攻撃回数
            int attackNumber = 3;
            for (int j = 0; j <= attackNumber; j++)    
            {
                float alpha = alphaTbl[j % 2];
                // image.color =  new Color(1.0f, 1.0f, 1.0f, alpha);
                image.color =  new Color(0.5f, 0f, 0f, alpha);
                yield return new WaitForSeconds((float)animationFrame);
            }
            imageEffectScreen.SetActive(false);
        }
    }
}