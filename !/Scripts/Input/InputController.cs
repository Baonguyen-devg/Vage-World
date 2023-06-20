using UnityEngine;

public class InputController : AutoMonobehaviour
{
    protected static InputController instance;
    [SerializeField] protected Mouse mouseInput;
    [SerializeField] protected Keyboard keyboardInput;

    public Mouse MouseInput => this.mouseInput;
    public Keyboard KeyboardInput => this.keyboardInput;
    public static InputController Instance => instance;

    protected override void LoadComponent()
    {
        InputController.instance = this;
        base.LoadComponent();
        this.LoadMouseInput();
        this.LoadKeyBoardInput();
    }

    protected virtual void LoadMouseInput()
    {
        if (this.mouseInput != null) return;
        this.mouseInput = transform.GetComponentInChildren<Mouse>();
        Debug.Log(transform.name + ": Load MouseInput", gameObject);
    }

    protected virtual void LoadKeyBoardInput()
    {
        if (this.keyboardInput != null) return;
        this.keyboardInput = transform.GetComponentInChildren<Keyboard>();
        Debug.Log(transform.name + ": Load KeyBoardInput", gameObject);
    }
}
