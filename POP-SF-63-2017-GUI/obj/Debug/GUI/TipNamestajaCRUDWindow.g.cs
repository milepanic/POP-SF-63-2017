﻿#pragma checksum "..\..\..\GUI\TipNamestajaCRUDWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5790AB98889B544C0D1B396C99543767ECC0F9D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_63_2017_GUI.GUI;
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


namespace POP_SF_63_2017_GUI.GUI {
    
    
    /// <summary>
    /// TipNamestajaCRUDWindow
    /// </summary>
    public partial class TipNamestajaCRUDWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label header;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzlaz;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodaj;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisi;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-63-2017-GUI;component/gui/tipnamestajacrudwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
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
            this.header = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
            this.dataGrid.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dataGrid_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
            this.btnIzlaz.Click += new System.Windows.RoutedEventHandler(this.btnIzlaz_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
            this.btnDodaj.Click += new System.Windows.RoutedEventHandler(this.btnDodaj_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnObrisi = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
            this.btnObrisi.Click += new System.Windows.RoutedEventHandler(this.btnObrisi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\GUI\TipNamestajaCRUDWindow.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.btnIzmeni_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

