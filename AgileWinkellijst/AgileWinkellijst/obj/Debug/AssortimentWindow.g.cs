﻿#pragma checksum "..\..\AssortimentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99E1FAE0C8D1BA2E8A1E676E7E323F86F1837548E253E08ACF805C483CB2ED0B"
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


namespace AgileWinkellijst {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAssortiment;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNieuwArtikel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWinkellijst;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsearch;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAfdeling;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbWinkellijstselecteren;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AssortimentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spArtikellijst;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AgileWinkellijst;component/assortimentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AssortimentWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\AssortimentWindow.xaml"
            ((AgileWinkellijst.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblAssortiment = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnNieuwArtikel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\AssortimentWindow.xaml"
            this.btnNieuwArtikel.Click += new System.Windows.RoutedEventHandler(this.btnNieuwArtikel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnWinkellijst = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\AssortimentWindow.xaml"
            this.btnWinkellijst.Click += new System.Windows.RoutedEventHandler(this.btnWinkellijst_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnsearch = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AssortimentWindow.xaml"
            this.btnsearch.Click += new System.Windows.RoutedEventHandler(this.btnsearch_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbAfdeling = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\AssortimentWindow.xaml"
            this.cbAfdeling.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbAfdeling_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbWinkellijstselecteren = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.spArtikellijst = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

