using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JSON_Practice
{
    public class CellRendererJson : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _amount;

        public void UpdateInfo(JsonObject js)
        {
            _image.sprite = js.GetIcon();
            _amount.text = js.GetCountSize().ToString();
        }
    }
}