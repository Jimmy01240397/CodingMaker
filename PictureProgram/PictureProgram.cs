using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PictureProgram
{
    public partial class PictureProgram: UserControl
    {
        #region variable


        #endregion variable

        #region Attributes

        [Browsable(true), Category("指令"), Description("程式種類"), DefaultValue(TypeEnum.前置處理)]
        public TypeEnum TypeOf
        {
            get; set;
        }

        [Browsable(true), Category("指令"), Description("指令內容")]
        public string TextIn
        {
            get;
            set;
        }


        #endregion Attributes

        #region Methods

        #endregion Methods

        #region Constructors
        public PictureProgram()
        {
            InitializeComponent();
        }

        #endregion Constructors

    }
}
