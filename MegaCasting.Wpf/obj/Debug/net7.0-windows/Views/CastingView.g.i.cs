﻿#pragma checksum "..\..\..\..\Views\CastingView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0F418EB86CC8EC207BE5C517469E93906B3E3D3B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MegaCasting.Wpf;
using MegaCasting.Wpf.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MegaCasting.Wpf.Views {
    
    
    /// <summary>
    /// CastingView
    /// </summary>
    public partial class CastingView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Views\CastingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelCastingsTitle;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\CastingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _AddCastingButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Views\CastingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _ShowCastingButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\CastingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _UpdateCastingButton;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\CastingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _DeleteCastingButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MegaCasting.Wpf;component/views/castingview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CastingView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LabelCastingsTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this._AddCastingButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\Views\CastingView.xaml"
            this._AddCastingButton.Click += new System.Windows.RoutedEventHandler(this.Create_Casting_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this._ShowCastingButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Views\CastingView.xaml"
            this._ShowCastingButton.Click += new System.Windows.RoutedEventHandler(this.Show_Details_Casting);
            
            #line default
            #line hidden
            return;
            case 4:
            this._UpdateCastingButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Views\CastingView.xaml"
            this._UpdateCastingButton.Click += new System.Windows.RoutedEventHandler(this.Edit_Casting_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this._DeleteCastingButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Views\CastingView.xaml"
            this._DeleteCastingButton.Click += new System.Windows.RoutedEventHandler(this.Delete_Casting_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

