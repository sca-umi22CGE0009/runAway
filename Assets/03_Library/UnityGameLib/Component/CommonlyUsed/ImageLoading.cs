using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

namespace CommonlyUsed
{
    public static class ImageLoading 
    {
        /// <summary>
        /// �摜���w��̃t�H���_����ǂݍ��ފ֐�
        /// ����(Image �Ԃ����摜, string �摜������p�X,bool �����������)
        /// </summary>
        public static void ImageLoadingAsync(Image image, string imagePath, bool check = true)
        {
            if (check)
            {
                Addressables.LoadAssetAsync<Sprite>(imagePath).Completed += sprite =>
                {
                    image.sprite = Object.Instantiate(sprite.Result);
                    
                };
            }
        }
    }
}