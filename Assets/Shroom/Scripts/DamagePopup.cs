using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isHeal)
    {
        Transform danagePopupTransform = Instantiate(GameAssets.I.PfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = danagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isHeal);

        return damagePopup;
    }
    private TextMeshPro _textMesh;
    private static int _sortingOrder;

    private float _disappearTimer;
    private Color _textColor;
    private Vector3 _moveVector;

    private const float DISAPPEAR_TIMER_MAX = 1f;

    private void Awake()
    {
        _textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount, bool isHeal)
    {
        if(!isHeal) _textColor = Color.red;

        else _textColor = Color.green;


        _textMesh.SetText(damageAmount.ToString());

        _textMesh.fontSize = 8;

        _textMesh.color = _textColor;
        _disappearTimer = 0.8f;

        _moveVector = new Vector3(1f, 3f, 0f) * 5f;

        _sortingOrder++;
        _textMesh.sortingOrder = _sortingOrder;

    }

    private void Update()
    {

        transform.position += _moveVector * Time.deltaTime;
        _moveVector -= _moveVector * 3f * Time.deltaTime;

        if (_disappearTimer > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            float increaseScaleAmount = 3.5f;
            transform.localScale += Vector3.forward * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 3.5f;
            transform.localScale -= Vector3.forward * decreaseScaleAmount * Time.deltaTime;
        }

        _disappearTimer -= Time.deltaTime;
        if (_disappearTimer < 0)
        {
            float disappearSpeed = 15f;
            _textColor.a -= disappearSpeed * Time.deltaTime;
            _textMesh.color = _textColor;
            if (_textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

