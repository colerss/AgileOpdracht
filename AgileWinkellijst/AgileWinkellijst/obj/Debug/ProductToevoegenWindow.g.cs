// Updated by XamlIntelliSenseFileGenerator 24/10/2020 17:42:23
#pragma checksum "..\..\ProductToevoegenWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "47292B22C952D1EBDF580E6B5762AF4B1D0D6DAE9845C8839FEE3FA9591E68C8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AgileWinkellijst;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AgileWinkellijst
{


    /// <summary>
    /// ProductToevoegenWindow
    /// </summary>
    public partial class ProductToevoegenWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 35 "..\..\ProductToevoegenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnArtikelAanmaken;

#line default
#line hidden


#line 36 "..\..\ProductToevoegenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNaarWinkellijst;

#line default
#line hidden


#line 37 "..\..\ProductToevoegenWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNaarArtikellijst;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AgileWinkellijst;component/producttoevoegenwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\ProductToevoegenWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.lblArtikel = ((System.Windows.Controls.Label)(target));
                    return;
                case 2:
                    this.tbNaam = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.tbPrijs = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.cmbNieuwArtikelLocatie = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 5:
                    this.btnArtikelAanmaken = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.btnNaarWinkellijst = ((System.Windows.Controls.Button)(target));
                    return;
                case 7:
                    this.btnNaarArtikellijst = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Label lblWinkellijst;
        internal System.Windows.Controls.Button btnTerugNaarArtikellijst;
    }
}

