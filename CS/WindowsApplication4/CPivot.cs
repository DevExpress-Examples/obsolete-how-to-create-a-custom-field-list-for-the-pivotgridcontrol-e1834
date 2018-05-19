using System;
using System.Collections;
using System.Text;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraEditors.Customization;

namespace MyControls
{
    public class CPivotGridControl : PivotGridControl
    {
        protected override DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData CreateData()
        {
            return new CPivotGridViewInfoData(this);
        }
    }

    public class CPivotGridViewInfoData : PivotGridViewInfoData
    {
        public CPivotGridViewInfoData(PivotGridControl pivot) : base(pivot) { }

        protected override CustomizationForm CreateCustomizationForm(CustomizationFormStyle style) {
            return new CCustomizationForm(this);
        }        
    }

    public class CCustomizationForm : CustomizationForm
    {
        public CCustomizationForm(PivotGridViewInfoData data) : base(data, CustomizationFormStyle.Simple) { }

        protected override CustomCustomizationListBoxBase CreateCustomizationListBox() {
            return new CFieldCustomizationListBox(this);
        }
    }

	public class CFieldCustomizationListBox : FieldCustomizationTreeBox
    {
        public CFieldCustomizationListBox(CustomizationForm form) : base(form) { }

		protected new CCustomizationForm CustomizationForm { get { return (CCustomizationForm)base.CustomizationForm; } }
        public override void Populate()
        {
            this.BeginUpdate();
            try
            {
                Items.Clear();
                ArrayList list = new ArrayList();
				foreach (PivotGridFieldBase f in CustomizationForm.Data.Fields) {
					list.Add(f);
				}
                list.Sort(new myComparer());
				foreach(PivotGridFieldBase f in list)
                {
					Items.Add(CreateTreeNode(f));
                }
            }
            finally
            {
                this.EndUpdate();
            }
        }
		object CreateTreeNode(PivotGridFieldBase f) {
            return new PivotCustomizationTreeNode((PivotGridField)f);
		}
    }

    public class myComparer : IComparer
    {
        IComparer comparer = new CaseInsensitiveComparer();
        int IComparer.Compare(Object x, Object y)
        {
            PivotGridFieldBase fieldx = x as PivotGridFieldBase;
            PivotGridFieldBase fieldy = y as PivotGridFieldBase;

            if (fieldx != null && fieldy != null)
            {
                string valx = string.IsNullOrEmpty(fieldx.Caption) ? fieldx.FieldName : fieldx.Caption;
                string valy = string.IsNullOrEmpty(fieldy.Caption) ? fieldy.FieldName : fieldy.Caption;
                return comparer.Compare(valx, valy);
            }
            return (comparer.Compare(y, x));
        }
    }


}
