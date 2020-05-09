using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewIssues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionItemView : ContentView
    {
        public CollectionItemView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ModelProperty =
            BindableProperty.Create("Model", typeof(CollectionItemModel), typeof(CollectionItemView), default(CollectionItemModel));

        public CollectionItemModel Model
        {
            get => (CollectionItemModel) GetValue(ModelProperty);
            set => SetValue(ModelProperty, value);
        }
    }
}