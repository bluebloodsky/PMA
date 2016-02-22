using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace MyControl
{
    public class YearMonthEdit : DateEdit
    {
        public YearMonthEdit()
        {
            Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            Properties.DisplayFormat.FormatString = "yyyy-MM";
            Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Properties.Mask.EditMask = "yyyy-MM";
            Properties.ShowToday = false;
        }
        protected override PopupBaseForm CreatePopupForm()
        {
            if (Properties.VistaDisplayMode == DevExpress.Utils.DefaultBoolean.True)
                return new CustomVistaPopupDateEditForm(this);
            return new PopupDateEditForm(this);
        }
        private DateResultModeEnum _dateMode = DateResultModeEnum.FirstDayOfMonth;
        public DateResultModeEnum DateMode
        {
            get { return _dateMode; }
            set { _dateMode = value; }
        }

        public enum DateResultModeEnum : int
        {
            //虽然是年月控件，但日期Datetime肯定是2012-01-01这种格式
            //所以，这个枚举定义了年月控件返回本月的第一天，还是本月的最后一天作为DateEditEx的值
            FirstDayOfMonth = 1,
            LastDayOfMonth = 2
        }

    }
    public class CustomVistaPopupDateEditForm : VistaPopupDateEditForm
    {
        public CustomVistaPopupDateEditForm(DateEdit ownerEdit) : base(ownerEdit) { }
        protected override DateEditCalendar CreateCalendar()
        {
            return new CustomVistaDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue);
        }
    }
    public class CustomVistaDateEditCalendar : VistaDateEditCalendar
    {
        public CustomVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate) : base(item, editDate) { }

        protected override void Init()
        {
            base.Init();
            this.View = DateEditCalendarViewType.YearInfo;
        }
        public YearMonthEdit.DateResultModeEnum DateMode
        {
            get { return ((YearMonthEdit)this.Properties.OwnerEdit).DateMode; }
        }
        protected override void OnItemClick(DevExpress.XtraEditors.Calendar.CalendarHitInfo hitInfo)
        {
            DayNumberCellInfo cell = hitInfo.HitObject as DayNumberCellInfo;
            if (View == DateEditCalendarViewType.YearInfo)
            {
                DateTime dt = new DateTime(DateTime.Year, cell.Date.Month, 1, 0, 0, 0);
                if (DateMode == YearMonthEdit.DateResultModeEnum.FirstDayOfMonth)
                {

                    OnDateTimeCommit(dt, false);
                }
                else
                {
                    DateTime tempDate = dt.AddMonths(1).AddDays(-1);
                    tempDate = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, 23, 59, 59);
                    OnDateTimeCommit(tempDate, false);
                }
            }
            else
                base.OnItemClick(hitInfo);
        }
    }
}
