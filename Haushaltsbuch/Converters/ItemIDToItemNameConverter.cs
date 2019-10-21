using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Converters
{
    public class ItemIdToItemNameConverter : IValueConverter
    {
        //members
        private IItemManager _itemManager;



        //properties
        protected IItemManager ItemManager
        {
            get
            {
                return _itemManager ??= (IItemManager) ((App) Application.Current).Container.Resolve(typeof(IItemManager));
            }
        }



        //public methods
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return "choose";
            }
            else if (value is int itemId)
            {
                return ItemManager.Get(itemId).Name;
            }
            
            throw new ArgumentException($"Id '{value.ToString()}' is unknown in system and thusly cannot be converted to item name");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Two-Way binding is currently not supported with this converter");
        }
    }
}
