using System.Windows;

namespace CustomEditingFieldsSelector {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            preview.DocumentSource = new XtraReport1();
        }
    }
}
