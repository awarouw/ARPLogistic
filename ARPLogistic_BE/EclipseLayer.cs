using System;

namespace ARPLogistic_BE
{
    public class EclipseLayer
    {
        protected short _rowStatus = 0;
        protected string _createdBy = "";
        protected DateTime? _createdTime = DateTime.Now;
        protected string _lastModifiedBy = "";
        protected DateTime? _lastModifiedTime = DateTime.Now;

        public short RowStatus
        {
            get
            {
                return _rowStatus;
            }
            set
            {
                _rowStatus = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }
            set
            {
                _createdBy = value;
            }
        }

        public DateTime? CreatedTime
        {
            get
            {
                return _createdTime;
            }
            set
            {
                _createdTime = value;
            }
        }

        public string LastModifiedBy
        {
            get
            {
                return _lastModifiedBy;
            }
            set
            {
                _lastModifiedBy = value;
            }
        }

        public DateTime? LastModifiedTime
        {
            get
            {
                return _lastModifiedTime;
            }
            set
            {
                _lastModifiedTime = value;
            }
        }
    }
}
