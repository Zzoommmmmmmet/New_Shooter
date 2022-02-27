using System;
using System.Threading.Tasks;

public interface IActionCommand // паттерн Комманд
{
    void Execute();
}

public interface IActionCommand<TParam> // паттерн Комманд (который принимает любую переменную)
{
    void Execute(TParam param); // метод с переменной
}

public interface IActionCommandAsync // паттерн Комманд для асинка (перезарядки игрока при стрельбе)
{
    Task Execute();
}