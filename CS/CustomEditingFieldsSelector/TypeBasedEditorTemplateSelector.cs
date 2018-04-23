using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CustomEditingFieldsSelector {
    public class TypeBasedEditorTemplateSelector : EditingFieldTemplateSelector {
        public DataTemplate Int32Template { get; set; }
        public DataTemplate DateTimeTemplate { get; set; }
        public DataTemplate EnumTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            var field = item as EditingField;

            if(field.EditValue != null && field.EditValue is Enum) {
                return EnumTemplate;
            } else if(field.EditValue is DateTime) {
                return DateTimeTemplate;
            } else if(field.EditValue is Int32) {
                return Int32Template;
            }

            return base.SelectTemplate(item, container);
        }
    }

    public class EnumValueToEnumSourceConverter : MarkupExtension, IValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(!(value is Enum))
                throw new InvalidOperationException();
            return Enum.GetValues(value.GetType());
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
