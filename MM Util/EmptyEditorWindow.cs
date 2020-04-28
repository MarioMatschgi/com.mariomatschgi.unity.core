using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MM.Util
{
    public class EmptyEditorWindow : EditorWindow
    {
        // Public static
        public static List<EmptyEditorWindow> windows { get; private set; }


        // Private
        EmptyEditorWindow currentWindow;


        #region Callback Methodes
        /*
         *
         *  Callback Methodes
         * 
         */

        /// <summary>
        /// Opens an empty EditorWindow as a placeholder in the UnityEditorGUILayout
        /// </summary>
        [MenuItem("Window/MM Core/EmptyEditorWindow")]
        public static void Open()
        {
            if (windows == null)
                windows = new List<EmptyEditorWindow>();

            EmptyEditorWindow _window = CreateInstance<EmptyEditorWindow>();
            _window.titleContent = new GUIContent("Empty EditorWindow");
            _window.currentWindow = _window;

            _window.Show();

            windows.Add(_window);
        }

        void OnDestroy()
        {
            windows.Remove(currentWindow);
        }

        #endregion

        #region Gameplay Methodes
        /*
         *
         *  Gameplay Methodes
         *
         */

        #endregion

        #region Helper Methodes
        /*
         *
         *  Helper Methodes
         * 
         */

        #endregion
    }
}
