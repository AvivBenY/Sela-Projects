#pragma checksum "C:\Users\benye\source\repos\Evil Cat 2.0\Evil Cat 2.0\Game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4C4D45A5C07E3188E1CA066E1BD9F6BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evil_Cat_2._0
{
    partial class Game : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Game.xaml line 11
                {
                    this.GameBoard = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 3: // Game.xaml line 15
                {
                    this.MeterCounter = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Game.xaml line 16
                {
                    this.EvilCatPlayer = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 5: // Game.xaml line 17
                {
                    this.TuggleTimerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.TuggleTimerButton).Click += this.TuggleButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

