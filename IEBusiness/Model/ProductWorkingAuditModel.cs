
using System;
namespace IE.Model
{
    public class ProductWorkingAuditModel : BaseModel
    {
        private int iD;
        private int productWorkingID;
        private int productID;
        private int productStepID;
        private int workingID;
        private string workingName;
        private int valueType;
        private string valueTypeName;
        private string periodValue;
        private decimal minValue;
        private decimal maxValue;
        private string unit;
        private int sortOrder;
        private int checkValueType;
        private string productStepCode;
        private decimal minValueNew;
        private decimal maxValueNew;
        private string periodValueNew;
        private string productStepCodeNew;
        private string workingNameNew;
        private int sortOrderNew;
        private int valueTypeNew;
        private int checkValueTypeNew;
        private int actionType;
        private string reasonChange;
        private int isApproved;
        private string userApproved;
        private string createdBy;
        private DateTime? createdDate;
        private string updatedBy;
        private DateTime? updatedDate;
        public bool IsHidden { get; set; }
        public bool IsHiddenNew { get; set; }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public int ProductWorkingID
        {
            get { return productWorkingID; }
            set { productWorkingID = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public int ProductStepID
        {
            get { return productStepID; }
            set { productStepID = value; }
        }

        public int WorkingID
        {
            get { return workingID; }
            set { workingID = value; }
        }

        public string WorkingName
        {
            get { return workingName; }
            set { workingName = value; }
        }

        public int ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }

        public string ValueTypeName
        {
            get { return valueTypeName; }
            set { valueTypeName = value; }
        }

        public string PeriodValue
        {
            get { return periodValue; }
            set { periodValue = value; }
        }

        public decimal MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public decimal MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public int SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }

        public int CheckValueType
        {
            get { return checkValueType; }
            set { checkValueType = value; }
        }

        public string ProductStepCode
        {
            get { return productStepCode; }
            set { productStepCode = value; }
        }

        public decimal MinValueNew
        {
            get { return minValueNew; }
            set { minValueNew = value; }
        }

        public decimal MaxValueNew
        {
            get { return maxValueNew; }
            set { maxValueNew = value; }
        }

        public string PeriodValueNew
        {
            get { return periodValueNew; }
            set { periodValueNew = value; }
        }

        public string ProductStepCodeNew
        {
            get { return productStepCodeNew; }
            set { productStepCodeNew = value; }
        }

        public string WorkingNameNew
        {
            get { return workingNameNew; }
            set { workingNameNew = value; }
        }

        public int SortOrderNew
        {
            get { return sortOrderNew; }
            set { sortOrderNew = value; }
        }

        public int ValueTypeNew
        {
            get { return valueTypeNew; }
            set { valueTypeNew = value; }
        }

        public int CheckValueTypeNew
        {
            get { return checkValueTypeNew; }
            set { checkValueTypeNew = value; }
        }

        public int ActionType
        {
            get { return actionType; }
            set { actionType = value; }
        }

        public string ReasonChange
        {
            get { return reasonChange; }
            set { reasonChange = value; }
        }

        public int IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }

        public string UserApproved
        {
            get { return userApproved; }
            set { userApproved = value; }
        }

        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public DateTime? CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        public DateTime? UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }
       
    }
}
