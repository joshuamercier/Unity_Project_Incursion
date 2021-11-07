public class Quit : ButtonObject
{
    protected override void OnClicked()
    {
        mainManager.Exit();
    }
}
