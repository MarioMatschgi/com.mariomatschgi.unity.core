using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace MM
{
    namespace Helper
    {
        public static class ImageHelperMethodes
        {
#if UNITY_EDITOR
            /// <summary>
            /// Gets a Texture2D at project root path
            /// </summary>
            /// <param name="_filePath"></param>
            /// <returns></returns>
            public static Texture2D LoadPngEditor(string _filePath)
            {
                return (Texture2D)AssetDatabase.LoadAssetAtPath(_filePath, typeof(Texture2D));
            }
#endif

            public static Texture2D LoadPng(string _filePath)
            {
                Texture2D tex = null;
                byte[] fileData;

                if (File.Exists(_filePath))
                {
                    fileData = File.ReadAllBytes(_filePath);
                    tex = new Texture2D(2, 2);
                    tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                }

                return tex;
            }
        }
    }
}