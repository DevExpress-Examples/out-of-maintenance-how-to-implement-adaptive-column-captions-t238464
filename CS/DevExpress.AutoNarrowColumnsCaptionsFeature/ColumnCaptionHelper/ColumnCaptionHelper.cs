using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;

namespace DevExpress.AutoNarrowColumnsCaptionsFeature.ColumnCaptionHelper {

    [DesignerCategory("")]
    public class ColumnCaptionHelper : Component {
        const string SEPARATOR_STRING = ";";
        public ColumnCaptionHelper() {
            CaptionItems = new CaptionItem[0];
        }

        protected override void Dispose(bool disposing) {
            Enabled = false;
            base.Dispose(disposing);
        }

        private bool _Enabled;
        private bool _AutoFill;
        private GridView _View;

        public bool Enabled {
            get { return _Enabled; }
            set {
                if(_Enabled == value)
                    return;
                _Enabled = value;
                OnChanged();
            }
        }
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
        public bool AutoFill {
            get { return _AutoFill; }
            set {
                _AutoFill = value;
                OnAutoFillChanged();
            }
        }
        public GridView View {
            get { return _View; }
            set {
                _View = value;
                OnChanged();
            }
        }
        [DisplayName("Caption Items")]
        [Description("Use ';' to separate captions")]
        public CaptionItem[] CaptionItems { get; set; }


        private void OnChanged() {
            if(View == null)
                return;
            View.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
            if(Enabled) {
                View.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
            }
            View.RefreshData();
        }

        void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
            if(e.Column != null) {
                var captionItem = CaptionItems.FirstOrDefault(x => x.FieldName == e.Column.FieldName);
                if(captionItem != null) {
                    string bestCaption = GetBestCaption(e.Cache, e.Column, e.Info.CaptionRect.Width, captionItem);
                    if (!string.IsNullOrEmpty(bestCaption))
                        e.Info.Caption = bestCaption;
                }
            }
        }

        private string GetBestCaption(GraphicsCache cache, GridColumn column, int width, CaptionItem item) {
            var captions = item.Captions.Split(new string[] { SEPARATOR_STRING }, StringSplitOptions.RemoveEmptyEntries);
            var resultItem = captions.Select(x => new { Caption = x, Width = GetTextWidth(cache, column, x) }).OrderByDescending(x => x.Width).FirstOrDefault(x => x.Width < width);
            return resultItem == null ? string.Empty : resultItem.Caption;
        }

        public int GetTextWidth(GraphicsCache cache, GridColumn column,  string text)
        {
            return column.AppearanceHeader.CalcTextSizeInt(cache, text, column.VisibleWidth).Width;
        }


        private void OnAutoFillChanged() {
            if(!_AutoFill || View == null)
                return;
            DoAutoFill();
        }

        private void DoAutoFill() {
            int length = CaptionItems.Length + View.Columns.Count;
            List<CaptionItem> captions = new List<CaptionItem>();
            captions.AddRange(CaptionItems);
            for(int i = 0; i < View.Columns.Count; i++) {
                GridColumn column = View.Columns[i];
                captions.Add(new CaptionItem() { FieldName = column.FieldName, Captions = column.GetCaption() + SEPARATOR_STRING });
            }
            CaptionItems = captions.ToArray();
        }
    }

    public class CaptionItem {
        public CaptionItem() {
        }
        public string FieldName { get; set; }

 

        public string Captions { get; set; }

        public override string ToString() {
            return string.IsNullOrEmpty(FieldName) ? "Empty item" : FieldName;
        }
    }
}
