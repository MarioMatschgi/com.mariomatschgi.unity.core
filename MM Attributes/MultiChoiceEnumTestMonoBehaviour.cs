using UnityEngine;
using MM.Extentions;

namespace MM.Attributes
{
    [AddComponentMenu("MM Core/MultiChoiceEnumTest")]
    public class MultiChoiceEnumTestMonoBehaviour : MonoBehaviour
    {
        [MultiChoiceEnum]
        public MultiChoiceTestEnum testEnum;


        #region Callback Methodes
        /*
         *
         *  Callback Methodes
         * 
         */

        void Start()
        {
            foreach (MultiChoiceTestEnum _item in testEnum.ReturnSelectedElements())
                Debug.Log("Enum value: " + _item);
        }

        void Update()
        {

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
