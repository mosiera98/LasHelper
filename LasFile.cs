using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LasHelper
{

    /// <summary>
    /// Class to hold las data
    /// </summary>
    [Serializable]
    public sealed class  LasFile
    {
        #region Properties

        /// <summary>
        /// Gets the file headers
        /// </summary>
        public readonly List<string> Headers = new List<string>();

        /// <summary>
        /// Gets the records in the file
        /// </summary>
        public readonly LasRecords Records = new LasRecords();

        /// <summary>
        /// Gets the header count
        /// </summary>
        public int HeaderCount
        {
            get
            {
                return Headers.Count;
            }
        }

        /// <summary>
        /// Gets the record count
        /// </summary>
        public int RecordCount
        {
            get
            {
                return Records.Count;
            }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Gets a record at the specified index
        /// </summary>
        /// <param name="recordIndex">Record index</param>
        /// <returns>LasRecord</returns>
        public LasRecord this[int recordIndex]
        {
            get
            {
                if (recordIndex > (Records.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no record at index {0}.", recordIndex));

                return Records[recordIndex];
            }
        }

        /// <summary>
        /// Gets the field value at the specified record and field index
        /// </summary>
        /// <param name="recordIndex">Record index</param>
        /// <param name="fieldIndex">Field index</param>
        /// <returns></returns>
        public string this[int recordIndex, int fieldIndex]
        {
            get
            {
                if (recordIndex > (Records.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no record at index {0}.", recordIndex));

                LasRecord record = Records[recordIndex];
                if (fieldIndex > (record.Fields.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));

                return record.Fields[fieldIndex];
            }
            set
            {
                if (recordIndex > (Records.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no record at index {0}.", recordIndex));

                LasRecord record = Records[recordIndex];

                if (fieldIndex > (record.Fields.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no field at index {0}.", fieldIndex));

                record.Fields[fieldIndex] = value;
            }
        }

        /// <summary>
        /// Gets the field value at the specified record index for the supplied field name
        /// </summary>
        /// <param name="recordIndex">Record index</param>
        /// <param name="fieldName">Field name</param>
        /// <returns></returns>
        public string this[int recordIndex, string fieldName]
        {
            get
            {
                if (recordIndex > (Records.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no record at index {0}.", recordIndex));

                LasRecord record = Records[recordIndex];

                int fieldIndex = -1;

                for (int i = 0; i < Headers.Count; i++)
                {
                    if (string.Compare(Headers[i], fieldName) != 0)
                        continue;

                    fieldIndex = i;
                    break;
                }

                if (fieldIndex == -1)
                    throw new ArgumentException(string.Format("There is no field header with the name '{0}'", fieldName));

                if (fieldIndex > (record.Fields.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));

                return record.Fields[fieldIndex];
            }
            set
            {
                if (recordIndex > (Records.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no record at index {0}.", recordIndex));

                LasRecord record = Records[recordIndex];

                int fieldIndex = -1;

                for (int i = 0; i < Headers.Count; i++)
                {
                    if (string.Compare(Headers[i], fieldName) != 0)
                        continue;

                    fieldIndex = i;
                    break;
                }

                if (fieldIndex == -1)
                    throw new ArgumentException(string.Format("There is no field header with the name '{0}'", fieldName));

                if (fieldIndex > (record.Fields.Count - 1))
                    throw new IndexOutOfRangeException(string.Format("There is no field at index {0} in record {1}.", fieldIndex, recordIndex));

                record.Fields[fieldIndex] = value;
            }
        }

        #endregion Indexers

        #region Methods

        /// <summary>
        /// Populates the current instance from the specified file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        public void Populate(string filePath, bool hasHeaderRow)
        {
            Populate(filePath, null, hasHeaderRow, false);
        }

        /// <summary>
        /// Populates the current instance from the specified file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(string filePath, bool hasHeaderRow, bool trimColumns)
        {
            Populate(filePath, null, hasHeaderRow, trimColumns);
        }

        /// <summary>
        /// Populates the current instance from the specified file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(string filePath, Encoding encoding, bool hasHeaderRow, bool trimColumns)
        {
            using (LasReader reader = new LasReader(filePath, encoding) { HasHeaderRow = hasHeaderRow, TrimColumns = trimColumns })
            {
                PopulateLasFile(reader);
            }
        }

        /// <summary>
        /// Populates the current instance from a stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        public void Populate(Stream stream, bool hasHeaderRow)
        {
            Populate(stream, null, hasHeaderRow, false);
        }

        /// <summary>
        /// Populates the current instance from a stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(Stream stream, bool hasHeaderRow, bool trimColumns)
        {
            Populate(stream, null, hasHeaderRow, trimColumns);
        }

        /// <summary>
        /// Populates the current instance from a stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(Stream stream, Encoding encoding, bool hasHeaderRow, bool trimColumns)
        {
            using (LasReader reader = new LasReader(stream, encoding) { HasHeaderRow = hasHeaderRow, TrimColumns = trimColumns })
            {
                PopulateLasFile(reader);
            }
        }

        /// <summary>
        /// Populates the current instance from a string
        /// </summary>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="LasContent">Las text</param>
        public void Populate(bool hasHeaderRow, string LasContent)
        {
            Populate(hasHeaderRow, LasContent, null, false);
        }

        /// <summary>
        /// Populates the current instance from a string
        /// </summary>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="LasContent">Las text</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(bool hasHeaderRow, string LasContent, bool trimColumns)
        {
            Populate(hasHeaderRow, LasContent, null, trimColumns);
        }

        /// <summary>
        /// Populates the current instance from a string
        /// </summary>
        /// <param name="hasHeaderRow">True if the file has a header row, otherwise false</param>
        /// <param name="LasContent">Las text</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="trimColumns">True if column values should be trimmed, otherwise false</param>
        public void Populate(bool hasHeaderRow, string LasContent, Encoding encoding, bool trimColumns)
        {
            using (LasReader reader = new LasReader(encoding, LasContent) { HasHeaderRow = hasHeaderRow, TrimColumns = trimColumns })
            {
                PopulateLasFile(reader);
            }
        }

        /// <summary>
        /// Populates the current instance using the LasReader object
        /// </summary>
        /// <param name="reader">LasReader</param>
        private void PopulateLasFile(LasReader reader)
        {
            Headers.Clear();
            Records.Clear();

            bool addedHeader = false;

            while (reader.ReadNextRecord())
            {
                if (reader.HasHeaderRow && !addedHeader)
                {
                    reader.Fields.ForEach(field => Headers.Add(field));
                    addedHeader = true;
                    continue;
                }

                LasRecord record = new LasRecord();
                reader.Fields.ForEach(field => record.Fields.Add(field));
                Records.Add(record);
            }
        }

        #endregion Methods

    }
    /// <summary>
    /// Class for a collection of LasRecord objects
    /// </summary>
    [Serializable]
    public sealed class LasRecords : List<LasRecord>
    {
    }

    /// <summary>
    /// Las record class
    /// </summary>
    [Serializable]
    public sealed class LasRecord
    {
        #region Properties

        /// <summary>
        /// Gets the Fields in the record
        /// </summary>
        public readonly List<string> Fields = new List<string>();

        /// <summary>
        /// Gets the number of fields in the record
        /// </summary>
        public int FieldCount
        {
            get
            {
                return Fields.Count;
            }
        }

        #endregion Properties
    }
}
