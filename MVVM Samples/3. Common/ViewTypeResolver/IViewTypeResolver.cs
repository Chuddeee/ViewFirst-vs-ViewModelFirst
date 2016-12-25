using System;

namespace _3.Common.ViewTypeResolver
{
    /// <summary>
    /// Интерфейс сервиса реализующего получение типа View сопоставленного с типом ViewModel
    /// </summary>
    public interface IViewTypeResolver
    {
        Type ResolveViewType(Type viewModelType);
    }
}