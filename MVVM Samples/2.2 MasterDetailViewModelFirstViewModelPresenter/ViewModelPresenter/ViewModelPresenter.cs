using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter
{
    public class ViewModelPresenter : ContentControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(object), typeof(ViewModelPresenter), new PropertyMetadata(default(object), OnViewModelChanged));

        public object ViewModel
        {
            get { return (object)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ViewModelPresenter)d).RefreshContentPresenter();
        }

        //DependencyProperty ViewModel
        private void RefreshContentPresenter()
        {
            if (ViewModel == null)
            {
                Content = null;
                return;
            }

            // берем из сервис локатора TypeMapper
            var viewTypeResolver = ServiceLocator.Current.GetInstance<IViewTypeResolver>();
            var viewType = viewTypeResolver.ResolveViewType(ViewModel.GetType()); // пытаемся получить сответствующий текущему ViewModel тип представления

            if (viewType == null)
            {
                Content = null;
            }
            else
            {
                var viewObject = Activator.CreateInstance(viewType); // создаем представление полученного типа
                Debug.Assert(viewObject is FrameworkElement); // если False, то отладчик бросает исключение и переходит в эту точку для пошаговой отладки

                var view = (FrameworkElement)viewObject;
                view.DataContext = ViewModel;
                Content = view;
            }
        }
    }
}