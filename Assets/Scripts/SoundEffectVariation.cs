using UnityEngine;

namespace Assets.Scripts
{
    public class SoundEffectVariation : MonoBehaviour
    {
        public AudioClip[] ClipArray;
        public AudioSource EffectSource;
        public float PitchMin = 0.8f, PitchMax = 1.2f, VolumeMin = 0.8f, VolumeMax = 1f;

        private int _clipIndex;

        private void Update()
        {
            if (Input.GetButtonUp("Fire1")) PlayRoundRobin();
            if (Input.GetButtonUp("Fire2")) PlayRandom();
        }

        void PlayRoundRobin()
        {
            EffectSource.pitch = Random.Range(PitchMin, PitchMax);
            EffectSource.volume = Random.Range(VolumeMin, VolumeMax);
            if (_clipIndex >= ClipArray.Length)
            {
                _clipIndex = 0;
            }
            EffectSource.PlayOneShot(ClipArray[_clipIndex]);
            _clipIndex++;
        }

        void PlayRandom()
        {
            EffectSource.pitch = Random.Range(PitchMin, PitchMax);
            EffectSource.volume = Random.Range(VolumeMin, VolumeMax);
            _clipIndex = RepeatCheck(_clipIndex, ClipArray.Length);
            EffectSource.PlayOneShot(ClipArray[_clipIndex]);
        }

        int RepeatCheck(int previousIndex, int range)
        {
            // only one item
            if (range <= 1)
            {
                return previousIndex;
            }

            int index = Random.Range(0, range);
            while (index == previousIndex)
            {
                index = Random.Range(0, range);
            }
            return index;
        }
    }
}