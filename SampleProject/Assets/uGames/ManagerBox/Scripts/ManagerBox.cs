using System;
using System.Collections.Generic;
using uGames;
using uGames.Interfaces;
using uGames.Managers;

/// <summary>
/// 
/// </summary>
public class ManagerBox : Singleton<ManagerBox>
{
    /// <summary>
    /// Контейнер для всех менеджеров. Ключом выступает тип менеджера. Значением любой object.
    /// Таким образом в данный контейнер можно поместить только один GameManager либо любой другой тип,
    /// но в единственном экземпляре
    /// </summary>
    private Dictionary<Type, object> _data = new Dictionary<Type, object>();

    /// <summary>
    /// Добавляет менеджеры в ManagerBox
    /// </summary>
    /// <param name="obj"></param>
    public static void Add(object obj)
    {
        object add = obj;
        ManagerBase manager = obj as ManagerBase;

        /*
         * Позволяет создать Manager наследуемый от ScriptavleObject так, чтобы данные после завершения сцены
         * не затерлись
         */
        if (manager) add = Instantiate(manager);
        else return;

        //Добавление в Dictionary (ключ = Тип переданого объекта, значение = переданный объект)
        Instance._data.Add(obj.GetType(), add);

        //Вызываем OnAwake у менеджеров, если такой интерфейс у них имется
        if (add is IAwake)
        {
            (add as IAwake).OnAwake();
        }
    }

    /// <summary>
    /// Функция пытается вернуть значение по параметру 
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого параметра </typeparam>
    /// <returns></returns>
    public static T TryGetManager<T>()
    {
        object resolve;
        Instance._data.TryGetValue(typeof(T), out resolve);
        return (T) resolve;
    }
}