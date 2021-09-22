using System;
using System.Windows.Markup;

namespace WpfBase.ViewModel
{
    public class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new Exception("Enum null or not of type Enum.");
            }

            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Array enumValues = Enum.GetValues(EnumType);
            return enumValues;
        }
    }
}
