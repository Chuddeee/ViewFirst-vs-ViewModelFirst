using System;

namespace _3.Common.ViewTypeResolver
{
    /// <summary>
    /// Сервис получения типа View сопоставленного с типом ViewModel посредством соглашения по именованию и расположению
    /// </summary>
    public class NamingConventionViewTypeResolver : IViewTypeResolver
    {
        public Type ResolveViewType(Type viewModelType)
        {
            //TODO Implement
            var viewTypeName = viewModelType.Name.Replace("ViewModel", "View");
            var fullName = string.Format("{0}.{1}, {2}", "_2._2_MasterDetailViewModelFirstViewModelPresenter.Views", viewTypeName, "2.2 MasterDetailViewModelFirstViewModelPresenter");
            return Type.GetType(fullName);
        }
    }
}