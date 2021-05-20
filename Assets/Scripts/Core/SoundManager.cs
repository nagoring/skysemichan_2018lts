using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skysemi.With.Core
{
    public class SoundManager : MonoBehaviour
    {
        //参考：http://hiyotama.hatenablog.com/entry/2015/06/10/090000
        public static SoundManager instance = null;
        public AudioSource efxSource;
        public AudioSource musicSource;

        //音の高さにバリエーションを付ける用の変数
        public float lowPitchRange = .95f;
        public float highPitchRange = 1.05f;

        private IEnumerator efxCoroutine;
	
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
		
            DontDestroyOnLoad (gameObject);
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
        public void PlaySingle(AudioClip clip)
        {
            efxSource.clip = clip;
            efxSource.Play();
        }

        public void StopMusic()
        {
            if (musicSource.clip != null)
            {
                musicSource.Stop();
            }
        }
        public void Stop()
        {
            if (efxSource.clip != null)
            {
                StopCoroutine(efxCoroutine);
                efxSource.Stop();
            }
        }
        public void PlaySingleRepeat(AudioClip clip, int number, float delayTime=0.3f)
        {
            efxSource.clip = clip;
            efxSource.Play();
            for (int i = 1; i < number; i++)
            {
                efxCoroutine = this.DelayMethod(delayTime, () =>
                {
                    efxSource.Play();
                }); 
                StartCoroutine(efxCoroutine);
            }
        }

        IEnumerator _DelayMethod(float delayTime)
        {
            return this.DelayMethod(delayTime, () =>
            {
                efxSource.Play();
            });
        }
        //数種類の効果音を受け取り、ランダムで再生
        public void RandomizeSfx (params AudioClip[] clips)
        {
            //受け取った効果音番号をランダムで指定
            int randomIndex = Random.Range(0, clips.Length);
            //音の高さをランダムで指定
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            //受け取った効果音を選択
            efxSource.clip = clips[randomIndex];
            //効果音を再生
            efxSource.Play();
        }	
	
        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
    
}


