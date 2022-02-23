public interface IActionCommand
{
    void Execute();
}

public interface IActionCommand<TParam>
{
    void Execute(TParam param);
}