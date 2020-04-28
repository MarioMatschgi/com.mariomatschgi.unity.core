using UnityEngine;
using MM.Extentions;

namespace MM.Attributes
{
    [AddComponentMenu("MM Core/MultiChoiceEnumTest")]
    public class MultipleChoiceEnumTestMonoBehaviour : MonoBehaviour
    {
        [MultipleChoiceEnum]
        public MultipleChoiceTestEnum testEnum;


        #region Callback Methodes
        /*
         *
         *  Callback Methodes
         * 
         */

        void Start()
        {
            foreach (MultipleChoiceTestEnum _item in testEnum.ReturnAllEnumValues())
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
